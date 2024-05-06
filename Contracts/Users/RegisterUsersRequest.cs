using Calendar.DataAccess.Entities;
using System.ComponentModel.DataAnnotations;

namespace FamilyCalendar.Contracts.Users
{
    public record RegisterUsersRequest(
        [Required] string FirstName,
        [Required] string LastName,
        [Required] UserRoleEnum Role,
        [Required] string Email,
        [Required] string Password,
        [Required] string FullName);

    // Для себя что бы не забыть. см. в LoginUsersRequest
}