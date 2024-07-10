using Alerium.Application.utilities;

namespace Alerium.Application.Fetures.Producto.Querys.GetProductoAll
{
    public interface IGetProductoAllQuery
    {
        Task<RepositoryResponse> Execute(Guid id);
    }
}
