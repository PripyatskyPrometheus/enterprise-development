using HotelBooking.Domain.Entity;

namespace HotelBooking.API.Repository;

public class RoomRepository : IRepository<Room>
{
    private readonly List<Room> _rooms = [];
    private int _roomId = 0;
    public IEnumerable<Room> GetAll() => _rooms;

    public Room? GetById(int id) => _rooms.Find(x => x.Id == id);

    public void Post(Room entity)
    {
        entity.Id = ++_roomId;
        _rooms.Add(entity);
    }

    public bool Put(Room room, int id)
    {
        var oldValue = GetById(id);

        if (oldValue == null)
            return false;
        oldValue.Type = room.Type;
        oldValue.Capacity = room.Capacity;
        oldValue.Cost = room.Cost;
        oldValue.HotelId = room.HotelId;
        return true;
    }

    public bool Delete(int id)
    {
        var room = GetById(id);
        if (room == null)
            return false;
        _rooms.Remove(room);
        return true;
    }
}