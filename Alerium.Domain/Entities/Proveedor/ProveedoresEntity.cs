using Alerium.Domain.Abstract;
using Alerium.Domain.Entities.Producto;

namespace Alerium.Domain.Entities.Proveedor
{
    public sealed class ProveedoresEntity : Entity
    {
        public string Codigo { get; set; }
        public string RazonSocial { get; set; }
        public string RFC { get; set; }

        public List<ProductosEntity> Productos { get; set; }
    }
}
