using System.Net.Mime;
using eb4364u20201e843.API.SCM.Domain.Model.Queries;
using eb4364u20201e843.API.SCM.Domain.Services;
using eb4364u20201e843.API.SCM.Interfaces.REST.Resources;
using eb4364u20201e843.API.SCM.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace eb4364u20201e843.API.SCM.Interfaces.REST.Controllers;

/// <summary>
///     REST API controller for managing Part resources.
/// </summary>
/// <remarks>
///     Author: Author
/// </remarks>
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Endpoints for managing parts.")]
public class PartsController(
    IPartCommandService partCommandService,
    IPartQueryService partQueryService
) : ControllerBase
{

    /// <summary>
    ///     Retrieves a Part by its ID.
    /// </summary>
    /// <param name="partId">The Part ID.</param>
    /// <returns>200 with PartResource, 404 if not found, 400 if invalid.</returns>
    [HttpGet("{partId:int}")]
    [SwaggerOperation(
        Summary = "Get a part by ID",
        Description = "Retrieves a Part resource by its database ID.",
        OperationId = "GetPartById"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "The part was found", typeof(PartResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid ID supplied")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The part was not found")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error")]
    public async Task<IActionResult> GetPartById([FromRoute] int partId)
    {
        try
        {
            if (partId <= 0) return BadRequest();
            var getPartByIdQuery = new GetPartByIdQuery(partId);
            var part = await partQueryService.Handle(getPartByIdQuery);
            if (part is null) return NotFound();
            var partResource = PartResourceFromEntityAssembler.ToResourceFromEntity(part);
            return Ok(partResource);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(StatusCodes.Status500InternalServerError, new { error = "Internal server error." });
        }
    }

    /// <summary>
    ///     Creates a new Part.
    /// </summary>
    /// <param name="resource">The CreatePartResource from the client.</param>
    /// <returns>201 with PartResource, 400 if validation fails.</returns>
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new part",
        Description = "Creates a new Part resource with the specified data.",
        OperationId = "CreatePart"
    )]
    [SwaggerResponse(StatusCodes.Status201Created, "The part was created", typeof(PartResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input supplied")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error")]
    public async Task<IActionResult> CreatePart([FromBody] CreatePartResource resource)
    {
        try
        {
            var createPartCommand = CreatePartCommandFromResourceAssembler.ToCommandFromResource(resource);
            var part = await partCommandService.Handle(createPartCommand);
            if (part is null) return BadRequest();
            var partResource = PartResourceFromEntityAssembler.ToResourceFromEntity(part);
            return CreatedAtAction(
                nameof(CreatePart),
                new { partId = part.Id },
                partResource
            );
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(StatusCodes.Status500InternalServerError, new { error = "Internal server error." });
        }
    }
}