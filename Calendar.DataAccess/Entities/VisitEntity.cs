using System.ComponentModel.DataAnnotations;

namespace Calendar.DataAccess.Entities
{
    public class VisitEntity
    {
        [Key] // Была ошибка при первичной миграции (необходимо задавать [key] if your primary key name is not Id or ID.)
        public Guid VisitId { get; set; }
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public UserEntity? User { get; set; }
    }
}
