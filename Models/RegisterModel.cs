using System.ComponentModel.DataAnnotations;

namespace FamilyCalendar.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Данное поле обязательно для заполнения")]
        public string FirstName { get; set; }

        [Required (ErrorMessage = "Данное поле обязательно для заполнения")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Данное поле обязательно для заполнения")]
        public string Role { get; set; }

        [Required(ErrorMessage = "Данное поле обязательно для заполнения")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Данное поле обязательно для заполнения")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
