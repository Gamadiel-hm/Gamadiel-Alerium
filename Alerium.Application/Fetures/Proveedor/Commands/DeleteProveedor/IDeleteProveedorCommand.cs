using Alerium.Application.utilities;

namespace Alerium.Application.Fetures.Proveedor.Commands.DeleteProveedor
{
    public interface IDeleteProveedorCommand
    {
        Task<RepositoryResponse> Execute(Guid id);
    }
}
