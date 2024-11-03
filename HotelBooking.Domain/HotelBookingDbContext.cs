using HotelBooking.Domain.Enity;

namespace HotelBooking.Domain;

public class HotelBookingDbContext
{
    public List<Hotel> Hotels { get; set; }

    public List<Client> Clients { get; set; }

    public List<Passport> Passports { get; set; }

    public List<Room> Rooms { get; set; }

    public List<BookedRoom> BookedRooms { get; set; }

    public List<RoomType> RoomTypes { get; set; }


}
