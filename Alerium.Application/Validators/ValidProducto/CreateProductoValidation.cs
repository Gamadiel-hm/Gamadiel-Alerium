using Alerium.Application.Fetures.Producto.Commands.CreateProducto;
using FluentValidation;

namespace Alerium.Application.Validators.ValidProducto
{
    public class CreateProductoValidation : AbstractValidator<CreateProductoModel>
    {
        public CreateProductoValidation()
        {
            RuleFor(x => x.Codigo).NotNull().NotEmpty().MaximumLength(20);
            RuleFor(x => x.Descripccion).NotNull().NotEmpty().MaximumLength(150);
            RuleFor(x => x.Unidad).NotNull().NotEmpty().MaximumLength(3);
            RuleFor(x => x.Costo).NotEmpty()
                .Must(BeValidDecimal).WithMessage("El costo debe ser un valor decimal válido.")
                .GreaterThan(0).WithMessage("El costo debe ser mayor que 0.");
        }
        private bool BeValidDecimal(decimal costo)
        {
            // Obtiene los bits del decimal
            var bits = decimal.GetBits(costo);
            var scale = (byte)((bits[3] >> 16) & 0xFF); // Escala
            var precision = (bits[3] & 0xFFFF); // Precisión

            // Verifica que la escala y precisión sean válidas
            return scale <= 2 && precision <= 6;
        }
    }
}
