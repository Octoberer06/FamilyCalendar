using Calendar.Core;
using Calendar.DataAccess.Entities;

namespace Calendar.DataAccess.Repository
{
    public interface ICalendarEventsReposytory
    {
        Task<Guid> CreateEvet(VisitEntity CalendarEntity);
        Task<Guid> DeleteEvent(Guid id);
        Task<List<CalendarEvent>> GetEvents();
        Task<Guid> UpdateEvent(Guid id, string titel, string description, decimal price, DateTime startDate, DateTime endDate);
    }
}