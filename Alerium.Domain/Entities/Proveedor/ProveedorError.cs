using Alerium.Domain.Abstract;

namespace Alerium.Domain.Entities.Proveedor
{
    public static class ProveedorError
    {
        public static Error NotFound => new("Proveedor.NotFound", "No existe este proveedor");
        public static Error Exist => new("Proveedor.Exist", "Ya existe este proveedor");
        public static Error NotDelete => new("NotDelete.HaveProducts", "No se puede borrar el proveedor porque tiene productos");
    }
}
