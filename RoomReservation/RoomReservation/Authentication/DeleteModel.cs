using System.ComponentModel.DataAnnotations;

namespace RoomReservation.Authentication
{
    public class DeleteModel
    {
        [Required(ErrorMessage = "User Name is required")]  
        public string Username { get; set; }  
    }
}