using Alerium.Application.Fetures.Producto.Commands.CreateProducto;
using Alerium.Application.Fetures.Producto.Querys.GetProductoAll;
using Alerium.Application.Fetures.Producto.Querys.GetProductoProveedorId;
using Alerium.Application.Fetures.Proveedor.Commands.CreateProveedor;
using Alerium.Presentation.Utilities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Alerium.Presentation.Controllers
{
    [ApiController]
    [Route("api/v1/producto")]
    public class ProductoController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]CreateProductoModel model, [FromServices]ICreateProductoCommand command, [FromServices] IValidator<CreateProductoModel> validator)
        {
            var validate = await validator.ValidateAsync(model);
            int code;

            if (!validate.IsValid)
            {
                code = StatusCodes.Status400BadRequest;
                return StatusCode(code, ApiResponse.Response(code, validate.Errors));
            }

            var result = await command.Execute(model);
            if (result.Message is not null)
            {
                code = StatusCodes.Status400BadRequest;
                return StatusCode(code, ApiResponse.Response(code, result.Data, result.Message));
            }

            code = StatusCodes.Status201Created;
            return StatusCode(code, ApiResponse.Response(code, result.Data));
        }

        [HttpGet("byproveedor/{id:guid}")]
        public async Task<ActionResult> GetAllByProveedor([FromRoute]Guid id, [FromServices]IGetProductoAllQuery query)
        {
            var result = await query.Execute(id);
            int code = StatusCodes.Status200OK;

            if(result.Message is not null)
            {
                code = StatusCodes.Status400BadRequest;
                return StatusCode(code, ApiResponse.Response(code, result.Data, result.Message));
            }

            return StatusCode(code, ApiResponse.ResponseAll((List<GetProductoAllModel>)result.Data,code, 1, ""));
        }

        [HttpGet("idproveedor/{idproveedor:guid}/idproducto/{idproducto:guid}")]
        public async Task<ActionResult> GetProductoProveedorById([FromRoute]Guid idproveedor, [FromRoute]Guid idproducto, [FromServices]IGetProductoProveedorIdQuery query)
        {
            var result = await query.Execute(idproveedor, idproducto);
            int code;
            if(result.Message is not null)
            {
                code = StatusCodes.Status400BadRequest;
                return StatusCode(code, ApiResponse.Response(code, result.Data, result.Message));
            }

            code = StatusCodes.Status200OK;
            return StatusCode(code, result.Data);
        }
    }
}
