using BusinessLogic.Dtos;
using DataAccess.Entities;
using DataAccess.Enums;

namespace BusinessLogic.Services;

public class ClientService
{
    private readonly List<Client> _clients;

    public List<Client> Clients
    {
        get => _clients;
        init => _clients = value;
    }

    public void CreateClient(ClientDto clientDto)
    {
        Gender gender = clientDto.Gender switch
        {
            "male" => Gender.Male,
            "female" => Gender.Female,
            _ => Gender.Male
        };

        Client client = new Client()
        {
            Name = clientDto.Name,
            Surname = clientDto.Surname,
            Patronymic = clientDto.Patronymic,
            Age = ushort.Parse((string)clientDto.Age),
            PassportNumber = clientDto.PassportNumber,
            Gender = gender,
            Phone = clientDto.Phone,
            Email = clientDto.Email,
            Password = clientDto.Password
        };

        Clients.Add(client);
    }

    public Client? GetByNameAndSurname(string name, string surname)
    {
        Client? clientToReturn = null;
        foreach (Client client in _clients)
        {
            if (client.Name == name && client.Surname == surname)
            {
                clientToReturn = client;
            }
            else
            {
                return null;
            }
        }

        return clientToReturn;
    }
}