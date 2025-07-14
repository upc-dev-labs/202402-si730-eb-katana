using System.Net.Mime;
using eb4364u20201e843.API.MRP.Domain.Services;
using eb4364u20201e843.API.MRP.Interfaces.REST.Resources;
using eb4364u20201e843.API.MRP.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace eb4364u20201e843.API.MRP.Interfaces.REST.Controllers;

/// <summary>
///     REST API controller for managing Bill Of Materials Item resources.
/// </summary>
/// <remarks>
///     Author: Author
/// </remarks>
[ApiController]
[Route("api/v1/bill-of-materials/{billOfMaterialsId:int}/items")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Endpoints for managing bill of materials items.")]
public class BillOfMaterialsItemsController(
    IBillOfMaterialsItemCommandService billOfMaterialsItemCommandService
) : ControllerBase
{
    /// <summary>
    ///     Creates a new Bill Of Materials Item for the specified Bill Of Materials.
    /// </summary>
    /// <param name="billOfMaterialsId">The ID of the Bill Of Materials that owns this item.</param>
    /// <param name="resource">The resource representing the item to create.</param>
    /// <returns>
    ///     201 Created with the created BillOfMaterialsItemResource, or 400 Bad Request if validation fails,
    ///     or 500 Internal Server Error if an unexpected error occurs.
    /// </returns>
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new Bill Of Materials Item",
        Description = "Creates a new Bill Of Materials Item for the specified Bill Of Materials.",
        OperationId = "CreateBillOfMaterialsItem"
    )]
    [SwaggerResponse(StatusCodes.Status201Created, "The item was created", typeof(BillOfMaterialsItemResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input supplied")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error")]
    public async Task<IActionResult> CreateBillOfMaterialsItem(
        [FromRoute] int billOfMaterialsId, [FromBody] CreateBillOfMaterialsItemResource resource
    )
    {
        try
        {
            var createBillOfMaterialsItemCommand = CreateBillOfMaterialsItemCommandFromResourceAssembler
                .ToCommandFromResource(billOfMaterialsId, resource);
            var billOfMaterialsItem = await billOfMaterialsItemCommandService.Handle(createBillOfMaterialsItemCommand);
            if (billOfMaterialsItem is null) return BadRequest();
            var billOfMaterialsItemResource = BillOfMaterialsItemResourceFromEntityAssembler.ToResourceFromEntity(billOfMaterialsItem);
            return Created(string.Empty, billOfMaterialsItemResource);
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message});
        }
    }
}