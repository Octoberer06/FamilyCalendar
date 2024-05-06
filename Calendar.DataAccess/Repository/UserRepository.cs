using AutoMapper;
using Calendar.DataAccess;
using Calendar.DataAccess.Entities;
using FamilyCalendar.Calendar.Application.Interfaces;
using FamilyCalendar.Calendar.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace FamilyCalendar.Calendar.DataAccess.Repository
{
    public class UserRepository : IUserRepository
    {
        //private readonly UserDbContext _context;
        private readonly CalendarDbContext _context;
        private readonly IMapper _mapper;
        public UserRepository(CalendarDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task Add(User user)
        {
            var userEntit = new UserEntity()
            {
                UserID = user.UserID,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Role = user.Role,
                PasswordHash = user.PasswordHash,
                //PasswordSalt = user.PasswordSalt
                //FullName = user.FullName
            };
            await _context.Users.AddAsync(userEntit);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetByEmail(string email)
        {
            var userEntity = await _context.Users
                    .AsNoTracking()
                    .FirstOrDefaultAsync(u => u.Email == email) ?? throw new Exception();
            //return _mapper.Map<User>(email);
            return _mapper.Map<User>(userEntity);
            //try
            //{
            //    var userEntity = await _context.Users
            //        .AsNoTracking()
            //        .FirstOrDefaultAsync(u => u.Email == email) ?? throw new Exception();
            //    //return _mapper.Map<User>(email);
            //    return _mapper.Map<User>(userEntity);
            //}
            //catch (Exception ex)
            //{
            //    return RedirectToPage("calendar/login", new { errorMessage = ex.Message });
            //}
        }

        public async Task<User> GetById(Guid userId)
        {
            var userEntity = await _context.Users.FindAsync(userId); // Ищем сущность пользователя в базе данных

            if (userEntity != null)
            {
                var user = _mapper.Map<User>(userEntity); // Выполняем преобразование сущности пользователя в модель пользователя
                return user;
            }
            return null; // Если пользователь с таким идентификатором не найден
        }
    }
}
