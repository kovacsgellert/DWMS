namespace DWMS.Inbound.Api.Domain.Entities;

public class Quantity
{
    public required decimal Value { get; set; }
    public required string UnitOfMeasure { get; set; }

    public Quantity(decimal value, string unitOfMeasure)
    {
        Value = value;
        UnitOfMeasure = unitOfMeasure;
    }
}
