using BusinessLogic.Dtos;
using DataAccess.Entities;
using DataAccess.Enums;

namespace BusinessLogic.Services;

public class OrderService
{
    public static Order CreateOrder(OrderDto orderDto)
    {
        DeliveryType deliveryType = orderDto.DeliveryType switch
        {
            "express" => DeliveryType.Express,
            "standard" => DeliveryType.Standard,
            "free" => DeliveryType.Free,
            _ => DeliveryType.Free
        };

        return new Order()
        {
            Description = orderDto.Description,
            Price = double.Parse((string)orderDto.Price),
            Date = orderDto.Date,
            DeliveryType = deliveryType,
            DeliveryAddress = orderDto.DeliveryAddress
        };
    }
}