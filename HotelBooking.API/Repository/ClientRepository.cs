using HotelBooking.Domain.Entity;

namespace HotelBooking.API.Repository;

public class ClientRepository : IRepository<Client>
{
    private readonly List<Client> _clients = [];
    private int _clientId = 0;
    public IEnumerable<Client> GetAll() => _clients;

    public Client? GetById(int id) => _clients.Find(x => x.Id == id);

    public void Post(Client entity)
    {
        entity.Id = ++_clientId;
        _clients.Add(entity);
    }

    public bool Put(Client entity, int id)
    {
        var oldValue = GetById(id);
        if (oldValue == null)
            return false;
        oldValue.FullName = entity.FullName;
        oldValue.PassportData = entity.PassportData;
        oldValue.BirthOfDay = entity.BirthOfDay;
        return true;
    }

    public bool Delete(int id)
    {
        var client = GetById(id);
        if (client == null)
            return false;
        _clients.Remove(client);
        return true;
    }
}