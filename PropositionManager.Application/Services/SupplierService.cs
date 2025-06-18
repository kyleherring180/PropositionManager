using PropositionManager.Application.Abstraction.Repositories;
using PropositionManager.Application.Abstraction.Services;
using PropositionManager.Application.Enums;
using PropositionManager.Model.Entities;

namespace PropositionManager.Application.Services;

public class SupplierService(ISupplierRepository supplierRepository) : ISupplierService
{
    public async Task<EntityUpdateStatus> CreateOrUpdateSupplierAsync(string supplierName, int? supplierId = null)
    {
        //If supplierId is null, we assume it's a new supplier
        if (supplierId == null)
        {
            // Logic to add a new supplier
            var newSupplier = new Supplier(supplierName);
            
            //TODO - add validation logic here
            await supplierRepository.CreateSupplierAsync(newSupplier);
            await supplierRepository.SaveChangesAsync();
            
            return EntityUpdateStatus.Success;
        }
        
        // If supplierId is provided, we assume it's an update operation
        // Logic to update an existing supplier
        var existingSupplier = await supplierRepository.GetSupplierByIdAsync(supplierId.Value);
        if (existingSupplier == null)
        {
            // If the supplier does not exist, we can return an error status
            return EntityUpdateStatus.NotFound;
        }
        
        // Update the supplier's name
        existingSupplier.UpdateName(supplierName);

        return EntityUpdateStatus.Success;
    }
}