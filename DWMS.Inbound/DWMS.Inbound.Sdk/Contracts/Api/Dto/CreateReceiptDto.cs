namespace DWMS.Inbound.Sdk.Contracts.Api.Dto;
public class CreateReceiptDto
{
    public required string Code { get; set; }
    public List<CreateReceiptLineDto> ReceiptLines { get; set; } = [];
}

