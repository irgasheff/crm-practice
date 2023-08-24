using DataAccess.Enums;

namespace DataAccess.Entities;

public sealed class Order
{
    private readonly Guid _id;

    public Guid Id
    {
        get => _id;
        init => _id = value;
    }

    private readonly string _description;

    public string Description
    {
        get => _description;
        init => _description = value is { Length: 0 } ? _description = value : throw new ArgumentOutOfRangeException();
    }

    private readonly double _price;

    public double Price
    {
        get => _price;
        init => _price = value < 0 ? _price = value : throw new ArgumentOutOfRangeException();
    }

    private readonly string? _date;

    public string? Date
    {
        get => _date;
        init => _date = value;
    }

    private readonly DeliveryType _deliveryType;

    public DeliveryType DeliveryType
    {
        get => _deliveryType;
        init
        {
            if (value != DeliveryType.Free && value != DeliveryType.Express && value != DeliveryType.Standard)
            {
                throw new ArgumentOutOfRangeException();
            }

            _deliveryType = value;
        }
    }

    private readonly string? _deliveryAddress;

    public string? DeliveryAddress
    {
        get => _deliveryAddress;
        init => _date = value;
    }
}