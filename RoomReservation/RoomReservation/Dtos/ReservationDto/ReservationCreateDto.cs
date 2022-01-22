using System;
using RoomReservation.Authentication;
using RoomReservation.Models;

namespace RoomReservation.Dtos.ReservationDto
{
    public class ReservationCreateDto
    {
        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }
        
        public int RoomId { get; set; }

        public RoomReservations ToEntity(ApplicationUser user)
        {
            return new RoomReservations
            {
                StartDate = StartDate,
                EndDate = EndDate,
                RoomId = RoomId,
                User = user
            };
        }
    }
}