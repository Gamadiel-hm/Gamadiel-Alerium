using Alerium.Application.utilities;

namespace Alerium.Application.Fetures.Proveedor.Commands.DeleteProveedorStore
{
    public interface IDeleteProveedorStoreCommand
    {
        Task<RepositoryResponse> Execute(Guid idProveedor);
    }
}
