// Ознакомление с написанием кода по другому с mappingom и т.п

//using Calendar.DataAccess.Entities;
//using FamilyCalendar.Calendar.Application.Services;
//using FamilyCalendar.Contracts.Users;
//using Microsoft.AspNetCore.Mvc;

//namespace FamilyCalendar.Endpoints
//{
//    public static class UsersEndpoints
//    {
//        public static IEndpointRouteBuilder MapUsersEndpoints(this IEndpointRouteBuilder app)
//        {
//            app.MapPost("regisrer", Register);
//            app.MapPost("login", Login);

//            return app;
//        }
//        //private static async Task<IResult> Register(RegisterUsersRequest request, UsersService usersService)
//        private static async Task<IResult> Register(
//            //User user,
//            [FromBody] RegisterUsersRequest request, // [FromBody] указывает, что параметр request будет получен из тела HTTP-запроса
//            UsersService usersService)
//        {
//            await usersService.Register(request.FirstName, request.LastName, request.Email, (UserRoleEnum)Enum.Parse(typeof(UserRoleEnum), request.Role.ToString()), request.Password, request.FullName);
//            // Можно это побороть (UserRoleEnum)Enum.Parse(typeof(UserRoleEnum), request.Role.ToString()) ???
//            //await usersService.Register(request.FirstName, request.LastName, request.Email, request.Role, request.Password, request.FullName);

//            return Results.Ok();
//        }

//        private static async Task<IResult> Login(
//            //LoginUsersRequest loginUsersRequest,
//            [FromBody] LoginUsersRequest request,
//            UsersService usersService,
//            HttpContext context)
//        {
//            var token = await usersService.Login(request.Email, request.Password);

//            context.Response.Cookies.Append("justCookie", token); // Лучше явно не называть что это JwtToket (для безопастности, если будет перехват cookies)

//            return Results.Ok(token);
//        }
//    }
//}
