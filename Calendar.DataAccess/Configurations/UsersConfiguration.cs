using Calendar.Core;
using Calendar.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace FamilyCalendar.Calendar.DataAccess.Configurations
{
    public class UsersConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(u => u.UserID); // Тут мы явно указываем что ключ нашей таблицы будет UserID

            builder.
                HasMany(u => u.Visits)
                .WithOne(v => v.User); //  Этот код - является дублирующим код в VisitConfiguration (builder.
                                                                                                        //HasOne(v => v.User)
                                                                                                        //.WithMany(u => u.Visits); - там можно не делать !

            builder.Property(u => u.FirstName);
            builder.Property(u => u.LastName);
            builder.Property(u => u.Email);
            builder.Property(u => u.Role);
            builder.Property(u => u.PasswordHash);
        }
    }
}

