using Calendar.DataAccess;
using Calendar.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FamilyCalendar.Views.Calendar
{
    //public class LoginModel : PageModel
    //{
    //    //private readonly CalendarDbContext _context;
    //    //public LoginModel(CalendarDbContext context)
    //    //{
    //    //    _context = context;
    //    //}

    //    //[BindProperty]
    //    //public List<UserEntity> usersEntity { get; set; }


    //    //public async Task OnGetAsync()
    //    //{
    //    //    // Логика для обработки GET-запроса
    //    //}

    //    ////public async Task<IActionResult> OnPostAsync(string email, string password)
    //    //public async Task<IActionResult> OnPostAsync(string email, string password)
    //    //{
    //    //    email = "Test_1@mail";
    //    //    password = "Test_1";
    //    //    // Логика для проверки введенных данных и аутентификации пользователя
    //    //    // Пример: проверка существования пользователя и верности пароля

    //    //    var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    //    //    if (user == null)
    //    //    {
    //    //        ModelState.AddModelError(string.Empty, "Пользователь не найден");
    //    //        return Page();
    //    //    }

    //    //    var passwordHasher = new PasswordHasher<string>();
    //    //    var passwordVerificationResult = passwordHasher.VerifyHashedPassword(null, user.PasswordHash, password);
    //    //    if (passwordVerificationResult != PasswordVerificationResult.Success)
    //    //    {
    //    //        ModelState.AddModelError(string.Empty, "Неверный пароль");
    //    //        return Page();
    //    //    }

    //    //    usersEntity = await _context.Users.ToListAsync(); // Получение списка пользователей

    //    //    // Если данные пользователя верны, перенаправляем на страницу UserPage.cshtml
    //    //    return RedirectToPage("/Calendar/UserPage");
    //    //}
    //}
}