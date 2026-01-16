using System.ComponentModel.DataAnnotations;

namespace iForce.Backend.Models
{
    public class AuthRequest
    {
        //TODO should also sanitize input

        [Required, MaxLength(200)]
        public required string Username { get; set; }

        [Required, MaxLength(200)]
        public required string Password { get; set; }
    }
}
