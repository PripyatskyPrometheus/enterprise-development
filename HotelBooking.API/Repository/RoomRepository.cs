using HotelBooking.API.Dto;

namespace HotelBooking.API.Repository;

/// <summary>
/// Repository for working with hotel room data
/// </summary>
public class RoomRepository(HotelBookingDbContext context) : IRepository<RoomGetDto>
{
    /// <inheritdoc />
    public IEnumerable<RoomGetDto> GetAll() => context.Rooms;

    /// <inheritdoc />
    public RoomGetDto? GetById(int id) => context.Rooms.Find(x => x.Id == id);

    /// <inheritdoc />
    public int Post(RoomGetDto room)
    {
        int newId = context.Rooms.Count > 0 ? context.Rooms.Max(h => h.Id) + 1 : 1;
        room.Id = newId;
        context.Rooms.Add(room);
        return newId;
    }

    /// <inheritdoc />
    public bool Put(RoomGetDto room)
    {
        var oldValue = GetById(room.Id);

        if (oldValue == null)
            return false;

        oldValue.Type = room.Type;
        oldValue.Capacity = room.Capacity;
        oldValue.Cost = room.Cost;
        oldValue.HotelId = room.HotelId;

        return true;
    }

    /// <inheritdoc />
    public bool Delete(int id)
    {
        var room = GetById(id);
        if (room == null)
            return false;
        _ = context.Rooms.Remove(room);
        return true;
    }
}