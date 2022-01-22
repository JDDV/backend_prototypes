using System.ComponentModel.DataAnnotations;

namespace RoomReservation.Authentication
{
    public class UpdateModel
    {
        [Required(ErrorMessage = "User Name is required")]  
        public string Username { get; set; }  
  
        [EmailAddress]  
        [Required(ErrorMessage = "Email is required")]  
        public string OldEmail { get; set; }  
  
        [Required(ErrorMessage = "Email is required")]  
        public string NewEmail { get; set; }  
    }
}