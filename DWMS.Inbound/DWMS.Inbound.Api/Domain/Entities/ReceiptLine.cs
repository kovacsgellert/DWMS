using DWMS.Inbound.Api.DataAccess.Common;

namespace DWMS.Inbound.Api.Domain.Entities;

public class ReceiptLine : IHasGuidId
{
    public Guid Id { get; set; }
    public Guid ReceiptId { get; set; }
    public required string Code { get; set; }
    public decimal Quantity { get; set; }
    public decimal Price { get; set; }
}
