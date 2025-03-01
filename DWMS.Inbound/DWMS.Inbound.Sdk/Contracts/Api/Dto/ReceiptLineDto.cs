namespace DWMS.Inbound.Sdk.Contracts.Api.Dto;
public class ReceiptLineDto
{
    public required Guid Id { get; set; }
    public required Guid ReceiptId { get; set; }
    public required Guid ItemId { get; set; }
    public required int LineNumber { get; set; }
    public required QuantityDto Quantity { get; set; }
}