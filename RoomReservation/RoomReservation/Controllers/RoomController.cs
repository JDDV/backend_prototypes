using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoomReservation.Data.RoomRepository;
using RoomReservation.Dtos.RoomDto;

namespace RoomReservation.Controllers
{
    [ApiController]
    [Route("api/room")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomRepository _roomRepository;
        public RoomController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        
        [HttpGet]
        public async Task<IList<RoomReadDto>> GetRooms()
        {
            var rooms = await _roomRepository.GetRooms();
            return rooms.Select(RoomReadDto.FromEntity).ToList();
        }

        [HttpGet("availability")]
        public async Task<IList<RoomReadDto>> GetRoomsAvailableOnDate(DateTime date)
        {
            var rooms = await _roomRepository.GetAvailableRoomsForDate(date);
            return rooms.Select(RoomReadDto.FromEntity).ToList();
        }
        
        [HttpGet("reservations")]
        [Authorize]
        public async Task<IList<RoomWithReservationsDto>> GetReservationsForPeriod(DateTime startPeriod, DateTime endPeriod)
        {
            var rooms = await _roomRepository.GetAvailableRoomsForPeriod(startPeriod, endPeriod);
            return rooms.Select(RoomWithReservationsDto.FromEntity).ToList();
        }
    }
}