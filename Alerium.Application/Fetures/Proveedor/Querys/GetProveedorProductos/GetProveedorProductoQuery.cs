using Alerium.Application.Interface;
using Alerium.Application.utilities;
using Alerium.Domain.Entities.Proveedor;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Alerium.Application.Fetures.Proveedor.Querys.GetProveedorProductos
{
    public class GetProveedorProductoQuery(IApplicationDbContext contex, IMapper mapper) : IGetProveedorProductoQuery
    {
        private readonly IApplicationDbContext _contex = contex;
        private readonly IMapper _mapper = mapper;

        public async Task<RepositoryResponse> Execute(Guid id)
        {
            bool exist = await _contex.Proveedores.AnyAsync(a => a.Id == id);

            if (!exist)
                return RepositoryResponse.Response(new { id }, ProveedorError.NotFound.Name);

            GetProveedorProductoModel getProveedor = await _contex.Proveedores.Include(nav => nav.Productos).ProjectTo<GetProveedorProductoModel>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(f => f.Id == id);

            return RepositoryResponse.Response(getProveedor);
        }
    }
}
