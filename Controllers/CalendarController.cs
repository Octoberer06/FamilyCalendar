using Calendar.DataAccess.Entities;
using FamilyCalendar.Calendar.Application.Services;
using FamilyCalendar.Calendar.Core.Abstractions;
using FamilyCalendar.Contracts;
using FamilyCalendar.Contracts.Users;
using FamilyCalendar.Models;
using FamilyCalendar.Views.Calendar;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using FamilyCalendar.Infrastructure;


namespace FamilyCalendar.Controllers
{
    [ApiController]
    [Route("calendar")]
    public class CalendarController : Controller
    {
        private readonly ICalendarService _calendarServise;
        private readonly UsersService _usersService;

        private readonly JwtProvider _jwtProvider;// Дописано
        //private readonly IHttpContextAccessor _httpContextAccessor;

        public CalendarController(ICalendarService calendarService, UsersService usersService, JwtProvider jwtProvider)//, IHttpContextAccessor httpContextAccessor)
        {
            _calendarServise = calendarService;
            _usersService = usersService;
            _jwtProvider = jwtProvider;
            //_httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public async Task<ActionResult<List<CalendarResponse>>> GetEvents()
        {
            var allEvents = await _calendarServise.GetAllEvents();
            var responce = allEvents.Select(ev => new CalendarResponse(ev.CalendarId, ev.Title, ev.Description, ev.Price, (DateTime)ev.StartDate, (DateTime)ev.EndDate));
            return Ok(responce);
        }

        [HttpGet]
        [Route("index")]
        public IActionResult Index()
        {
            return View("./Views/Home/Index.cshtml");
        }

        [HttpGet]
        [Route("privacy")]
        public IActionResult Privacy()
        {
            return View("./Views/Home/Privacy.cshtml");
        }

        //[HttpGet]
        //[Route("Test")]
        //public IActionResult Test()
        //{
        //    Response.Redirect("./Views/Calendar/Login.cshtml");
        //    return View("./Views/Calendar/Login.cshtml");
        //}

        [HttpGet]
        [Route("error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        [Route("register")]
        public IActionResult Register()
        {
            return View("./Views/Calendar/Register.cshtml");
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUsersRequest request)
        {
            await _usersService.Register(request.FirstName, request.LastName, request.Email, (UserRoleEnum)Enum.Parse(typeof(UserRoleEnum), request.Role.ToString()), request.Password, request.FullName);
            return Ok();
        }

        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {
            return View("./Views/Calendar/Login.cshtml");
        }

        // Работает не со SWAGERа
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromForm] LoginModel request)
        {
            var token = await _usersService.Login(request.Email, request.Password);
            HttpContext.Response.Cookies.Append("justCookie", token);
            return RedirectToAction("userpage", "calendar", new { token = token });
        }

        // Работает со SWAGER
        //[HttpPost]
        //[Route("login")]
        //public async Task<IActionResult> Login([FromBody] LoginModel request)
        //{
        //    var token = await _usersService.Login(request.Email, request.Password);
        //    HttpContext.Response.Cookies.Append("justCookie", token);
        //    return Ok(token);
        //}


        //[HttpGet]
        //[Route("userpage")]
        //public IActionResult UserPage(string token)
        //{
        //    Console.WriteLine($"FullUserName = {_usersService.GetUserIdFromToken(token).Result}");
        //    return View("./Views/Calendar/UserPage.cshtml");
        //}

        [HttpGet]
        [Route("userpage")]
        public async Task<IActionResult> UserPage(string token)
        {
            var fullUserName = await _usersService.GetUserIdFromToken(token);

            var model = new UserPageModel
            {
                FullUserName = fullUserName
            };

            return View("./Views/Calendar/UserPage.cshtml", model);
        }

        [HttpPost]
        public IActionResult Logout()
        {
            // Получаем сессию
            //var session = _httpContextAccessor.HttpContext.Session;

            // Очищаем сессию
            //session.Clear();

            // Перенаправляем пользователя на страницу после выхода
            return RedirectToAction("Privacy", "Calendar");
        }

        //[HttpGet]
        //[Route("[usersdata]")]
        //public IActionResult GetUserData()
        //{
        //    // Получаем идентификатор текущего пользователя
        //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        //    // Получаем имя пользователя
        //    var username = User.Identity.Name;

        //    // Возвращаем данные о текущем пользователе
        //    return Ok(new { UserId = userId, Username = username });
        //}
    }
}
