using DWMS.Inbound.Api.DataAccess.Common;

namespace DWMS.Inbound.Api.Domain.Entities;

public class Receipt : IHasGuidId
{
    public Guid Id { get; set; }
    public required string Code { get; set; }
    public List<ReceiptLine> ReceiptLines { get; set; } = new List<ReceiptLine>();
}
