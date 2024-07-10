using Alerium.Application.utilities;

namespace Alerium.Application.Fetures.Proveedor.Commands.CreateProveedor
{
    public interface ICreateProveedorCommand
    {
        Task<RepositoryResponse> Execute(CreateProveedorModel proveedor);
    }
}
