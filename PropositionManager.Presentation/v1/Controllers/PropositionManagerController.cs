using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PropositionManager.Application.Abstraction.Services;
using PropositionManager.Application.Enums;
using PropositionManager.Contracts.v1.Request;
using PropositionManager.Contracts.v1.Response;
using PropositionManager.Presentation.v1.MapToContract;
using PropositionManager.Presentation.v1.MapToModel;

namespace PropositionManager.Presentation.v1.Controllers;

[Produces("application/json")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[ApiController]
public class PropositionManagerController(ISupplierService supplierService, IPriceService priceService, ICostTypeService costTypeService) : ControllerBase
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
    
    [HttpGet("prices/{supplierId}")]
    [ProducesResponseType(typeof(IEnumerable<Proposition>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BadRequestResult), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(NotFoundResult), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetPricesBySupplierId(int supplierId)
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
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdatePrice([FromBody] PriceRequest request)
    {
        if(string.IsNullOrWhiteSpace(request.Name))
            return BadRequest("Price name cannot be empty.");
        
        var result = await priceService.CreatePriceAsync(request.ToModel());

        return result switch
        {
            EntityUpdateStatus.Success => Ok(new { Message = "Price updated successfully." }),
            EntityUpdateStatus.NoChange => Ok("No changes were made to the price."),
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
        
        var result = await supplierService.CreateOrUpdateSupplierAsync(request.SupplierName, request.SupplierId);

        return result switch
        {
            EntityUpdateStatus.Success => Ok(new { Message = "Supplier was added/updated successfully." }),
            // BadRequestResult => BadRequest(new { Message = "Invalid request." }),
            // NotFoundResult => NotFound(new { Message = "Price not found." }),
            // ProblemDetails => StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while updating the price." }),
            _ => StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An unexpected error occurred." })
        };
    }
    
    [HttpPut("update-cost-type")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BadRequestResult), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(NotFoundResult), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateCostType([FromBody] CostTypeRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
            return BadRequest("CostType name cannot be empty.");

        var result = await costTypeService.CreateOrUpdateCostTypeAsync(request.Name, request.CostTypeId);

        return result switch
        {
            EntityUpdateStatus.Success => Ok(new { Message = "CostType was added/updated successfully." }),
            // BadRequestResult => BadRequest(new { Message = "Invalid request." }),
            EntityUpdateStatus.NotFound => NotFound(new { Message = $"CostType with Id {request.CostTypeId} not found." }),
            // ProblemDetails => StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while updating the price." }),
            _ => StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An unexpected error occurred." })
        };
    }
}