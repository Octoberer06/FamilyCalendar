using FamilyCalendar.Calendar.Core.Models;

namespace FamilyCalendar.Calendar.Application.Interfaces
{
    public interface IUserRepository
    {
        Task Add(User user);
        Task<User> GetByEmail(string email);
        Task<User> GetById(Guid userId);
    }
}