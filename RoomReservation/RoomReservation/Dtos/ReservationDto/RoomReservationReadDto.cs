using RoomReservation.Models;

namespace RoomReservation.Dtos.ReservationDto
{
    public class RoomReservationReadDto
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public static RoomReservationReadDto FromEntity(Room room)
        {
            if (room == null)
            {
                return null;
            }
            return new RoomReservationReadDto
            {
                Id = room.Id,
                Name = room.Name
            };
        }
    }
}