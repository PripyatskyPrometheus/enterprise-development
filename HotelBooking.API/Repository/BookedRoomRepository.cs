using HotelBooking.Domain.Entity;

namespace HotelBooking.API.Repository;

public class BookedRoomRepository : IRepository<BookedRoom>
{
    private readonly List<BookedRoom> _roomsBooked = [];
    private int _roomsBookedId = 0;
    public IEnumerable<BookedRoom> GetAll() => _roomsBooked;

    public BookedRoom? GetById(int id) => _roomsBooked.Find(x => x.Id == id);

    public BookedRoom Post(BookedRoom entity)
    {
        entity.Id = _roomsBookedId++;
        _roomsBooked.Add(entity);
        return entity;  
    }

    public BookedRoom? Put(BookedRoom entity, int id)
    {
        var oldValue = GetById(id);
        if (oldValue == null)
            return oldValue;
        oldValue.Client = entity.Client;
        oldValue.Room = entity.Room;
        oldValue.DateArrival = entity.DateArrival;
        oldValue.DateEvection = entity.DateEvection;
        oldValue.PeriodInDays = entity.PeriodInDays;
        return oldValue;
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