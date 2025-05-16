using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Anastasia_Vinokurova_KT_31_22.Models;
using Anastasia_Vinokurova_KT_31_22.Databases.Helpers;

namespace Anastasia_Vinokurova_KT_31_22.Database.Configurations
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        private const string TableName = "Subject";

        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.ToTable(TableName);
            builder.HasKey(s => s.SubjectId).HasName($"pk_{TableName}_subject_id");

            builder.Property(s => s.SubjectId)
                .ValueGeneratedOnAdd()
                .HasColumnName("subject_id")
                .HasComment("Идентификатор предмета");

            builder.Property(s => s.SubjectName)
                .IsRequired()
                .HasColumnName("c_subject_name")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Название предмета");

            builder.Property(s => s.IsDeleted)
                .HasColumnName("is_deleted")
                .HasDefaultValue(false)
                .HasComment("Помечено как удалённое (soft-delete)");

            // Optional: move your query‐filter here so it's all in one place
            builder.HasQueryFilter(s => !s.IsDeleted);
        }
    }
}
