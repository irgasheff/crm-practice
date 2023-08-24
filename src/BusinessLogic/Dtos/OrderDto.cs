namespace BusinessLogic.Dtos;

public readonly struct OrderDto
{
    public string Description { get; init; }
    public string Price { get; init; }
    public string? Date { get; init; }
    public string DeliveryType { get; init; }
    public string? DeliveryAddress { get; init; }
}