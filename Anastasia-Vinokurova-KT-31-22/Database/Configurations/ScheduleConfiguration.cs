using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Anastasia_Vinokurova_KT_31_22.Models;
using Anastasia_Vinokurova_KT_31_22.Databases.Helpers;

namespace Anastasia_Vinokurova_KT_31_22.Database.Configurations
{
    public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        private const string TableName = "Schedule";

        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.HasKey(s => s.Id).HasName($"pk_{TableName}_Id");

            builder.Property(s => s.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("para_id")
                .HasComment("Идентификатор занятия");

            builder.Property(s => s.SubjectId)
                .HasColumnName("c_subject_id")
                .HasComment("Идентификатор предмета");

            builder.ToTable(TableName).HasOne(s => s.Subject)
                .WithMany()
                .HasForeignKey(s => s.SubjectId)
                .HasConstraintName($"fk_subject_id")
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable(TableName)
                .HasIndex(p => p.SubjectId, $"idx_{TableName}_fk_subject_id");

            builder.Property(s => s.PrepodId)
                .HasColumnName("c_prepod_id")
                .HasComment("Идентификатор преподавателя");

            builder.ToTable(TableName).HasOne(s => s.Prepod)
                .WithMany()
                .HasForeignKey(s => s.PrepodId)
                .HasConstraintName($"fk_prepod_id")
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable(TableName)
                .HasIndex(p => p.PrepodId, $"idx_{TableName}_fk_prepod_id");

            builder.Property(s => s.DayOfWeek)
                .IsRequired()
                .HasColumnName("c_schedule_day_of_week")
                .HasColumnType(ColumnType.Byte)
                .HasComment("День недели (1-6 = Пн-Сб)");

            builder.Property(s => s.OrderInDay)
                .IsRequired()
                .HasColumnName("c_schedule_order_in_day")
                .HasColumnType(ColumnType.Byte)
                .HasComment("Порядок занятия в дне (1-8)");

            builder.Navigation(p => p.Subject)
                .AutoInclude();
            builder.Navigation(p => p.Prepod)
                .AutoInclude();
        }
    }
}
