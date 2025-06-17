using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PropositionManager.Application.Abstraction.Services;
using PropositionManager.Application.Enums;
using PropositionManager.Contracts.v1.Request;
using PropositionManager.Contracts.v1.Response;
using PropositionManager.Presentation.v1.MapToContract;

namespace PropositionManager.Presentation.v1.Controllers;

[Produces("application/json")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[ApiController]
public class PropositionManagerController(ISupplierService supplierService, IPriceService priceService) : ControllerBase
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
    
    [HttpGet("prices")]
    [ProducesResponseType(typeof(IEnumerable<Proposition>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BadRequestResult), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(NotFoundResult), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetPricesBySupplierId([FromQuery] int supplierId)
    {
        if (supplierId == 0)
            return BadRequest("SupplierId is a required field.");
        
        var result = await priceService.GetPricesBySupplierIdAsync(supplierId);
        
        if(result.Count == 0)
            return NotFound($"No prices found for supplier with ID {supplierId}.");
        
        return Ok(result.ToContract());
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