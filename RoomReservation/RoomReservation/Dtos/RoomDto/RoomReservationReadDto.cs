using System;
using RoomReservation.Models;

namespace RoomReservation.Dtos.RoomDto
{
    public class RoomReservationReadDto
    {
        public int Id { get; set; }
        
        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }
        
        public string UserName { get; set; }

        public static RoomReservationReadDto FromEntity(RoomReservations reservation)
        {
            if (reservation == null)
            {
                return null;
            }
            return new RoomReservationReadDto
            {
                Id = reservation.Id,
                StartDate = reservation.StartDate,
                EndDate = reservation.EndDate,
                UserName = reservation.User?.UserName
            };
        }
    }
}