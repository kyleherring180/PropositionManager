using PropositionManager.Application.Enums;

namespace PropositionManager.Application.Abstraction.Services;

public interface ISupplierService
{
    /// <summary>
    /// Adds a new supplier to the system.
    /// </summary>
    /// <param name="supplierName"></param>
    /// <param name="supplierId"></param>
    /// <returns></returns>
    Task<SupplierUpdateStatus> UpdateSupplierAsync(string supplierName, int? supplierId = null);
}