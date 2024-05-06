using Calendar.Core;
using Calendar.DataAccess.Entities;

namespace FamilyCalendar.Calendar.Core.Abstractions
{
    public interface ICalendarService
    {
        Task<Guid> CreateCalendarEvet(VisitEntity calendarEntity);
        Task<Guid> DeleteCalendarEvent(Guid id);
        Task<List<CalendarEvent>> GetAllEvents();
        Task<Guid> UpdateCalendarEvent(Guid id, string titel, string description, decimal price, DateTime startDate, DateTime endDate);
    }
}