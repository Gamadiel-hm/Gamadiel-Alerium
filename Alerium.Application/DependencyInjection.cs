using Alerium.Application.Fetures.Producto.Commands.CreateProducto;
using Alerium.Application.Fetures.Producto.Querys.GetProductoAll;
using Alerium.Application.Fetures.Producto.Querys.GetProductoProveedorId;
using Alerium.Application.Fetures.Proveedor.Commands.CreateProveedor;
using Alerium.Application.Fetures.Proveedor.Commands.DeleteProveedor;
using Alerium.Application.Fetures.Proveedor.Commands.DeleteProveedorStore;
using Alerium.Application.Fetures.Proveedor.Querys.GetProvedorAll;
using Alerium.Application.Fetures.Proveedor.Querys.GetProveedorById;
using Alerium.Application.Fetures.Proveedor.Querys.GetProveedorProductos;
using Alerium.Application.Services;
using Alerium.Application.Validators.ValidProducto;
using Alerium.Application.Validators.ValidProveedor;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Alerium.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var mapper = new MapperConfiguration(config =>
            {
                config.AddProfile(new MapperProfile());
            });

            services.AddSingleton(mapper.CreateMapper());

            #region Proveedor
            services.AddTransient<ICreateProveedorCommand, CreateProveedorCommand>()
                .AddTransient<IGetProveedorAllQuery, GetProveedorAllQuery>()
                .AddTransient<IDeleteProveedorCommand, DeleteProveedorCommand>()
                .AddTransient<IGetProveedorByIdQuery, GetProveedorByIdQuery>()
                .AddTransient<IGetProveedorProductoQuery, GetProveedorProductoQuery>()
                .AddTransient<IDeleteProveedorStoreCommand, DeleteProveedorStoreCommand>();
            #endregion

            #region Producto
            services.AddTransient<ICreateProductoCommand, CreateProductoCommand>()
                    .AddTransient<IGetProductoAllQuery, GetProductoAllQuery>()
                    .AddTransient<IGetProductoProveedorIdQuery, GetProductoProveedorIdQuery>();
            #endregion

            #region validators
            services.AddScoped<IValidator<CreateProveedorModel>, CreateProveedorValidation>()
                .AddScoped<IValidator<CreateProductoModel>, CreateProductoValidation>();
            #endregion
            return services;
        }
    }
}
