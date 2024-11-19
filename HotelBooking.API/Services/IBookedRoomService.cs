using HotelBooking.API.Application;
using HotelBooking.Domain.Entity;

namespace HotelBooking.API.Services;

public interface IBookedRoomService
{
    public IEnumerable<Client> ReturnAllClientInHotel(int hotelId, IEnumerable<Room> rooms);
    public IEnumerable<Room> GetFreeRoomInCity(IEnumerable<Room> rooms);
    public IEnumerable<DataBookedRoom> GetLongLiversHotel();
    public Hotel GetHotelById(int id);
    public IEnumerable<int> GetHotelsByCity(string city);
    public IEnumerable<Room> GetRoomsInHotel(IEnumerable<int> id);
}