using Microsoft.EntityFrameworkCore;
using Anastasia_Vinokurova_KT_31_22.Database.Configurations;
using Anastasia_Vinokurova_KT_31_22.Models;

namespace Anastasia_Vinokurova_KT_31_22.Databases
{
    public class PrepodDbContext : DbContext
    {
        DbSet<Prepod> Prepods { get; set; }

        DbSet<Cafedra> Cafedri { get; set; }
        Enum Subjects { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PrepodConfiguration());
            modelBuilder.ApplyConfiguration(new CafedraConfiguration());
            modelBuilder.ApplyConfiguration(new DegreeConfiguration());
            modelBuilder.ApplyConfiguration(new PositionConfiguration());
            modelBuilder.ApplyConfiguration(new ScheduleConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectConfiguration());

            //modelBuilder.Entity<Subject>().HasQueryFilter(s => !s.IsDeleted);
        }

        public PrepodDbContext(DbContextOptions<PrepodDbContext> options) : base(options) { }
    }
}
