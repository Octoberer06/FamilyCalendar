using System.ComponentModel.DataAnnotations;

namespace Calendar.DataAccess.Entities
{
    public class UserEntity
    {
        [Key] // Была ошибка при первичной миграции (необходимо задавать [key] if your primary key name is not Id or ID.)
        public Guid UserID { get; set; }
        [MaxLength(100)]
        public required string FirstName { get; set; }
        [MaxLength(100)]
        public string? LastName { get; set; }
        [MaxLength(200)]
        public required string Email { get; set; }
        public required UserRoleEnum Role { get; set; }

        [MaxLength(100)]
        public required string PasswordHash { get; set; }
        //[MaxLength(100)]
        //public required string PasswordSalt { get; set; }

        public string FullName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(LastName))
                {
                    return FirstName;
                }
                return $"{FirstName} {LastName}";
            }
        }

        public IEnumerable<VisitEntity>? Visits { get; set; } // один юзер множество ивенотов !!!
    }
}
