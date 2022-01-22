using System.Collections.Generic;

namespace RoomReservation.Models
{
    public class Room : BaseEntity
    {
        public string Name { get; set; }
        
        public IList<RoomReservations> Reservations { get; set; }
    }
}