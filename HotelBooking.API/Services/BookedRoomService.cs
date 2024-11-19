using HotelBooking.Domain.Entity;
using HotelBooking.API.Repository;
using HotelBooking.API.Application;

namespace HotelBooking.API.Services;
public class BookedRoomService(IRepository<BookedRoom> repositoryBookedRoom,
    IRepository<Room> repositoryRoom,
    IRepository<Hotel> repositoryHotel) : IBookedRoomService
{
    public IEnumerable<Client> ReturnAllClientInHotel(int hotelId, IEnumerable<Room> rooms)
    {
        var clientInHotel = repositoryBookedRoom.GetAll()
            .OrderBy(r => r.Client.FullName)
            .Where(r => rooms.ToList().Contains(r.Room))
            .Select(r => r.Client)
            .Distinct()
            .ToList();
        return clientInHotel;
    }

    public IEnumerable<Room> GetFreeRoomInCity(IEnumerable<Room> rooms)
    {
        var bookedRooms = repositoryBookedRoom.GetAll().Where(r => rooms.Contains(r.Room)).Select(r => r.Room);
        var freeRooms = rooms.Where(r => !bookedRooms.Contains(r)).Select(r => r);
        return freeRooms;
    }

    public IEnumerable<DataBookedRoom> GetLongLiversHotel()
    {

        var longerPeriods = repositoryBookedRoom.GetAll()
            .GroupBy(c => c.Client)
            .Select(c => new
            {
                Client = c.Key,
                Total = c.Sum(r => r.PeriodInDays)
            }).Max(c => c.Total);

        var clientWithLongerPer = repositoryBookedRoom.GetAll()
            .GroupBy(c => c.Client)
            .Select(c => new
            {
                Client = c.Key,
                Total = c.Sum(r => r.PeriodInDays)
            }).Where(c => c.Total == longerPeriods).Select(c => new DataBookedRoom(c.Client, c.Total)).ToList();
        return clientWithLongerPer;
    }

    public Hotel GetHotelById(int id)
    {
        return repositoryHotel.GetAll().FirstOrDefault(h => h.Id == id);
    }

    public IEnumerable<int> GetHotelsByCity(string city) => repositoryHotel.GetAll().Where(h => h.City == city).Select(h => h.Id);

    public IEnumerable<Room> GetRoomsInHotel(IEnumerable<int> id) => repositoryRoom.GetAll().Where(r => id.Contains(r.HotelId)).Select(r => r);
}
