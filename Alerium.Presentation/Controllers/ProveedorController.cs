using Alerium.Application.Fetures.Proveedor.Commands.CreateProveedor;
using Alerium.Application.Fetures.Proveedor.Commands.DeleteProveedor;
using Alerium.Application.Fetures.Proveedor.Commands.DeleteProveedorStore;
using Alerium.Application.Fetures.Proveedor.Querys.GetProvedorAll;
using Alerium.Application.Fetures.Proveedor.Querys.GetProveedorById;
using Alerium.Application.Fetures.Proveedor.Querys.GetProveedorProductos;
using Alerium.Presentation.Utilities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Alerium.Presentation.Controllers
{
    [ApiController]
    [Route("api/v1/proveedor")]
    public class ProveedorController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateProveedorModel model,
            [FromServices] ICreateProveedorCommand createProveedorCommand, [FromServices] IValidator<CreateProveedorModel> validator)
        {
            var validate = await validator.ValidateAsync(model);
            int code;
            if (!validate.IsValid)
            {
                code = StatusCodes.Status400BadRequest;
                return StatusCode(code, ApiResponse.Response(code, validate.Errors));
            }

            var result = await createProveedorCommand.Execute(model);
            if (result.Message is not null)
            {
                code = StatusCodes.Status409Conflict;
                return StatusCode(code, ApiResponse.Response(code, result.Data, result.Message));
            }

            code = StatusCodes.Status201Created;
            return StatusCode(code, ApiResponse.Response(code, result.Data));
        }

        [HttpGet]
        public async Task<ActionResult> GetAll([FromServices] IGetProveedorAllQuery query)
        {
            var result = await query.Exucute();

            int code = StatusCodes.Status200OK;
            return StatusCode(code, ApiResponse.ResponseAll<GetProveedorAllModel>((List<GetProveedorAllModel>)result.Data, code, 1));
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult> GetById([FromRoute]Guid id, [FromServices]IGetProveedorByIdQuery query)
        {
            var result = await query.Execute(id);
            int code;
            if(result.Message is not null)
            {
                code = StatusCodes.Status400BadRequest;
                return StatusCode(code, ApiResponse.ResponseById(result.Data, code, result.Message));
            }

            code = StatusCodes.Status200OK;
            return StatusCode(code, ApiResponse.ResponseById(result.Data, code));
        }

        [HttpGet("withproducts/{id:guid}")]
        public async Task<ActionResult> GetProveedorProductos([FromRoute]Guid id, [FromServices]IGetProveedorProductoQuery query)
        {
            var result = await query.Execute(id);
            int code;
            if(result.Message is not null)
            {
                code = StatusCodes.Status400BadRequest;
                return StatusCode(code, ApiResponse.Response(code, result.Data, result.Message));
            }

            code = StatusCodes.Status200OK;
            return StatusCode(code, ApiResponse.ResponseById(result.Data, code));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteCascade([FromRoute] Guid id, [FromServices] IDeleteProveedorCommand command)
        {
            var result = await command.Execute(id);
            int code;
            if (result.Message is not null)
            {
                code = StatusCodes.Status404NotFound;
                return StatusCode(code, ApiResponse.Response(code, result.Data, result.Message));
            }

            code = StatusCodes.Status200OK;
            return StatusCode(code, ApiResponse.ResponseById(command, code));
        }

        [HttpDelete("deleteproductnotexist/{idProveedor:guid}")]
        public async Task<ActionResult> DeleteIfProductsNotExist([FromRoute]Guid idProveedor, [FromServices] IDeleteProveedorStoreCommand command)
        {
            var result = await command.Execute(idProveedor);
            int code;
            if(result.Message is not null)
            {
                code = StatusCodes.Status400BadRequest;
                return StatusCode(code, ApiResponse.Response(code, result.Data, result.Message));
            }

            code = StatusCodes.Status200OK;
            return StatusCode(code, ApiResponse.Response(code, new { }));
        }
    }
}
