using Alerium.Application.utilities;

namespace Alerium.Application.Fetures.Producto.Querys.GetProductoProveedorId
{
    public interface IGetProductoProveedorIdQuery
    {
        Task<RepositoryResponse> Execute(Guid idProveedor, Guid idProducto);
    }
}
