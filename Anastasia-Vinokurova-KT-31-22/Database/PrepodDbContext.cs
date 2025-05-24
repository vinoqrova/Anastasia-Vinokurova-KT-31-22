using Microsoft.EntityFrameworkCore;
using Anastasia_Vinokurova_KT_31_22.Database.Configurations;
using Anastasia_Vinokurova_KT_31_22.Models;

namespace Anastasia_Vinokurova_KT_31_22.Databases
{
    public class PrepodDbContext : DbContext
    {
        DbSet<Prepod> Prepods { get; set; }

        DbSet<faculty> Cafedri { get; set; }
        Enum Subjects { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PrepodConfiguration());
            modelBuilder.ApplyConfiguration(new facultyConfiguration());
            modelBuilder.ApplyConfiguration(new Academic_Academic_degreeConfiguration());
            modelBuilder.ApplyConfiguration(new ТitleConfiguration());
            modelBuilder.ApplyConfiguration(new ScheduleConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectConfiguration());

            //modelBuilder.Entity<Subject>().HasQueryFilter(s => !s.IsDeleted);
        }

        public PrepodDbContext(DbContextOptions<PrepodDbContext> options) : base(options) { }
    }
}
