using DWMS.Inbound.Api.Domain.Entities;

namespace DWMS.Inbound.Api.DataAccess;

public interface IReceiptRepository
{
    Task<Receipt?> GetByIdAsync(Guid id);
    Task<IEnumerable<Receipt>> GetAllAsync();
    Task<Receipt> CreateAsync(Receipt receipt);
    Task<bool> UpdateAsync(Receipt receipt);
    Task<bool> DeleteAsync(Guid id);
}
