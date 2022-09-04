using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Dtos
{
    public class AddUserDto
    {
        [Required]
        [StringLength(int.MaxValue,MinimumLength =3,ErrorMessage ="İsim en az 3 karakter olmalıdır.")]
        public string Name { get; set; }
        [Required]
        [StringLength(int.MaxValue, MinimumLength = 3, ErrorMessage = "Soyad en az 3 karakter olmalıdır.")]
        public string SurName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
