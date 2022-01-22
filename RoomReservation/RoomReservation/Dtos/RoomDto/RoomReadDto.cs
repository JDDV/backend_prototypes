using RoomReservation.Models;

namespace RoomReservation.Dtos.RoomDto
{
    public class RoomReadDto
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public static RoomReadDto FromEntity(Room room)
        {
            if (room == null)
            {
                return null;
            }
            return new RoomReadDto
            {
                Id = room.Id,
                Name = room.Name
            };
        }
    }
}