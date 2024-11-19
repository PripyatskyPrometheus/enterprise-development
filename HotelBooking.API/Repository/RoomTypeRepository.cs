using HotelBooking.Domain.Entity;

namespace HotelBooking.API.Repository;

public class RoomTypeRepository : IRepository<RoomType>
{
    private readonly List<RoomType> _roomType = [];
    private int _roomTypeId = 0;

    public IEnumerable<RoomType> GetAll() => _roomType;

    public RoomType? GetById(int id) => _roomType.Find(x => x.Id == id);

    public RoomType Post(RoomType entity)
    {
        entity.Id = ++_roomTypeId;
         _roomType.Add(entity);
        return entity;
    }

    public RoomType? Put(RoomType entity, int id)
    {
        var oldValue = GetById(id);
        if (oldValue == null)
            return oldValue;
        oldValue.TypeName = entity.TypeName;
        return oldValue;
    }

    public bool Delete(int id)
    {
        var type = GetById(id);
        if (type == null)
            return false;
        _roomType.Remove(type);
        return true;
    }
}