using Alerium.Domain.Abstract;
using Alerium.Domain.Entities.Proveedor;

namespace Alerium.Domain.Entities.Producto
{
    public sealed class ProductosEntity : Entity
    {
        public string Codigo { get; set; }
        public string Descripccion { get; set; }
        public string Unidad { get; set; }
        public decimal Costo { get; set; }

        public Guid ProveedoresId { get; set; }
        public ProveedoresEntity Proveedores { get; set; }
    }
}
