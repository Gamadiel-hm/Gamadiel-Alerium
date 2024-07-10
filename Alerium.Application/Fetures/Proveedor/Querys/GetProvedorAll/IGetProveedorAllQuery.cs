using Alerium.Application.utilities;

namespace Alerium.Application.Fetures.Proveedor.Querys.GetProvedorAll
{
    public interface IGetProveedorAllQuery
    {
        Task<RepositoryResponse> Exucute();
    }
}
