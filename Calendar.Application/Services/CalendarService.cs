using Calendar.Core;
using Calendar.DataAccess.Entities;
using Calendar.DataAccess.Repository;
using FamilyCalendar.Calendar.Core.Abstractions;

namespace FamilyCalendar.Calendar.Application.Services
{
    public class CalendarService : ICalendarService // Ctrl+R Ctrl+I (Извлеч интерфес из класса, точнее на базе уже имеющегося класса создать интерфейс)
    {
        // В этом классе будет реализация сервиса что бы использовать различные репозитории
        // и с помощью репозиториев создавать данные здесь может быть валидация, кэширование, обращение к другим базам данных,
        // то есть вот такая вот прослойка которая использует наши во-первых доменные модели во-вторых используют наши репозитории
        // и контроллер будет как раз вызывать эти сервисы.

        private readonly ICalendarEventsReposytory _calendarEventsReposytory;

        public CalendarService(ICalendarEventsReposytory calendarEventsReposytory)
        {
            _calendarEventsReposytory = calendarEventsReposytory;
        }

        public async Task<List<CalendarEvent>> GetAllEvents()
        {
            return await _calendarEventsReposytory.GetEvents();
        }

        public async Task<Guid> CreateCalendarEvet(VisitEntity calendarEntity)
        {
            return await _calendarEventsReposytory.CreateEvet(calendarEntity);
        }

        public async Task<Guid> UpdateCalendarEvent(Guid id, string titel, string description, decimal price, DateTime startDate, DateTime endDate)
        {
            return await _calendarEventsReposytory.UpdateEvent(id, titel, description, price, startDate, endDate);
        }

        public async Task<Guid> DeleteCalendarEvent(Guid id)
        {
            return await _calendarEventsReposytory.DeleteEvent(id);
        }
    }
}
