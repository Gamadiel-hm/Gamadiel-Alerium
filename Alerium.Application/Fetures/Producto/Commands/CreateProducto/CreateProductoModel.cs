namespace Alerium.Application.Fetures.Producto.Commands.CreateProducto
{
    public class CreateProductoModel
    {
        public string Codigo { get; set; }
        public string Descripccion { get; set; }
        public string Unidad { get; set; }
        public decimal Costo { get; set; }
        public Guid ProveedoresId { get; set; }
    }
}
