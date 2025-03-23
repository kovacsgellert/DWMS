using DWMS.Inbound.Api.DataAccess;
using DWMS.Inbound.Sdk.Contracts.Api.Dto;
using DWMS.Inbound.Sdk.Contracts.Api.Queries;
using MediatR;

namespace DWMS.Inbound.Api.Domain.QueryHandlers;

public class GetReceiptByIdQueryHandler
    : IRequestHandler<GetReceiptByIdQuery, GetReceiptByIdQueryResponse>
{
    private readonly IReceiptRepository _receiptRepository;

    public GetReceiptByIdQueryHandler(IReceiptRepository receiptRepository)
    {
        _receiptRepository = receiptRepository;
    }

    public async Task<GetReceiptByIdQueryResponse> Handle(
        GetReceiptByIdQuery request,
        CancellationToken cancellationToken
    )
    {
        var receipt = await _receiptRepository.GetByIdAsync(request.ReceiptId);

        if (receipt == null)
        {
            return new GetReceiptByIdQueryResponse { Receipt = null };
        }

        // Map receipt entity to DTO
        var receiptDto = new ReceiptDto { Id = receipt.Id, Code = receipt.Code };

        return new GetReceiptByIdQueryResponse { Receipt = receiptDto };
    }
}
