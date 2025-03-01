namespace DWMS.Inbound.Sdk.Contracts.Api.Dto;

public class ReceiptDto
{
    public required Guid Id { get; set; }
    public required string Code { get; set; }
    public Guid? TripId { get; set; }
}