using DWMS.Inbound.Api.DataAccess;
using DWMS.Inbound.Sdk.Contracts.Api.Commands;
using MediatR;

namespace DWMS.Inbound.Api.Domain.CommandHandlers;

public class DeleteReceiptCommandHandler
    : IRequestHandler<DeleteReceiptCommand, DeleteReceiptCommandResponse>
{
    private readonly IReceiptRepository _receiptRepository;

    public DeleteReceiptCommandHandler(IReceiptRepository receiptRepository)
    {
        _receiptRepository = receiptRepository;
    }

    public async Task<DeleteReceiptCommandResponse> Handle(
        DeleteReceiptCommand request,
        CancellationToken cancellationToken
    )
    {
        await _receiptRepository.DeleteAsync(request.ReceiptId);
        return new DeleteReceiptCommandResponse();
    }
}
