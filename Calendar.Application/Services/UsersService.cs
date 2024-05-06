using Calendar.DataAccess.Entities;
using FamilyCalendar.Calendar.Application.Interfaces;
using FamilyCalendar.Calendar.Core.Models;
using FamilyCalendar.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace FamilyCalendar.Calendar.Application.Services
{
    public class UsersService
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserRepository _userRepository;
        private readonly IJwtProvider _jwtProvider;
        //private readonly UsersService _usersService;
        private readonly JwtOptions _jwtOptions;

        public UsersService(IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtProvider jwtProvider,  JwtOptions jwtOptions)
        {
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
            _jwtProvider = jwtProvider;
            //_usersService = usersService;
            _jwtOptions = jwtOptions;
        }
        public async Task Register(string firstName, string lastName, string email, UserRoleEnum role, string password, string fullName)
        {
            var hashedPassword = _passwordHasher.Generate(password);

            var user = User.CreateUser(Guid.NewGuid(), firstName, lastName, email, role, hashedPassword, fullName);
            await _userRepository.Add(user);
        }
        public async Task<string> Login(string email, string password)
        {
            var user = await _userRepository.GetByEmail(email);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            var result = _passwordHasher.Verify(password, user.PasswordHash);
            if (result == false)
            {
                throw new Exception("Fail to login");
            }

            var token = _jwtProvider.GenerateToken(user);

            return token;
        }

        public async Task<string> GetUserNameById(Guid userId)
        {
            var user = await _userRepository.GetById(userId);
            if (user != null)
            {
                return user.FullName;
            }
            return null; // Если пользователь с таким идентификатором не найден
        }

        //
        public async Task<string> GetUserIdFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)),
                ValidateIssuer = false,
                ValidateAudience = false
            };

            try
            {
                // Декодируем и валидируем токен
                var claimsPrincipal = tokenHandler.ValidateToken(token, validationParameters, out var validatedToken);

                if (validatedToken is JwtSecurityToken jwtSecurityToken)
                {
                    // Извлекаем идентификатор пользователя из токена
                    var userId = jwtSecurityToken.Claims.FirstOrDefault(c => c.Type == "userId")?.Value;

                    if (!string.IsNullOrEmpty(userId))
                    {
                        // Преобразуем идентификатор из Guid в int
                        if (Guid.TryParse(userId, out Guid userIdInt))
                        {

                            Console.WriteLine($"userId = {userId}, userGuid = {userIdInt}");

                            // Здесь вы можете использовать идентификатор пользователя для получения User из вашей базы данных или другого источника
                            var user = await GetUserNameById(userIdInt);

                            return user;
                            //if (user != null)
                            //{
                            //    var userName = user.FullName; // Используйте свойство FullName из объекта User
                            //    return userName;
                            //}
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Обработка ошибки валидации токена
                // Можно например, записать ошибку в лог или выбросить исключение
            }

            return null; // Если токен невалидный или имя пользователя не найдено
        }
    }
}
