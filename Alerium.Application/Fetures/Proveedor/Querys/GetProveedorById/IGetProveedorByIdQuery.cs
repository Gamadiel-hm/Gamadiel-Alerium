using Alerium.Application.utilities;

namespace Alerium.Application.Fetures.Proveedor.Querys.GetProveedorById
{
    public interface IGetProveedorByIdQuery
    {
        Task<RepositoryResponse> Execute(Guid id);
    }
}
