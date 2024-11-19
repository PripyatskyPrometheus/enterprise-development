using HotelBooking.API.Application;
using HotelBooking.API.Repository;
using HotelBooking.Domain.Entity;

namespace HotelBooking.API.Services;

public interface IHotelService
{
    public int GetCountHotels();

    public IEnumerable<Hotel> GetTopFiveHotelById(IEnumerable<int> id);

    public IEnumerable<DataHotelMinMaxAvgCost> GetMaxAvgMinForHotels(IEnumerable<Room> rooms);

    public IEnumerable<int> GetTopFiveHotelId();
}
