using Alerium.Domain.Abstract;

namespace Alerium.Domain.Entities.Producto
{
    public static class ProductoError
    {
        public static Error NotFound => new("Producto.NotFound","No existe este producto");
        public static Error Exist => new("Producto.Exist","Ya existe este producto");
        public static Error NotFoundProveedor => new("Proveedor.NotExist","No existe este proveedor");
        public static Error NotFoundProveedorProducto => new("ProveedorProducto.NotExist","No existe algun id");
    }
}
