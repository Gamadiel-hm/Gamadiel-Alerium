using Alerium.Application.Fetures.Producto.Querys.GetProductoAll;

namespace Alerium.Application.Fetures.Proveedor.Querys.GetProveedorProductos
{
    public class GetProveedorProductoModel
    {
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public string RazonSocial { get; set; }
        public string RFC { get; set; }
        public List<GetProductoAllModel> Productos { get; set; }
    }
}
