using System;
using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public record UserForAuthenticationDTO
    {
        [Required(ErrorMessage = "User name is required")]
        public string? UserName { get; init; }
        [Required(ErrorMessage = "Password name is required")]
        public string? Password { get; init; }
    }    
}

