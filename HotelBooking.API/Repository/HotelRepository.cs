using HotelBooking.Domain.Entity;

namespace HotelBooking.API.Repository;

public class HotelRepository : IRepository<Hotel>
{
    private readonly List<Hotel> _hotels = [];
    private int _hotelId = 0;

    public IEnumerable<Hotel> GetAll() => _hotels;

    public Hotel? GetById(int id) => _hotels.Find(x => x.Id == id);

    public Hotel Post(Hotel entity)
    {
        entity.Id = _hotelId++;
        _hotels.Add(entity);
        return entity;
    }

    public Hotel? Put(Hotel entity, int id)
    {
        var oldValue = GetById(id);
        if (oldValue == null)
            return oldValue;
        oldValue.Name = entity.Name;
        oldValue.Address = entity.Address;
        oldValue.City = entity.City;
        return oldValue;
    }

    public bool Delete(int id)
    {
        var hotel = GetById(id);
        if (hotel == null)
            return false;
        _hotels.Remove(hotel);
        return true;
    }
}