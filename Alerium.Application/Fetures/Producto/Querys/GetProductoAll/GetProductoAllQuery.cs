using Alerium.Application.Interface;
using Alerium.Application.utilities;
using Alerium.Domain.Entities.Producto;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Alerium.Application.Fetures.Producto.Querys.GetProductoAll
{
    public class GetProductoAllQuery(IApplicationDbContext context, IMapper mapper) : IGetProductoAllQuery
    {
        private readonly IApplicationDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<RepositoryResponse> Execute(Guid id)
        {
            List<GetProductoAllModel> productos = await _context.Productos.Where(w => w.ProveedoresId == id).ProjectTo<GetProductoAllModel>(_mapper.ConfigurationProvider).ToListAsync();

            if (productos.Count == 0)
                return RepositoryResponse.Response(new { id }, ProductoError.NotFoundProveedor.Name);

            return RepositoryResponse.ResponseAll<GetProductoAllModel>(productos);
            
        }
    }
}
