using Alerium.Application.Interface;
using Alerium.Application.utilities;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Alerium.Application.Fetures.Proveedor.Querys.GetProvedorAll
{
    public class GetProveedorAllQuery(IApplicationDbContext context, IMapper mapper) : IGetProveedorAllQuery
    {
        private readonly IApplicationDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<RepositoryResponse> Exucute()
        {
            List<GetProveedorAllModel> getProveedors = await _context.Proveedores.ProjectTo<GetProveedorAllModel>(_mapper.ConfigurationProvider).ToListAsync();

            return RepositoryResponse.ResponseAll(getProveedors);
        }
    }
}
