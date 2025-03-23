using DWMS.Inbound.Sdk.Contracts.Api.Dto;
using MediatR;

namespace DWMS.Inbound.Sdk.Contracts.Api.Queries;

public class GetReceiptByIdQuery : IRequest<GetReceiptByIdQueryResponse>
{
    public required Guid ReceiptId { get; set; }
}

public class GetReceiptByIdQueryResponse
{
    public ReceiptDto? Receipt { get; set; }
}
