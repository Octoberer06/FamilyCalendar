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
    //        // ������ ��� ��������� GET-�������
    //    }

    //    public IActionResult OnPost()
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            // �������� ������ ������� ������������ � ������� �� ����� �����������
    //            //var newUser = new User
    //            //{
    //            //    FirstName = Request.Form["firstName"],
    //            //    LastName = Request.Form["lastName"],
    //            //    Role = Request.Form["role"],
    //            //    Email = Request.Form["email"],
    //            //    Password = Request.Form["password"]
    //            //};

    //            // ���������� ������ ������������ � ���� ������
    //            //_context.Users.Add(newUser);
    //            //_context.SaveChanges();

    //            // ��������������� �� ������ �������� ����� �������� �����������
    //            return RedirectToPage("/Calendar/Index");
    //        }

    //        // ���� ������ ���������������, �������� �� �������� �����������
    //        return Page();
    //    }
    //}
}