using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Anastasia_Vinokurova_KT_31_22.Databases.Helpers;
using Anastasia_Vinokurova_KT_31_22.Models;

namespace Anastasia_Vinokurova_KT_31_22.Database.Configurations
{
    public class facultyConfiguration : IEntityTypeConfiguration<faculty>
    {
        private const string TableName = "faculty";

        public void Configure(EntityTypeBuilder<faculty> builder)
        {
            builder.ToTable(TableName);
            builder.HasKey(c => c.facultyId).HasName($"pk_{TableName}_Id");

            builder.Property(c => c.facultyId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id")
                .HasComment("Идентификатор кафедры");

            builder.Property(c => c.facultyName)
                .IsRequired()
                .HasColumnName("c_faculty_name")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Название кафедры");

            // Foreign Key to Prepod (Admin)
            builder.Property(c => c.AdminId)
                .IsRequired()
                .HasColumnName("c_admin_id")
                .HasColumnType(ColumnType.Int)
                .HasComment("Идентификатор администратора(заведующего) кафедры");

/*            builder.ToTable(TableName).HasOne(c => c.Admin)
                .WithOne()
                .HasForeignKey<faculty>(c => c.AdminId)
                .HasConstraintName("fk_admin_id_prepod_id")
                .OnDelete(DeleteBehavior.Restrict);*/

            builder.ToTable(TableName).HasOne(s => s.Admin)
                .WithMany()
                .HasForeignKey(s => s.AdminId)
                .HasConstraintName($"fk_admin_id_prepod_id")
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable(TableName)
                .HasIndex(p => p.facultyId, $"idx_{TableName}_fk_admin_id_prepod_id");
        }
    }
}
