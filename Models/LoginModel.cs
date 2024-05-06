using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FamilyCalendar.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Данное поле обязательно для заполнения")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Данное поле обязательно для заполнения")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
