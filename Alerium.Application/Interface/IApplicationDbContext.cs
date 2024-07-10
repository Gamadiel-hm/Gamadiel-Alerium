using Alerium.Domain.Entities.Producto;
using Alerium.Domain.Entities.Proveedor;
using Microsoft.EntityFrameworkCore;

namespace Alerium.Application.Interface
{
    public interface IApplicationDbContext
    {
        DbSet<ProveedoresEntity> Proveedores { get; set; }
        DbSet<ProductosEntity> Productos { get; set; }

        Task<bool> SaveAsync();

        Task<int> DeleteProveedorIfProductoNotExistAsync(Guid proveedorId);
    }
}
