using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RoomReservation.Models;

namespace RoomReservation.Data.ReservationRepository
{
    public class SqlReservationRepository : IReservationRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public SqlReservationRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<RoomReservations>> GetReservations()
        {
            return await _dbContext.Reservations
                .Include(r => r.Room)
                .Include(r => r.User)
                .ToListAsync();
        }

        public async Task<RoomReservations> AddReservation(RoomReservations reservation)
        {
            if (reservation.StartDate > reservation.EndDate)
            {
                throw new ArgumentException("Reservation cannot be created. The start date is later than the end date.");
            }
            
            var reservationPossible = await _dbContext.Reservations
                .AnyAsync(rr =>
                    rr.StartDate <= reservation.StartDate.Date && rr.EndDate >= reservation.StartDate.Date && rr.RoomId == reservation.RoomId ||
                    rr.StartDate >= reservation.StartDate.Date && rr.EndDate <= reservation.EndDate.Date && rr.RoomId == reservation.RoomId ||
                    rr.StartDate <= reservation.EndDate.Date && rr.EndDate >= reservation.EndDate.Date && rr.RoomId == reservation.RoomId);
            
            if (reservationPossible)
            {
                throw new ArgumentException(
                    "Reservation cannot be created. Another reservation already exists for that room in that timeslot.");
            }

            await _dbContext.Reservations.AddAsync(reservation);
            await _dbContext.SaveChangesAsync();
            reservation.Room = await _dbContext.Rooms.FirstOrDefaultAsync(r => r.Id == reservation.RoomId);
            return reservation;
        }

        public async Task<RoomReservations> UpdateReservation(RoomReservations reservation, string userName)
        {
            if (reservation.StartDate > reservation.EndDate)
            {
                throw new ArgumentException("Reservation cannot be updated. The start date is later than the end date.");
            }

            var reservationPossible = await _dbContext.Reservations
                .Where(rr =>
                    rr.Id != reservation.Id)
                .AnyAsync(rr =>
                    rr.StartDate <= reservation.StartDate.Date && rr.EndDate >= reservation.StartDate.Date ||
                    rr.StartDate >= reservation.StartDate.Date && rr.EndDate <= reservation.EndDate.Date ||
                    rr.StartDate <= reservation.EndDate.Date && rr.EndDate >= reservation.EndDate.Date);

            if (reservationPossible)
            {
                throw new ArgumentException(
                    "Reservation cannot be updated. Another reservation already exists in that period!");
            }

            reservation.User = (await _dbContext.Reservations.Include(r => r.User)
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.Id == reservation.Id))?.User;

            if (reservation.User != null && reservation.User.UserName != userName)
            {
                throw new ArgumentException("Reservation cannot be updated. This reservation is not yours!");
            }


            _dbContext.Reservations.Update(reservation);
            await _dbContext.SaveChangesAsync();
            reservation.Room = await _dbContext.Rooms.FirstOrDefaultAsync(r => r.Id == reservation.RoomId);
            return reservation;
        }

        public async Task DeleteReservation(int reservationId, string userName)
        {
            var reservation =
                await _dbContext.Reservations.FirstOrDefaultAsync(r =>
                    r.Id == reservationId && r.User.UserName == userName);
            if (reservation == null)
            {
                throw new ArgumentException(
                    "Reservation cannot be removed. This reservation might not exist or you are trying to delete another user's reservation!");
            }

            _dbContext.Remove(reservation);
            await _dbContext.SaveChangesAsync();
        }
    }
}