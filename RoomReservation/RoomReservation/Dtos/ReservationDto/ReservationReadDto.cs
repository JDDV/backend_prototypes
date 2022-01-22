using System;
using RoomReservation.Models;

namespace RoomReservation.Dtos.ReservationDto
{
    public class ReservationReadDto
    {
        public int Id { get; set; }
        
        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }
        
        public string UserName { get; set; }
        
        public RoomReservationReadDto Room { get; set; }

        public static ReservationReadDto FromEntity(RoomReservations reservation)
        {
            if (reservation == null)
            {
                return null;
            }
            return new ReservationReadDto
            {
                Id = reservation.Id,
                StartDate = reservation.StartDate,
                EndDate = reservation.EndDate,
                UserName = reservation.User?.UserName,
                Room = RoomReservationReadDto.FromEntity(reservation.Room)
            };
        }
    }
}