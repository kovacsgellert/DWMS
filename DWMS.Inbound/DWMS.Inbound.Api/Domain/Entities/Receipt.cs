using DWMS.Inbound.Sdk.Contracts.Api.Dto;

namespace DWMS.Inbound.Api.Domain.Entities;

public class Receipt
{
    public required Guid Id { get; set; }
    public required string Code { get; set; }
    public List<ReceiptLine> ReceiptLines { get; set; } = [];

    public static Receipt Create(CreateReceiptDto dto)
    {
        var receipt = new Receipt
        {
            Id = Guid.CreateVersion7(),
            Code = dto.Code,
            ReceiptLines = []
        };

        foreach (var lineDto in dto.ReceiptLines)
        {
            receipt.ReceiptLines.Add(new ReceiptLine
            {
                Id = Guid.CreateVersion7(),
                ReceiptId = receipt.Id,
                ItemId = lineDto.ItemId,
                LineNumber = lineDto.LineNumber,
                Quantity = new Quantity
                {
                    Value = lineDto.Quantity.Value,
                    UnitOfMeasure = lineDto.Quantity.UnitOfMeasure
                }
            });
        }

        return receipt;
    }
}
