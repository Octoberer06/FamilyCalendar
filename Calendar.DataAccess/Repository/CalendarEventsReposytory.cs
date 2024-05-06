using Calendar.Core;
using Calendar.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Calendar.DataAccess.Repository
{
    public class CalendarEventsReposytory : ICalendarEventsReposytory
    {
        private readonly CalendarDbContext _context;

        public CalendarEventsReposytory(CalendarDbContext context)
        {
            this._context = context;
        }

        public async Task<List<CalendarEvent>> GetEvents()
        {
            var calendarEntities = await _context.CalendarEvents
                .AsNoTracking()
                .ToListAsync();

            var calendarEvents = calendarEntities
                .Select(c => CalendarEvent.Create(c.VisitId, c.Title, c.Description, c.Price, c.StartDate.Value, c.EndDate.Value).CalendarEvent)
                .ToList();

            return calendarEvents;
        }

        public async Task<Guid> CreateEvet(VisitEntity CalendarEntity)
        {
            var eventEntity = new VisitEntity
            {
                VisitId = CalendarEntity.VisitId,
                Title = CalendarEntity.Title,
                Description = CalendarEntity.Description,
                Price = CalendarEntity.Price,
                StartDate = CalendarEntity.StartDate,
                EndDate = CalendarEntity.EndDate,
            };

            await _context.CalendarEvents.AddAsync(eventEntity);
            await _context.SaveChangesAsync();

            return eventEntity.VisitId;
        }

        public async Task<Guid> UpdateEvent(Guid id, string titel, string description, decimal price, DateTime startDate, DateTime endDate)
        {
            await _context.CalendarEvents
                .Where(ev => ev.VisitId == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(ev => ev.Title, ev => titel)
                    .SetProperty(ev => ev.Description, ev => description)
                    .SetProperty(ev => ev.Price, ev => price)
                    .SetProperty(ev => ev.StartDate, ev => startDate)
                    .SetProperty(ev => ev.EndDate, ev => endDate));
            return id;
        }

        public async Task<Guid> DeleteEvent(Guid id)
        {
            await _context.CalendarEvents
                .Where(ev => ev.VisitId == id)
                .ExecuteDeleteAsync();
            return id;
        }
    }
}
