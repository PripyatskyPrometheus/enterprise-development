namespace HotelBooking.Client.API;

public class HotelBookingApiWrapper(IConfiguration configuration) : IHotelBookingApiWrapper
{
    public readonly HotelBookingApi client = new(configuration["OpenApi:ServerUrl"], new HttpClient());

    public async Task CreateHotel(HotelDto hotelDto) => await client.HotelPOSTAsync(hotelDto);

    public async Task<ICollection<HotelGetDto>> GetAllHotels() =>  await client.HotelAllAsync();

    public async Task<HotelGetDto> GetHotelById(int id) => await client.HotelGETAsync(id);

    public async Task UpdateHotel(int id, HotelDto hotelDto) => await client.HotelPUTAsync(id, hotelDto);

    public async Task DeleteHotel(int id) => await client.HotelDELETEAsync(id);

    public async Task CreateBookedRoom(BookedRoomDto bookedRoomDto) => await client.BookedRoomPOSTAsync(bookedRoomDto);

    public async Task<ICollection<BookedRoomGetDto>> GetAllBookedRooms() => await client.BookedRoomAllAsync();

    public async Task<BookedRoomGetDto> GetBookedRoomById(int id) => await client.BookedRoomGETAsync(id);

    public async Task UpdateBookedRoom(int id, BookedRoomDto bookedRoomDto) => await client.BookedRoomPUTAsync(id, bookedRoomDto);

    public async Task DeleteBookedRoom(int id) => await client.BookedRoomDELETEAsync(id);

    public async Task CreateRoom(RoomDto roomDto) => await client.RoomPOSTAsync(roomDto);

    public async Task<ICollection<RoomGetDto>> GetAllRooms() => await client.RoomAllAsync();

    public async Task<RoomGetDto> GetRoomById(int id) => await client.RoomGETAsync(id);

    public async Task UpdateRoom(int id, RoomDto roomDto) => await client.RoomPUTAsync(id, roomDto);

    public async Task DeleteRoom(int id) => await client.RoomDELETEAsync(id);

    public async Task CreateClient(ClientDto clientDto) => await client.ClientPOSTAsync(clientDto);

    public async Task<ICollection<ClientGetDto>> GetAllClients() => await client.ClientAllAsync();

    public async Task<ClientGetDto> GetClientById(int id) => await client.ClientGETAsync(id);

    public async Task UpdateClient(int id, ClientDto clientDto) => await client.ClientPUTAsync(id, clientDto);

    public async Task DeleteClient(int id) => await client.ClientDELETEAsync(id);
}