using Alerium.Application.Interface;
using Alerium.Application.utilities;
using Alerium.Domain.Entities.Proveedor;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Alerium.Application.Fetures.Proveedor.Commands.CreateProveedor
{
    public class CreateProveedorCommand(IApplicationDbContext context, IMapper mapper) : ICreateProveedorCommand
    {
        private readonly IApplicationDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<RepositoryResponse> Execute(CreateProveedorModel proveedor)
        {
            bool exist = await _context.Proveedores.AnyAsync(p => p.Codigo == proveedor.Codigo);

            if (exist)
                return RepositoryResponse.Response(proveedor, ProveedorError.Exist.Name);

            ProveedoresEntity newProveedor = _mapper.Map<ProveedoresEntity>(proveedor);
            _context.Proveedores.Add(newProveedor);
            await _context.SaveAsync();

            return RepositoryResponse.Response(proveedor);
        }
    }
}
