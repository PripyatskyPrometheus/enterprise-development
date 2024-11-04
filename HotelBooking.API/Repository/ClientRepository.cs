using HotelBooking.API.Dto;

namespace HotelBooking.API.Repository;

/// <summary>
/// Repository for working with hotel room data
/// </summary>
public class ClientRepository(HotelBookingDbContext context) : IRepository<ClientGetDto>
{
    /// <inheritdoc />
    public IEnumerable<ClientGetDto> GetAll() => context.Clients;

    /// <inheritdoc />
    public ClientGetDto? GetById(int id) => context.Clients.Find(x => x.Id == id);

    /// <inheritdoc />
    public int Post(ClientGetDto client)
    {
        int newId = context.Clients.Count > 0 ? context.Clients.Max(h => h.Id) + 1 : 1;
        client.Id = newId;
        context.Clients.Add(client);
        return newId;
    }

    /// <inheritdoc />
    public bool Put(ClientGetDto client)
    {
        var oldValue = GetById(client.Id);

        if (oldValue == null)
            return false;

        oldValue.FullName = client.FullName;
        oldValue.PassportData = client.PassportData;
        oldValue.BirthOfDay = client.BirthOfDay;

        return true;
    }

    /// <inheritdoc />
    public bool Delete(int id)
    {
        var client = GetById(id);
        if (client == null)
            return false;
        _ = context.Clients.Remove(client);
        return true;
    }
}