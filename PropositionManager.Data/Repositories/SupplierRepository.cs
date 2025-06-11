using Microsoft.EntityFrameworkCore;
using PropositionManager.Application.Abstraction.Repositories;
using PropositionManager.Model.Entities;

namespace PropositionManager.Data.Repositories;

public class SupplierRepository(PropositionManagerContext context) : ISupplierRepository
{
    public async Task CreateSupplierAsync(Supplier supplier)
    {
        await context.Suppliers.AddAsync(supplier);
    }

    public async Task<Supplier> GetSupplierByIdAsync(int supplierId)
    {
        return await context.Suppliers
            .FirstOrDefaultAsync(s => s.Id == supplierId);
    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
}
