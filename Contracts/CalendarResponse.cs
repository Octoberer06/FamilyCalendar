namespace FamilyCalendar.Contracts
{
    // Это для фронт-енда
    public record CalendarResponse (
        Guid Id,
        string Titel, 
        string Description, 
        decimal Price, 
        DateTime StartDate, 
        DateTime EndDate)
    {
    }
}
