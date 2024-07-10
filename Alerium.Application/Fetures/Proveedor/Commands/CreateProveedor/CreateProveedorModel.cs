namespace Alerium.Application.Fetures.Proveedor.Commands.CreateProveedor
{
    public record CreateProveedorModel
    {
        public string Codigo { get; set; }
        public string RazonSocial { get; set; }
        public string RFC { get; set; }
    }
}
