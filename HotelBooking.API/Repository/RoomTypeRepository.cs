using HotelBooking.API.Dto;

namespace HotelBooking.API.Repository;

/// <summary>
/// Repository for working with hotel room data
/// </summary>
public class RoomTypeRepository(HotelBookingDbContext context) : IRepository<RoomTypeGetDto>
{
    /// <inheritdoc />
    public IEnumerable<RoomTypeGetDto> GetAll() => context.RoomTypes;

    /// <inheritdoc />
    public RoomTypeGetDto? GetById(int id) => context.RoomTypes.Find(x => x.Id == id);

    /// <inheritdoc />
    public int Post(RoomTypeGetDto type)
    {
        int newId = context.RoomTypes.Count > 0 ? context.RoomTypes.Max(h => h.Id) + 1 : 1;
        type.Id = newId;
        context.RoomTypes.Add(type);
        return newId;
    }

    /// <inheritdoc />
    public bool Put(RoomTypeGetDto type)
    {
        var oldValue = GetById(type.Id);

        if (oldValue == null)
            return false;

        oldValue.TypeName = type.TypeName;

        return true;
    }

    /// <inheritdoc />
    public bool Delete(int id)
    {
        var type = GetById(id);
        if (type == null)
            return false;
        _ = context.RoomTypes.Remove(type);
        return true;
    }
}