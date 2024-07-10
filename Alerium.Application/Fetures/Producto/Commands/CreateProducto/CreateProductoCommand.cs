using Alerium.Application.Interface;
using Alerium.Application.utilities;
using Alerium.Domain.Entities.Producto;
using Alerium.Domain.Entities.Proveedor;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Alerium.Application.Fetures.Producto.Commands.CreateProducto
{
    public class CreateProductoCommand(IApplicationDbContext context, IMapper mapper) : ICreateProductoCommand
    {
        private readonly IApplicationDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<RepositoryResponse> Execute(CreateProductoModel model)
        {
            bool existProveedor = await _context.Proveedores.AnyAsync(a => a.Id == model.ProveedoresId);

            if (!existProveedor)
                return RepositoryResponse.Response(model, ProductoError.NotFoundProveedor.Name);

            ProductosEntity newProduct = _mapper.Map<ProductosEntity>(model);

            _context.Productos.Add(newProduct);
            await _context.SaveAsync();

            return RepositoryResponse.Response(model);
        }
    }
}
