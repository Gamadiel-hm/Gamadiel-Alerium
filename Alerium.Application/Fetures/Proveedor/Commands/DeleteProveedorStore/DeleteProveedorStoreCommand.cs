using Alerium.Application.Interface;
using Alerium.Application.utilities;
using Alerium.Domain.Entities.Proveedor;

namespace Alerium.Application.Fetures.Proveedor.Commands.DeleteProveedorStore
{
    public class DeleteProveedorStoreCommand(IApplicationDbContext context) : IDeleteProveedorStoreCommand
    {
        private readonly IApplicationDbContext _context = context;

        public async Task<RepositoryResponse> Execute(Guid idProveedor)
        {
            var result = await _context.DeleteProveedorIfProductoNotExistAsync(idProveedor);
            if (result == 0)
                return RepositoryResponse.Response(new { }, ProveedorError.NotDelete.Name);
            return RepositoryResponse.Response(new { idProveedor });
        }
    }
}
