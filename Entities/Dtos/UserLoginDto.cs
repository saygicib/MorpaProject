using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Dtos
{
    public class UserLoginDto
    {
        [Required]
        [EmailAddress(ErrorMessage = "Email girmelisiniz.")]
        public string Email { get; set; }
        [Required]
        [StringLength(int.MaxValue, MinimumLength = 8, ErrorMessage = "Şifre en az 8 karakter olmalıdır.")]
        public string Password { get; set; }
    }
}
