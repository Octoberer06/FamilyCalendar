using FamilyCalendar.Calendar.Core.Models;

namespace FamilyCalendar.Calendar.Application.Interfaces
{
    public interface IJwtProvider
    {
        string GenerateToken(User user);
    }
}