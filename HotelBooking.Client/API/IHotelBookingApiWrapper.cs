namespace HotelBooking.Client.API;

public interface IHotelBookingApiWrapper
{   
    Task CreateHotel(HotelDto hotelDto);
    Task<ICollection<HotelGetDto>> GetAllHotels();
    Task<HotelGetDto> GetHotelById(int id);
    Task UpdateHotel(int id, HotelDto hotelDto);
    Task DeleteHotel(int id);

    Task CreateBookedRoom(BookedRoomDto bookedRoomDto);

    Task<ICollection<BookedRoomGetDto>> GetAllBookedRooms();

    Task<BookedRoomGetDto> GetBookedRoomById(int id);

    Task UpdateBookedRoom(int id, BookedRoomDto bookedRoomDto);

    Task DeleteBookedRoom(int id);

    Task CreateRoom(RoomDto roomDto);

    Task<ICollection<RoomGetDto>> GetAllRooms();

    Task<RoomGetDto> GetRoomById(int id);

    Task UpdateRoom(int id, RoomDto roomDto);

    Task DeleteRoom(int id);

    Task CreateClient(ClientDto clientDto);

    Task<ICollection<ClientGetDto>> GetAllClients();

    Task<ClientGetDto> GetClientById(int id);

    Task UpdateClient(int id, ClientDto clientDto);

    Task DeleteClient(int id);
}
