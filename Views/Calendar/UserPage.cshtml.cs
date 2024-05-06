using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FamilyCalendar.Views.Calendar
{
    public class UserPageModel : PageModel
    {
        //Тест

        public string Message { get; set; }
        public string FullUserName { get; set; }
        public void OnGet()
        {
            Message = "Введите данные";
            FullUserName = "Имя пользователя";
        }
        public void OnPost(string name, int age)
        {
            Message = $"Имя: {name}  Возраст: {age}";
        }
    }
}
