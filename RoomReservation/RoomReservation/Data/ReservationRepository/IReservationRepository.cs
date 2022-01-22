using System.Collections.Generic;
using System.Threading.Tasks;
using RoomReservation.Models;

namespace RoomReservation.Data.ReservationRepository
{
    public interface IReservationRepository
    {
        Task<IList<RoomReservations>> GetReservations();
        Task<RoomReservations> AddReservation(RoomReservations reservation);
        Task<RoomReservations> UpdateReservation(RoomReservations reservation, string userName);
        Task DeleteReservation(int reservationId, string userName);
    }
}