using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RoomReservation.Models;

namespace RoomReservation.Data.RoomRepository
{
    public interface IRoomRepository
    {
        Task<IList<Room>> GetRooms();

        Task<IList<Room>> GetAvailableRoomsForDate(DateTime date);

        Task<IList<Room>> GetAvailableRoomsForPeriod(DateTime startPeriod, DateTime EndPeriod);
    }
}