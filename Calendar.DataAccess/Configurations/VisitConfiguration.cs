using Calendar.DataAccess.Entities;
using Calendar.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Calendar.DataAccess.Configurations
{
    // Данная конфигурация выполнена в таком виде - для потенциального расширения данного проекта. 
    public class VisitConfiguration : IEntityTypeConfiguration<VisitEntity>
    {
        public void Configure(EntityTypeBuilder<VisitEntity> builder)
        {
            builder.HasKey(v => v.VisitId); // Тут мы явно указываем что ключ нашей таблицы будет VisitId

            builder.
                HasOne(v => v.User)
                .WithMany(u => u.Visits);

            builder.Property(v => v.Title)
                .HasMaxLength(CalendarEvent.MAX_TITLE_LENGHT)
                .IsRequired();

            builder.Property(v => v.Description)
                .IsRequired();

            builder.Property(v => v.Price)
                .IsRequired();

            builder.Property(v => v.StartDate)
                .IsRequired();

            builder.Property(v => v.EndDate)
                .IsRequired();
        }
    }
}
