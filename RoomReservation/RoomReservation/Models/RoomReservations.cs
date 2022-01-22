using System;
using System.ComponentModel.DataAnnotations.Schema;
using RoomReservation.Authentication;

namespace RoomReservation.Models
{
    public class RoomReservations : BaseEntity
    {
        public int RoomId { get; set; }
        public Room Room { get; set; }
        
        [Column(TypeName="date")]
        public DateTime StartDate { get; set; }
        [Column(TypeName="date")]
        public DateTime EndDate { get; set; }
        
        public ApplicationUser User { get; set; }
    }
}