using Alerium.Domain.Entities.Proveedor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alerium.Infrastructure.Config
{
    public class ProveedoresConfig : IEntityTypeConfiguration<ProveedoresEntity>
    {
        public void Configure(EntityTypeBuilder<ProveedoresEntity> builder)
        {
            builder.Property(prop => prop.Codigo)
                .IsRequired().HasMaxLength(20);
            builder.HasIndex(prop => prop.Codigo)
                .IsUnique();
            builder.Property(prop => prop.RazonSocial)
                .IsRequired().HasMaxLength(150);
            builder.Property(prop => prop.RFC)
                .IsRequired().HasMaxLength(13);


            builder.HasMany(hm => hm.Productos)
                .WithOne(wo => wo.Proveedores)
                .HasForeignKey(fk => fk.ProveedoresId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
