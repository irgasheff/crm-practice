using BusinessLogic.Dtos;
using BusinessLogic.Services;
using DataAccess.Entities;

Console.WriteLine("Выбериите действие: Создать клиента (1), Создать заказ (2), Поиск по имени и фамилии (3)");
string command = Console.ReadLine();

switch (command)
{
    case "1":
        CreateClient();
        break;
    case "2":
        CreateOrder();
        break;
    case "3":
        SearchClient();
        break;
    default:
        Console.WriteLine("Неизвестная команда");
        break;
}

void CreateClient()
{
    Console.WriteLine("Введите имя клиента: ");
    string name = Console.ReadLine();

    Console.WriteLine("Введите фамилие клиента: ");
    string surname = Console.ReadLine();

    Console.WriteLine("Введите отчество клиента: ");
    string patronymic = Console.ReadLine();

    Console.WriteLine("Введите возраст клиента: ");
    string age = Console.ReadLine();

    Console.WriteLine("Введите серию паспорта клиента: ");
    string passportNumber = Console.ReadLine();

    Console.WriteLine("Введите пол клиента (male или female) :");
    string gender = Console.ReadLine();

    Console.WriteLine("Введите номер телефона клиента :");
    string phone = Console.ReadLine();

    Console.WriteLine("Введите электронную почту клиента :");
    string email = Console.ReadLine();

    Console.WriteLine("Введите пароль для клиента :");
    string password = Console.ReadLine();

    ClientDto clientDto = new ClientDto()
    {
        Name = name,
        Surname = surname,
        Patronymic = patronymic,
        Age = age,
        PassportNumber = passportNumber,
        Gender = gender,
        Phone = phone,
        Email = email,
        Password = password
    };

    if (!ValidateClient(clientDto)) return;

    ClientService clientService = new ClientService();

    clientService.CreateClient(clientDto);
}

void CreateOrder()
{
    Console.WriteLine("Введите описание заказа: ");
    string description = Console.ReadLine();

    Console.WriteLine("Введите итоговую сумму заказа: ");
    string price = Console.ReadLine();

    Console.WriteLine("Введите дату доставки заказа: ");
    string date = Console.ReadLine();

    Console.WriteLine("Введите тип доставки: ");
    string deliveryType = Console.ReadLine();

    Console.WriteLine("Введите адресс доставки: ");
    string deliveryAddress = Console.ReadLine();

    OrderDto orderDto = new OrderDto()
    {
        Description = description,
        Price = price,
        Date = date,
        DeliveryType = deliveryType,
        DeliveryAddress = deliveryAddress
    };

    if (!ValidateOrder(orderDto)) return;

    OrderService.CreateOrder(orderDto);
}

void SearchClient()
{
    Console.WriteLine("Введите имя клиента");
    string name = Console.ReadLine();

    Console.WriteLine("Введите фамилие клиента");
    string surname = Console.ReadLine();

    if (!ValidateSearchClient(name, surname)) return;

    ClientService clientService = new ClientService();
    Client? client = clientService.GetByNameAndSurname(name, surname);

    if (client is not null)
    {
        Console.WriteLine(
            $"Client by name: {name} and surname: {surname} was found, phone: {client.Phone}, passport number: {client.PassportNumber}, Phone: {client.Phone} ");
    }

    Console.WriteLine($"Client by name: {name} and surname: {surname} was not found");
}

bool ValidateClient(ClientDto clientDto)
{
    List<string> errors = new();

    if (clientDto.Name is { Length: 0 })
        errors.Add("Name field is required!");

    if (clientDto.Surname is { Length: 0 })
        errors.Add("Surname field is required");

    bool isAgeCorrect = ushort.TryParse(clientDto.Age, out ushort age);
    if (!isAgeCorrect)
        errors.Add("Please input correct value for age field!");

    if (clientDto.PassportNumber is { Length: 0 })
        errors.Add("Passport number field is required");

    if (clientDto.Gender != "male" && clientDto.Gender != "female")
        errors.Add("Please input correct value for gender field (male, female)!");

    if (clientDto.Phone is { Length: 0 })
        errors.Add("Phone field is required");

    if (clientDto.Email is { Length: 0 })
        errors.Add("Email field is required");

    if (clientDto.Password is { Length: 0 })
        errors.Add("Password field is required");

    if (errors is not { Count: > 0 }) return true;
    DisplayErrors(errors);
    return false;
}

bool ValidateOrder(OrderDto orderDto)
{
    List<string> errors = new();

    if (orderDto.Description is { Length: 0 })
        errors.Add("Заполните описание для вашего заказа");

    bool isPriceCorrect = double.TryParse(orderDto.Price, out double price);
    if (!isPriceCorrect)
        errors.Add("Введите правильное значение для поля цена");

    if (orderDto.DeliveryType != "express" && orderDto.DeliveryType != "standard" && orderDto.DeliveryType != "free")
        errors.Add("Выберите правильный тип доставки");

    if (errors is not { Count: > 0 }) return true;
    DisplayErrors(errors);
    return false;
}

bool ValidateSearchClient(string name, string surname)
{
    List<string> errors = new();

    if (name is { Length: 0 })
        errors.Add("Name field is required!");

    if (surname is { Length: 0 })
        errors.Add("Surname field is required");

    if (errors is not { Count: > 0 }) return true;
    DisplayErrors(errors);
    return false;
}

void DisplayErrors(List<string> errors)
{
    foreach (string error in errors)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(error);
    }

    Console.ForegroundColor = ConsoleColor.White;
}