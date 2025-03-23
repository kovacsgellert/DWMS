using DWMS.Inbound.Api.DataAccess;
using DWMS.Inbound.Api.Domain.Entities;
using DWMS.Inbound.Sdk.Contracts.Api.Commands;
using MediatR;

namespace DWMS.Inbound.Api.Domain.CommandHandlers;

public class CreateReceiptCommandHandler
    : IRequestHandler<CreateReceiptCommand, CreateReceiptCommandResponse>
{
    private readonly IReceiptRepository _receiptRepository;

    public CreateReceiptCommandHandler(IReceiptRepository receiptRepository)
    {
        _receiptRepository = receiptRepository;
    }

    public async Task<CreateReceiptCommandResponse> Handle(
        CreateReceiptCommand request,
        CancellationToken cancellationToken
    )
    {
        var receipt = Receipt.Create(request.Receipt);

        await _receiptRepository.CreateAsync(receipt);

        return new CreateReceiptCommandResponse { ReceiptId = receipt.Id };
    }
}
