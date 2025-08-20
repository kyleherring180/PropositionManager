using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PropositionManager.Application.Abstraction.Services;
using PropositionManager.Application.Enums;
using PropositionManager.Contracts.v1.Request;
using PropositionManager.Contracts.v1.Response;
using PropositionManager.Model.Extensions;
using PropositionManager.Model.Shared;
using PropositionManager.Presentation.v1.MapToContract;
using PropositionManager.Presentation.v1.MapToModel;

namespace PropositionManager.Presentation.v1.Controllers;

[Produces("application/json")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[ApiController]
public class PropositionManagerController(
    ISupplierService supplierService, 
    IPriceService priceService, 
    ICostTypeService costTypeService,
    IPropositionService propositionService) : ControllerBase
{
    [HttpGet("propositions")]
    [ProducesResponseType(typeof(IEnumerable<Proposition>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BadRequestResult), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(NotFoundResult), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetPropositions()
    {
        var propositions = await propositionService.GetAllPropositionsAsync();
        
        if (propositions.Count == 0)
            return NotFound("No propositions found.");
        
        var result = propositions.Select(p => p.ToContract()).ToList();
        
        return Ok(result);
    }
    
    [HttpGet("proposition/{id}")]
    [ProducesResponseType(typeof(Proposition), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BadRequestResult), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(NotFoundResult), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetPropositionById(Guid id)
    {
        if(id == Guid.Empty)
            return BadRequest("Proposition ID is a required field.");

        try
        {
            var proposition = await propositionService.GetPropositionByIdAsync(id);
            if (proposition == null)
                return NotFound($"Proposition with ID {id} not found.");
            
            return Ok(proposition.ToContract());
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = $"An error occurred while retrieving the proposition: {ex.Message }" });
        } 
        
        
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
    public async Task<IActionResult> AddOrUpdatePrice([FromBody] PriceRequest request)
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
    
    [HttpPut("add-proposition")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BadRequestResult), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(NotFoundResult), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AddOrUpdateProposition([FromBody] PropositionRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
            return BadRequest("Proposition name cannot be empty.");

        if (request.MartketStartDate == null)
            return BadRequest("Market start date is a required field.");
        
        var marketPeriod = new Period(request.MartketStartDate.ToDutchDateTimeOffset(), request.MarketEndDate?.ToDutchDateTimeOffset());

        if (request.SupplierId == null)
            return BadRequest("Proposition must be linked to a supplier.");
        
        var result = await propositionService.CreateOrUpdatePropositionAsync(
            request.Name, 
            marketPeriod, 
            request.SupplierId, 
            request.PropositionId);

        return result switch
        {
            EntityUpdateStatus.Success => Ok(new { Message = "Proposition was added/updated successfully." }),
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
    
    [HttpPut("add-proposition-price")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AddOrUpdatePropositionPrice([FromBody] PropositionPriceRequest request)
    {
        if(Guid.Empty == request.PropositionId || Guid.Empty == request.PriceId)
            return BadRequest("PropositionId and PriceId are required fields.");

        var result = await propositionService.CreateOrUpdatePropositionPrice(request.PropositionId, request.PriceId);

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
}