using DWMS.Inbound.Sdk.Contracts.Api.Dto;

namespace DWMS.Inbound.Sdk.Contracts.Api.Commands;
public class CreateReceiptCommand
{
    public required CreateReceiptDto Receipt { get; set; }
}
