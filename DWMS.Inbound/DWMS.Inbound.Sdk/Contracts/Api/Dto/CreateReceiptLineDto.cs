namespace DWMS.Inbound.Sdk.Contracts.Api.Dto;
public class CreateReceiptLineDto
{
    public required Guid ItemId { get; set; }
    public required int LineNumber { get; set; }
    public required QuantityDto Quantity { get; set; }
}
