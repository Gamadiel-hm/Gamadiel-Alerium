using Alerium.Application.Interface;
using Alerium.Application.utilities;
using Alerium.Domain.Entities.Proveedor;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Alerium.Application.Fetures.Proveedor.Querys.GetProveedorById
{
    public class GetProveedorByIdQuery(IApplicationDbContext context, IMapper mapper) : IGetProveedorByIdQuery
    {
        private readonly IApplicationDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<RepositoryResponse> Execute(Guid id)
        {
            GetProveedorByIdModel getProveedor = await _context.Proveedores.ProjectTo<GetProveedorByIdModel>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(f => f.Id == id);

            if (getProveedor is null)
                return RepositoryResponse.Response(new { id }, ProveedorError.NotFound.Name);

            return RepositoryResponse.Response(getProveedor);
        }
    }
}
