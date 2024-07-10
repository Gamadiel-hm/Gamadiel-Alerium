using Alerium.Application.Fetures.Producto.Commands.CreateProducto;
using Alerium.Application.Fetures.Producto.Querys.GetProductoAll;
using Alerium.Application.Fetures.Proveedor.Commands.CreateProveedor;
using Alerium.Application.Fetures.Proveedor.Querys.GetProvedorAll;
using Alerium.Application.Fetures.Proveedor.Querys.GetProveedorById;
using Alerium.Application.Fetures.Proveedor.Querys.GetProveedorProductos;
using Alerium.Domain.Entities.Producto;
using Alerium.Domain.Entities.Proveedor;
using AutoMapper;

namespace Alerium.Application.Services
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CreateProveedorModel, ProveedoresEntity>();
            CreateMap<ProveedoresEntity, GetProveedorAllModel>();
            CreateMap<ProveedoresEntity, GetProveedorByIdModel>();
            CreateMap<ProveedoresEntity, GetProveedorProductoModel>();

            CreateMap<CreateProductoModel, ProductosEntity>();
            CreateMap<ProductosEntity, GetProductoAllModel>();
        }
    }
}
