using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RoomReservation.Models;

namespace RoomReservation.Data.RoomRepository
{
    public class SqlRoomRepository : IRoomRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public SqlRoomRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<Room>> GetRooms()
        {
            var roomsAvailable = await _dbContext.Rooms.ToListAsync();
            return roomsAvailable;
        }

        public async Task<IList<Room>> GetAvailableRoomsForDate(DateTime date)
        {
            var roomsAvailable = await _dbContext.Rooms.Where(r =>
                !r.Reservations.Any(rr =>
                    rr.StartDate <= date.Date && rr.EndDate >= date.Date
                )
            ).ToListAsync();

            return roomsAvailable;
        }

        public async Task<IList<Room>> GetAvailableRoomsForPeriod(DateTime startPeriod, DateTime endPeriod)
        {
            var roomsAvailable = await _dbContext.Rooms
                .Include(r => r.Reservations.Where(rr =>
                    rr.StartDate <= startPeriod.Date && rr.EndDate >= startPeriod.Date ||
                    rr.StartDate >= startPeriod.Date && rr.EndDate <= endPeriod.Date ||
                    rr.StartDate <= endPeriod.Date && rr.EndDate >= endPeriod.Date))
                .ThenInclude(rr => rr.User)
                .ToListAsync();

            return roomsAvailable;
        }
    }
}