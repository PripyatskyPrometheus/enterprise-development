using HotelBooking.API.Application;
using HotelBooking.Domain.Entity;

namespace HotelBooking.API.Services;

public interface IHotelService
{
    public int GetCountHotels();

    public IEnumerable<Hotel> GetTopFiveHotelById(IEnumerable<int> id);

    public IEnumerable<DataCostMinMaxAvgInHotel> GetMaxAvgMinForHotels(IEnumerable<Room> rooms);

    public IEnumerable<int> GetTopFiveHotelId();
}