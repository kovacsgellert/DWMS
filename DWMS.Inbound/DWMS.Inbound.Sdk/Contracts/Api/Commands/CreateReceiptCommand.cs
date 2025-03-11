using DWMS.Inbound.Sdk.Contracts.Api.Dto;
using MediatR;

namespace DWMS.Inbound.Sdk.Contracts.Api.Commands;
public class CreateReceiptCommand : IRequest<CreateReciptCommandResponse>
{
    public required CreateReceiptDto Receipt { get; set; }
}

public class CreateReciptCommandResponse
{
    public required Guid ReceiptId { get; set; }
}
