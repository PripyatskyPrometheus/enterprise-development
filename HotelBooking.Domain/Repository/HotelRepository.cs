using HotelBooking.Domain.Enity;

namespace HotelBooking.Domain.Repository;

public class HotelRepository(HotelBookingDbContext context) : IRepository<Hotel>
{
    /// <inheritdoc />
    public IEnumerable<Hotel> GetAll() => context.Hotels;

    /// <inheritdoc />
    public Hotel? GetById(int id) => context.Hotels.Find(x => x.Id == id);

    /// <inheritdoc />
    public void Post(Hotel hotel)
    {
        context.Hotels.Add(hotel);
    }

    /// <inheritdoc />
    public bool Put(Hotel hotel)
    {
        var oldValue = GetById(hotel.Id);

        if (oldValue == null)
            return false;

        oldValue.Name = hotel.Name;
        oldValue.Address = hotel.Address;
        oldValue.City = hotel.City;

        return true;
    }

    /// <inheritdoc />
    public bool Delete(int id)
    {
        var hotel = GetById(id);
        if (hotel == null)
            return false;
        _ = context.Hotels.Remove(hotel);
        return true;
    }
}