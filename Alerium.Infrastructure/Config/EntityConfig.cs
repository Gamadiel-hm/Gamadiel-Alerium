using Alerium.Domain.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alerium.Infrastructure.Config
{
    public class EntityConfig : IEntityTypeConfiguration<Entity>
    {
        public void Configure(EntityTypeBuilder<Entity> builder)
        {
            builder.HasKey(key => key.Id);
            builder.Property(prop => prop.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
