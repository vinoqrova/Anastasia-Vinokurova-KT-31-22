using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Anastasia_Vinokurova_KT_31_22.Models;
using Anastasia_Vinokurova_KT_31_22.Databases.Helpers;

namespace Anastasia_Vinokurova_KT_31_22.Database.Configurations
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        private const string TableName = "Position";

        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.HasKey(p => p.PositionId)
                .HasName($"pk_{TableName}_position_id");

            builder.Property(p => p.PositionId)
                .ValueGeneratedOnAdd()
                .HasColumnName("position_id")
                .HasComment("Идентификатор должности");

            builder.Property(p => p.PositionName)
                .IsRequired()
                .HasColumnName("c_position_name")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Название должности (например, доцент)");
        }
    }
}
