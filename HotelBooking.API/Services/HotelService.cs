using HotelBooking.API.Application;
using HotelBooking.API.Repository;
using HotelBooking.Domain.Entity;

namespace HotelBooking.API.Services;

public class HotelService(IRepository<Hotel> repository, IRepository<BookedRoom> repositoryBookedRoom) : IHotelService
{
    public int GetCountHotels() => repository.GetAll().Count();

    public IEnumerable<Hotel> GetTopFiveHotelById(IEnumerable<int> id)
    {
        return repository.GetAll().Where(h => id.Contains(h.Id));
    }

    public IEnumerable<DataCostMinMaxAvgInHotel> GetMaxAvgMinForHotels(IEnumerable<Room> rooms)
    {
        var hotelCosts = repository.GetAll().Select(h => new DataCostMinMaxAvgInHotel
        (
            (repository.GetAll().Where(hotel => hotel.Id == h.Id).Select(hotel => hotel)),
            rooms.Where(r => r.HotelId == h.Id).Select(r => r).ToList().Min(rm => rm.Cost),
            rooms.Where(r => r.HotelId == h.Id).Select(r => r).ToList().Max(rm => rm.Cost),
            rooms.Where(r => r.HotelId == h.Id).Select(r => r).ToList().Average(rm => rm.Cost)
        )).AsEnumerable();

        return hotelCosts;
    }

    public IEnumerable<int> GetTopFiveHotelId() => repositoryBookedRoom.GetAll().GroupBy(r => r.Room.HotelId).Select(r => r.Key).Take(5);
}