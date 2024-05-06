using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FamilyCalendar.Views.Calendar
{
    public class UserPageModel : PageModel
    {
        //����

        public string Message { get; set; }
        public string FullUserName { get; set; }
        public void OnGet()
        {
            Message = "������� ������";
            FullUserName = "��� ������������";
        }
        public void OnPost(string name, int age)
        {
            Message = $"���: {name}  �������: {age}";
        }
    }
}
