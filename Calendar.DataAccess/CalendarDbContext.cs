using Calendar.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Calendar.DataAccess
{
    public class CalendarDbContext: DbContext
    {
        public CalendarDbContext(DbContextOptions<CalendarDbContext> options): base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}
        public DbSet<VisitEntity> CalendarEvents { get; set; }
        public DbSet<UserEntity> Users { get; set; }
    }
}
