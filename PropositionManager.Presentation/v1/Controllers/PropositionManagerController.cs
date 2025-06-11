using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PropositionManager.Application.Abstraction.Services;
using PropositionManager.Application.Enums;
using PropositionManager.Contracts.v1.Request;
using PropositionManager.Contracts.v1.Response;

namespace PropositionManager.Presentation.v1.Controllers;

[Produces("application/json")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[ApiController]
public class PropositionManagerController(ISupplierService supplierService) : ControllerBase
{
    [HttpGet("propositions")]
    [ProducesResponseType(typeof(IEnumerable<Proposition>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BadRequestResult), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(NotFoundResult), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetPropositions()
    {
        // This is a placeholder for the actual implementation.
        // You would typically call a service to get the propositions.
        return Ok(new { Message = "This is a placeholder response." });
    }
    
    [HttpGet("proposition/{id}")]
    [ProducesResponseType(typeof(Proposition), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BadRequestResult), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(NotFoundResult), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetPropositionById(Guid id)
    {
        // This is a placeholder for the actual implementation.
        // You would typically call a service to get the proposition by ID.
        return Ok(new { Message = $"This is a placeholder response for proposition with ID: {id}." });
    }

    [HttpPut("price")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdatePrice([FromBody] PriceRequest request)
    {
        var result = Ok();

        return result switch
        {
            OkResult => Ok(new { Message = "Price updated successfully." }),
            // BadRequestResult => BadRequest(new { Message = "Invalid request." }),
            // NotFoundResult => NotFound(new { Message = "Price not found." }),
            // ProblemDetails => StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while updating the price." }),
            _ => StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An unexpected error occurred." })
        };
    }
    
    [HttpPut("add-supplier")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BadRequestResult), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(NotFoundResult), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateSupplier([FromBody] SupplierRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.SupplierName))
            return BadRequest("Supplier name cannot be empty.");
        
        var result = await supplierService.UpdateSupplierAsync(request.SupplierName);

        return result switch
        {
            SupplierUpdateStatus.Success => Ok(new { Message = "Supplier was added/updated successfully." }),
            // BadRequestResult => BadRequest(new { Message = "Invalid request." }),
            // NotFoundResult => NotFound(new { Message = "Price not found." }),
            // ProblemDetails => StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while updating the price." }),
            _ => StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An unexpected error occurred." })
        };
    }
}