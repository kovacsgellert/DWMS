namespace DWMS.Inbound.Sdk.Contracts.Api;
public class QuantityDto
{
    public required decimal Value { get; set; }
    public required string UnitOfMeasure { get; set; }

    public QuantityDto(decimal value, string unitOfMeasure)
    {
        Value = value;
        UnitOfMeasure = unitOfMeasure;
    }
}
