using HotelBooking.Domain.Entity;

namespace HotelBooking.API.Application;

public class DataCostMinMaxAvgInHotel(IEnumerable<Hotel> hotel, decimal min, decimal max, decimal avg)
{
    public IEnumerable<Hotel> Hotel { get; set; } = hotel;
    public decimal Min { get; set; } = min;
    public decimal Max { get; set; } = max;
    public decimal Avg { get; set; } = avg;
}