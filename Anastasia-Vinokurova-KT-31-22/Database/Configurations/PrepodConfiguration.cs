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

            builder.Property(p => p.DegreeId)
            .HasColumnName("c_degree_id")
            .HasColumnType(ColumnType.Int)
            .HasComment("Степень(учёная) преподавателя");

            builder.ToTable(TableName).HasOne(p => p.Degree)
                .WithMany().HasForeignKey(p => p.DegreeId)
                .HasConstraintName("fk_degree_id")
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable(TableName)
                .HasIndex(p => p.DegreeId, $"idx_{TableName}_fk_degree_id");

            builder.Property(p => p.PositionId)
                .HasColumnName("c_position_id")
                .HasColumnType(ColumnType.Int)
                .HasComment("Должность преподавателя");

            builder.ToTable(TableName).HasOne(p => p.Position)
                .WithMany().HasForeignKey(p => p.PositionId)
                .HasConstraintName("fk_position_id")
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable(TableName)
                .HasIndex(p => p.PositionId, $"idx_{TableName}_fk_position_id");

            builder.Property(p => p.CafedraId)
                .IsRequired()
                .HasColumnName("c_cafedra_id")
                .HasColumnType(ColumnType.Int)
                .HasComment("Айди кафедры");

            builder.ToTable(TableName).HasOne(p => p.Cafedra)
                .WithMany().HasForeignKey(p => p.CafedraId)
                .HasConstraintName("fk_f_group_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName)
                .HasIndex(p => p.CafedraId, $"idx_{TableName}_fk_f_group_id");

            builder.Navigation(p => p.Degree).AutoInclude();
            builder.Navigation(p => p.Position).AutoInclude();
            builder.Navigation(p => p.Cafedra).AutoInclude();
        }
    }
}
