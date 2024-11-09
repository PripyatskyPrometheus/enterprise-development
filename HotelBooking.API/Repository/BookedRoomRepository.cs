using HotelBooking.Domain.Entity;

namespace HotelBooking.API.Repository;

public class M
{
    public M(Client client, int total)
    {
        Total = total;
        Client = client;
    }
    public Client Client { get; set; }
    public int Total { get; set; }
}

public class BookedRoomRepository : IRepository<BookedRoom>
{
    private readonly List<BookedRoom> _roomsBooked = [];
    private int _roomsBookedId = 0;
    public IEnumerable<BookedRoom> GetAll() => _roomsBooked;

    public BookedRoom? GetById(int id) => _roomsBooked.Find(x => x.Id == id);

    public void Post(BookedRoom entity)
    {
        entity.Id = ++_roomsBookedId;
        _roomsBooked.Add(entity);
    }

    public bool Put(BookedRoom entity, int id)
    {
        var oldValue = GetById(id);
        if (oldValue == null)
            return false;
        oldValue.Client = entity.Client;
        oldValue.Room = entity.Room;
        oldValue.DateArrival = entity.DateArrival;
        oldValue.DateEvection = entity.DateEvection;
        oldValue.PeriodInDays = entity.PeriodInDays;
        return true;
    }

    public bool Delete(int id)
    {
        var bookedroom = GetById(id);
        if (bookedroom == null)
            return false;
        _roomsBooked.Remove(bookedroom);
        return true;
    }
}