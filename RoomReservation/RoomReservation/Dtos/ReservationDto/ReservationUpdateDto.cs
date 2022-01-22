using System;
using RoomReservation.Models;

namespace RoomReservation.Dtos.ReservationDto
{
    public class ReservationUpdateDto
    {
        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }
        public int RoomId { get; set; }


        public RoomReservations ToEntity(int id)
        {
            return new RoomReservations
            {
                StartDate = StartDate,
                EndDate = EndDate,
                RoomId = RoomId,
                Id = id
            };
        }
    }
}