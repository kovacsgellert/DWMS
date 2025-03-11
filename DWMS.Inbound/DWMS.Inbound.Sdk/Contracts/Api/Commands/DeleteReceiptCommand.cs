using MediatR;

namespace DWMS.Inbound.Sdk.Contracts.Api.Commands;
public class DeleteReceiptCommand : IRequest<DeleteReceiptCommandResponse>
{
    public required Guid ReceiptId { get; set; }
}

public class DeleteReceiptCommandResponse
{
}
