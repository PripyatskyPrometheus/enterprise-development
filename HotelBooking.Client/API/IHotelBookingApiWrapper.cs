namespace HotelBooking.Client.API;

public interface IHotelBookingApiWrapper
{   
    Task CreateHotel(HotelDto hotelDto);
    Task<ICollection<HotelGetDto>> GetHotels();
    Task<HotelGetDto> GetHotelById(int id);
    Task UpdateHotel(int id, HotelDto hotelDto);
    Task DeleteHotel(int id);
}
