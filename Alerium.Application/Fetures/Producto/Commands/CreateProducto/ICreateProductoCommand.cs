using Alerium.Application.utilities;

namespace Alerium.Application.Fetures.Producto.Commands.CreateProducto
{
    public interface ICreateProductoCommand
    {
        Task<RepositoryResponse> Execute(CreateProductoModel model);
    }
}
