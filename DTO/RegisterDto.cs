﻿using System.ComponentModel.DataAnnotations;

namespace LoginMicroservice.DTO
{
    public class RegisterDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
