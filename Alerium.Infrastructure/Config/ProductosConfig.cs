using Alerium.Domain.Entities.Producto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alerium.Infrastructure.Config
{
    public class ProductoConfig : IEntityTypeConfiguration<ProductosEntity>
    {
        public void Configure(EntityTypeBuilder<ProductosEntity> builder)
        {
            builder.Property(prop => prop.Codigo)
                .IsRequired().HasMaxLength(20);
            builder.Property(prop => prop.Descripccion)
                .HasMaxLength(150);
            builder.Property(prop => prop.Unidad)
                .HasMaxLength(3);
            builder.Property(prop => prop.Costo)
                .HasPrecision(6,2);

            builder.HasIndex(prop => prop.Codigo)
                .IsUnique();
        }
    }
}
