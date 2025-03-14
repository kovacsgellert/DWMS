﻿namespace DWMS.Inbound.Api.Domain.Entities;

public class ReceiptLine
{
    public required Guid Id { get; set; }
    public required Guid ReceiptId { get; set; }
    public required Guid ItemId { get; set; }
    public required int LineNumber { get; set; }
    public required Quantity Quantity { get; set; }

}
