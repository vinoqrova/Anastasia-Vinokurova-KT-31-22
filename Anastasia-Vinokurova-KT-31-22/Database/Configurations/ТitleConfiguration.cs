using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Anastasia_Vinokurova_KT_31_22.Models;
using Anastasia_Vinokurova_KT_31_22.Databases.Helpers;

namespace Anastasia_Vinokurova_KT_31_22.Database.Configurations
{
    public class ТitleConfiguration : IEntityTypeConfiguration<Тitle>
    {
        private const string TableName = "Тitle";

        public void Configure(EntityTypeBuilder<Тitle> builder)
        {
            builder.HasKey(p => p.ТitleId)
                .HasName($"pk_{TableName}_Тitle_id");

            builder.Property(p => p.ТitleId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Тitle_id")
                .HasComment("Идентификатор должности");

            builder.Property(p => p.ТitleName)
                .IsRequired()
                .HasColumnName("c_Тitle_name")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Название должности (например, доцент)");
        }
    }
}
