using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FamilyCalendar.Models;
using FamilyCalendar.Calendar.Core.Models;
using Calendar.DataAccess;

namespace FamilyCalendar.Views.Calendar
{
    //public class RegisterModel : PageModel
    //{
    //    private readonly CalendarDbContext _context;

    //    public RegisterModel(CalendarDbContext context)
    //    {
    //        _context = context;
    //    }

    //    public void OnGet()
    //    {
    //        // Ћогика дл€ обработки GET-запроса
    //    }

    //    public IActionResult OnPost()
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            // —оздание нового объекта пользовател€ с данными из формы регистрации
    //            //var newUser = new User
    //            //{
    //            //    FirstName = Request.Form["firstName"],
    //            //    LastName = Request.Form["lastName"],
    //            //    Role = Request.Form["role"],
    //            //    Email = Request.Form["email"],
    //            //    Password = Request.Form["password"]
    //            //};

    //            // —охранение нового пользовател€ в базе данных
    //            //_context.Users.Add(newUser);
    //            //_context.SaveChanges();

    //            // ѕеренаправление на другую страницу после успешной регистрации
    //            return RedirectToPage("/Calendar/Index");
    //        }

    //        // ≈сли модель недействительна, остаемс€ на странице регистрации
    //        return Page();
    //    }
    //}
}