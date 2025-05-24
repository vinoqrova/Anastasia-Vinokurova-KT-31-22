using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Anastasia_Vinokurova_KT_31_22.Databases.Helpers;
using Anastasia_Vinokurova_KT_31_22.Models;

namespace Anastasia_Vinokurova_KT_31_22.Database.Configurations
{
    public class Academic_Academic_degreeConfiguration : IEntityTypeConfiguration<Academic_Academic_degree>
    {
        private const string TableName = "Academic_degree";

        public void Configure(EntityTypeBuilder<Academic_Academic_degree> builder)
        {
            builder.HasKey(p => p.Academic_degreeId)
                .HasName($"pk_{TableName}_Academic_degree_id");

            builder.Property(p => p.Academic_degreeId)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Academic_degreeId)
                .HasColumnName("c_Academic_degree_id")
                .HasComment("Идентификатор степени");

            builder.Property(p => p.Academic_degreeName)
                .IsRequired()
                .HasColumnName("c_Academic_degree_name")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Название степени (например, кандидат наук)");

        }
    }
}
