using DWMS.Inbound.Sdk.Contracts.Api.Dto;
using MediatR;

namespace DWMS.Inbound.Sdk.Contracts.Api.Commands;

public class CreateReceiptCommand : IRequest<CreateReceiptCommandResponse>
{
    public required CreateReceiptDto Receipt { get; set; }
}

public class CreateReceiptCommandResponse
{
    public required Guid ReceiptId { get; set; }
}
