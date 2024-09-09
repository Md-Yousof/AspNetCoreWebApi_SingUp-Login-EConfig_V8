using System.ComponentModel.DataAnnotations;

namespace MemberShip_Lenant_CleanArchitecture_Api.Models.Authentication.SingUp
{
    public class RegisterUser
    {
        [Required(ErrorMessage = "User Name is required")]
        public string? UserName { get; set; }
        [EmailAddress]
        [Required(ErrorMessage ="Email is required")]
        public string? Email { get; set; }
        [Required(ErrorMessage ="Password is required")]
        public string? Password { get; set; }

    }
}
