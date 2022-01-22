using System.Collections.Generic;
using System.Linq;
using RoomReservation.Models;

namespace RoomReservation.Dtos.RoomDto
{
    public class RoomWithReservationsDto : RoomReadDto
    {
        public IList<RoomReservationReadDto> Reservations { get; set; }
        
        public new static RoomWithReservationsDto FromEntity(Room room)
        {
            if (room == null)
            {
                return null;
            }
            return new RoomWithReservationsDto
            {
                Reservations = room.Reservations.Select(RoomReservationReadDto.FromEntity).ToList(),
                Id = room.Id,
                Name = room.Name
            };
        }
    }
}