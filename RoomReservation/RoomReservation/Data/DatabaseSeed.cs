using System;
using System.Linq;
using RoomReservation.Models;

namespace RoomReservation.Data
{
    public class DatabaseSeed
    {
        public static void SeedDatabase(ApplicationDbContext dbContext)
        {
            if (dbContext.Rooms.Any() || dbContext.Reservations.Any())
            {
                return;
            }

            var roomOne = dbContext.Rooms.Add(new Room {Name = "Room 1"}).Entity;
            var roomTwo = dbContext.Rooms.Add(new Room {Name = "Room 2"}).Entity;
            var roomThree = dbContext.Rooms.Add(new Room {Name = "Room 3"}).Entity;
            var roomFour = dbContext.Rooms.Add(new Room {Name = "Room 4"}).Entity;
            var roomFive = dbContext.Rooms.Add(new Room {Name = "Room 5"}).Entity;
            var roomSix = dbContext.Rooms.Add(new Room {Name = "Room 6"}).Entity;
            
            dbContext.SaveChanges();
        }
    }
}