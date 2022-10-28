﻿using System.ComponentModel.DataAnnotations;

namespace Vehicles.DTOs
{
    public class UserCredential
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }

    }
}
