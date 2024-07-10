using Alerium.Application.Fetures.Producto.Querys.GetProductoAll;
using Alerium.Application.Interface;
using Alerium.Application.utilities;
using Alerium.Domain.Entities.Producto;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Alerium.Application.Fetures.Producto.Querys.GetProductoProveedorId
{
    public class GetProductoProveedorIdQuery(IApplicationDbContext context, IMapper mapper) : IGetProductoProveedorIdQuery
    {
        private readonly IApplicationDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<RepositoryResponse> Execute(Guid idProveedor, Guid idProducto)
        {
            GetProductoAllModel getProducto = await _context.Productos.Where(w => w.Id == idProducto && w.ProveedoresId == idProveedor).ProjectTo<GetProductoAllModel>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(); 

            if(getProducto is null)
                return RepositoryResponse.Response(new { idProducto, idProveedor }, ProductoError.NotFoundProveedorProducto.Name);

            return RepositoryResponse.Response(getProducto);
        }
    }
}
