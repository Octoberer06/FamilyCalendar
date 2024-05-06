using System.Globalization;

namespace Calendar.Core
{
    public class CalendarEvent
    {
        public const int MAX_TITLE_LENGHT = 250;
        private CalendarEvent(Guid id, string titel, string description, decimal price, DateTime startdate, DateTime enddate)
        {
            CalendarId = id;
            Title = titel;
            Description = description;
            Price = price;
            StartDate = startdate;
            EndDate = enddate;
        }

        // Т.к. модель доменная мы не задаем set-ы, для того что бы извне нельзя было взаимодействовать с этой моделью кроме как разрешенными методами
        public Guid CalendarId { get; }
        public string Title { get; } = string.Empty;
        public string Description { get; } = string.Empty;
        public decimal Price { get; }
        public DateTime? StartDate { get; }
        public DateTime? EndDate { get; }

        public static (CalendarEvent CalendarEvent, string Error) Create(Guid id, string titel, string description, decimal price, DateTime startdate, DateTime enddate)
        {
            var error = string.Empty;
            if (string.IsNullOrEmpty(titel) || titel.Length > MAX_TITLE_LENGHT)
            {
                error = "Title can`t be empty or loner then 250 symbols";
            }

            if (startdate < enddate)
            {
                error = "Неверный формат даты: дата начала должна быть ранее даты окончания приёма";
            }

            if (!DateTime.TryParseExact(startdate.ToString(), "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
            {
                error = "Неверный формат даты: дата должна быть в формате dd.MM.yyyy";
            }

            var calendarEvent = new CalendarEvent(id, titel, description, price, startdate, enddate);

            return (calendarEvent, error);
        }
    }
}
