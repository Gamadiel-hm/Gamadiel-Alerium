using Alerium.Application.Fetures.Proveedor.Commands.CreateProveedor;
using FluentValidation;

namespace Alerium.Application.Validators.ValidProveedor
{
    public class CreateProveedorValidation : AbstractValidator<CreateProveedorModel>
    {
        public CreateProveedorValidation()
        {
            RuleFor(x => x.Codigo).NotNull().NotEmpty().MaximumLength(20);
            RuleFor(x => x.RazonSocial).NotNull().NotEmpty().MaximumLength(150);
            RuleFor(x => x.RFC).NotNull().NotEmpty().MaximumLength(13);

            RuleFor(x => x.Codigo)
                .Matches(@"^[A-Za-z]{4}\d{6}[A-Za-z]\d{2}$")
                .WithMessage("El campo codigo no es valido");
        }
    }
}
