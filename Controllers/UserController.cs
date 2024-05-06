//using FamilyCalendar.Calendar.Application.Interfaces;
//using FamilyCalendar.Calendar.Application.Services;
//using FamilyCalendar.Calendar.Core.Models;
//using FamilyCalendar.Contracts.Users;
//using Microsoft.AspNetCore.Mvc;


//namespace FamilyCalendar.Controllers
//{
//    namespace FamilyCalendar.Controllers
//    {
//        [ApiController]
//        [Route("users")]
//        public class UserController : Controller
//        {
//            private readonly IUserRepository _userRepository;
//            private readonly IPasswordHasher _passwordHasher;
//            private readonly IJwtProvider _jwtProvider;
//            private readonly UsersService _usersService;
//            public UserController(IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtProvider jwtProvider, UsersService usersService)
//            {
//                _userRepository = userRepository;
//                _passwordHasher = passwordHasher;
//                _jwtProvider = jwtProvider;
//                _usersService = usersService;
//            }

//            ////public static IEndpointRouteBuilder MapUsersEndpoints(this IEndpointRouteBuilder app)
//            ////{
//            ////    app.MapPost("regisrer", Register);
//            ////    app.MapPost("login", Login);

//            ////    return app;
//            ////}

//            //private static async Task<IResult> Register(RegisterUsersRequest request, UsersService usersService)

//            [HttpGet("calendar/[usersdata]")]
//            [Route("register")]
//            private static async Task<IResult> Register(User user, UsersService usersService)
//            {
//                await usersService.Register(user.FirstName, user.LastName, user.Email, user.Role, user.Password, user.FullName);

//                return Results.Ok();
//            }
//            //public async Task Register(string firstName, string lastName, string email, Enum role, string password, string fullName)
//            //{
//            //    _userRepository.GetHashCode();
//            //}

//            [HttpGet("calendar/[usersdata]")]
//            [Route("login")]
//            private static async Task<IResult> Login(LoginUsersRequest loginUsersRequest, UsersService usersService)
//            {
//                var token = await usersService.Login(loginUsersRequest.Email, loginUsersRequest.Password);

//                return Results.Ok(token);
//            }
//            //public async Task<string> Login(string email, string password)
//            //{
//            //    _userRepository.GetByEmail(email);
//            //    var user = await _userRepository.GetByEmail(email);
//            //    var result = _passwordHasher.Verify(password, user.PasswordHash);
//            //    if (result == false)
//            //    {
//            //        throw new Exception("Fail to login");
//            //    }

//            //    var token = _jwtProvider.GenerateToken(user);

//            //    return token;
//            //}
//        }
//    }
//}
