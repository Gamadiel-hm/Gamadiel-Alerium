using Alerium.Application.Interface;
using Alerium.Application.utilities;
using Alerium.Domain.Entities.Proveedor;
using Microsoft.EntityFrameworkCore;

namespace Alerium.Application.Fetures.Proveedor.Commands.DeleteProveedor
{
    public class DeleteProveedorCommand(IApplicationDbContext context) : IDeleteProveedorCommand
    {
        private readonly IApplicationDbContext _context = context;

        public async Task<RepositoryResponse> Execute(Guid id)
        {
            ProveedoresEntity entity = await _context.Proveedores.FirstOrDefaultAsync(p => p.Id == id);

            if (entity is null)
                RepositoryResponse.Response(entity, ProveedorError.NotFound.Name);

            _context.Proveedores.Remove(entity);
            await _context.SaveAsync();

            return RepositoryResponse.Response(entity);
        }
    }
}
