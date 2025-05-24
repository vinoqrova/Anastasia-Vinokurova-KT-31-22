using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Anastasia_Vinokurova_KT_31_22.Databases.Helpers;
using Anastasia_Vinokurova_KT_31_22.Models;

namespace Anastasia_Vinokurova_KT_31_22.Database.Configurations
{
    public class PrepodConfiguration : IEntityTypeConfiguration<Prepod>
    {
        private const string TableName = "Prepod";

        public void Configure(EntityTypeBuilder<Prepod> builder)
        {
            builder.HasKey(p => p.PrepodId)
                .HasName($"pk_{TableName}_prepod_id");

            builder.Property(p => p.PrepodId)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.PrepodId)
                .HasColumnName("prepod_id")
                .HasComment("Идентификатор препода");

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasColumnName("c_prepod_firstname")
                .HasColumnType(ColumnType.String).HasMaxLength(50)
                .HasComment("Имя препода");

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasColumnName("c_prepod_lastname")
                .HasColumnType(ColumnType.String).HasMaxLength(50)
                .HasComment("Фамилия препода");

            builder.Property(p => p.MiddleName)
                .HasColumnName("c_prepod_midname")
                .HasColumnType(ColumnType.String).HasMaxLength(50)
                .HasComment("Отчество препода");

            builder.Property(p => p.Academic_degreeId)
            .HasColumnName("c_Academic_degree_id")
            .HasColumnType(ColumnType.Int)
            .HasComment("Степень(учёная) преподавателя");

            builder.ToTable(TableName).HasOne(p => p.Academic_degree)
                .WithMany().HasForeignKey(p => p.Academic_degreeId)
                .HasConstraintName("fk_Academic_degree_id")
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable(TableName)
                .HasIndex(p => p.Academic_degreeId, $"idx_{TableName}_fk_Academic_degree_id");

            builder.Property(p => p.ТitleId)
                .HasColumnName("c_Тitle_id")
                .HasColumnType(ColumnType.Int)
                .HasComment("Должность преподавателя");

            builder.ToTable(TableName).HasOne(p => p.Тitle)
                .WithMany().HasForeignKey(p => p.ТitleId)
                .HasConstraintName("fk_Тitle_id")
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable(TableName)
                .HasIndex(p => p.ТitleId, $"idx_{TableName}_fk_Тitle_id");

            builder.Property(p => p.facultyId)
                .IsRequired()
                .HasColumnName("c_faculty_id")
                .HasColumnType(ColumnType.Int)
                .HasComment("Айди кафедры");

            builder.ToTable(TableName).HasOne(p => p.faculty)
                .WithMany().HasForeignKey(p => p.facultyId)
                .HasConstraintName("fk_f_group_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName)
                .HasIndex(p => p.facultyId, $"idx_{TableName}_fk_f_group_id");

            builder.Navigation(p => p.Academic_degree).AutoInclude();
            builder.Navigation(p => p.Тitle).AutoInclude();
            builder.Navigation(p => p.faculty).AutoInclude();
        }
    }
}
