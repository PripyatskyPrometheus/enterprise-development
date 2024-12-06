namespace HotelBooking.Client.API;

public class HotelBookingApiWrapper(IConfiguration configuration) : IHotelBookingApiWrapper
{
    public readonly HotelBooking client = new(configuration["OpenApi:ServerUrl"], new HttpClient());

    public async Task CreateHotel(HotelDto hotelDto) => await client.HotelPOSTAsync(hotelDto);

    public async Task<ICollection<HotelGetDto>> GetHotels() =>  await client.HotelAllAsync();

    public async Task<HotelGetDto> GetHotelById(int id) => await client.HotelGETAsync(id);

    public async Task UpdateHotel(int id, HotelDto hotelDto) => await client.HotelPUTAsync(id, hotelDto);

    public async Task DeleteHotel(int id) => await client.HotelDELETEAsync(id);
}
