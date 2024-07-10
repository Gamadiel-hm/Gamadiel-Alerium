using Alerium.Application.Interface;
using Alerium.Domain.Abstract;
using Alerium.Domain.Entities.Producto;
using Alerium.Domain.Entities.Proveedor;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection;

namespace Alerium.Infrastructure.Context
{
    public class ApplicationDbContext(DbContextOptions options) : DbContext(options), IApplicationDbContext
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Ignore<Entity>();
        }

        public DbSet<ProveedoresEntity> Proveedores { get; set; }
        public DbSet<ProductosEntity> Productos { get; set; }

        public async Task<bool> SaveAsync()
        {
            return await SaveChangesAsync() > 0;
        }

        public async Task<int> DeleteProveedorIfProductoNotExistAsync(Guid proveedorId)
        {
            var proveedorParam = new SqlParameter("@proveedorId", SqlDbType.UniqueIdentifier) { Value = proveedorId };
            var deleteProveedorParam = new SqlParameter("@deleteProveedor", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };

            await Database.ExecuteSqlRawAsync("EXEC sp_DeleteProveedorIfProductoNotExist @proveedorId, @deleteProveedor OUTPUT",
                proveedorParam, deleteProveedorParam);

            return (int)deleteProveedorParam.Value;
        }
    }
}
