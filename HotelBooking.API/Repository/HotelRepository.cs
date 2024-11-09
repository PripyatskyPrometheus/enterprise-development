using HotelBooking.Domain.Entity;

namespace HotelBooking.API.Repository;

public class T
{
    public T(IEnumerable<Hotel> hotel, decimal min, decimal max, decimal avg)
    {
        Min = min; Max = max;
        Avg = avg;
        Hotel = hotel;
    }
    public IEnumerable<Hotel> Hotel { get; set; }
    public decimal Min { get; set; }
    public decimal Max { get; set; }
    public decimal Avg { get; set; }
}

public class HotelRepository : IRepository<Hotel>
{
    private readonly List<Hotel> _hotels = [];
    private int _hotelId = 0;

    public IEnumerable<Hotel> GetAll() => _hotels;

    public Hotel? GetById(int id) => _hotels.Find(x => x.Id == id);

    public void Post(Hotel entity)
    {
        entity.Id = _hotelId++;
        _hotels.Add(entity);
    }

    public bool Put(Hotel entity, int id)
    {
        var oldValue = GetById(id);
        if (oldValue == null)
            return false;
        oldValue.Name = entity.Name;
        oldValue.Address = entity.Address;
        oldValue.City = entity.City;
        return true;
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