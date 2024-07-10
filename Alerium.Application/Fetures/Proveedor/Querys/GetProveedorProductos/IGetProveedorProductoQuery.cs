using Alerium.Application.utilities;

namespace Alerium.Application.Fetures.Proveedor.Querys.GetProveedorProductos
{
    public interface IGetProveedorProductoQuery
    {
        public Task<RepositoryResponse> Execute(Guid id);
    }
}
