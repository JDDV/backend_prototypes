using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RoomReservation.Authentication;
using RoomReservation.Data.ReservationRepository;
using RoomReservation.Dtos.ReservationDto;

namespace RoomReservation.Controllers
{
    [ApiController]
    [Route("api/reservation")]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly UserManager<ApplicationUser> _userManager;


        public ReservationsController(IReservationRepository reservationRepository, UserManager<ApplicationUser> userManager)
        {
            _reservationRepository = reservationRepository;
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IList<ReservationReadDto>>> GetReservations()
        {
            var reservations = await _reservationRepository.GetReservations();
            return reservations.Select(ReservationReadDto.FromEntity).ToList();
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ReservationReadDto>> AddReservation(ReservationCreateDto reservationModel)
        {
            var reservation =
                reservationModel.ToEntity(await _userManager.FindByNameAsync(User.FindFirstValue(ClaimTypes.Name)));

            try
            {
                reservation = await _reservationRepository.AddReservation(reservation);
            }
            catch (ArgumentException e)
            {
                return BadRequest(new {Status = "Error", e.Message});
            }
            return ReservationReadDto.FromEntity(reservation);
        }
        
        [HttpPut("{reservationId:int}")]
        [Authorize]
        public async Task<ActionResult<ReservationReadDto>> UpdateReservation(int reservationId, ReservationUpdateDto reservationModel)
        {
            var reservation =
                reservationModel.ToEntity(reservationId);

            try
            {
                reservation = await _reservationRepository.UpdateReservation(reservation, User.FindFirstValue(ClaimTypes.Name));
            }
            catch (ArgumentException e)
            {
                return BadRequest(new {Status = "Error", e.Message});
            }
            return ReservationReadDto.FromEntity(reservation);
        }

        [HttpDelete("{reservationId:int}")]
        [Authorize]
        public async Task<IActionResult> DeleteReservation(int reservationId)
        {
            try
            {
                await _reservationRepository.DeleteReservation(reservationId, User.FindFirstValue(ClaimTypes.Name));
            }
            catch (ArgumentException e)
            {
                return BadRequest(new {Status = "Error", e.Message});
            }

            return Accepted();
        }
    }
}