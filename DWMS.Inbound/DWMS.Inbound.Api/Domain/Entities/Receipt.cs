namespace DWMS.Inbound.Api.Domain.Entities;

public class Receipt
{
    public required Guid Id { get; set; }
    public required string Code { get; set; }
    public List<ReceiptLine> ReceiptLines { get; set; } = new List<ReceiptLine>();
}
