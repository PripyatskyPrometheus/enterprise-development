using HotelBooking.API.Dto;

namespace HotelBooking.API.Repository;

public class BookedRoomRepository(HotelBookingDbContext context) : IRepository<BookedRoomGetDto>
{
    /// <inheritdoc />
    public IEnumerable<BookedRoomGetDto> GetAll() => context.BookedRooms;

    /// <inheritdoc />
    public BookedRoomGetDto? GetById(int id) => context.BookedRooms.Find(x => x.Room.Id == id);

    /// <inheritdoc />
    public int Post(BookedRoomGetDto bookedroom)
    {
        int newId = context.BookedRooms.Count > 0 ? context.BookedRooms.Max(br => br.Room.Id) + 1 : 1;
        bookedroom.Room.Id = newId;
        context.BookedRooms.Add(bookedroom);
        return newId;
    }

    /// <inheritdoc />
    public bool Put(BookedRoomGetDto bookedroom)
    {
        var oldValue = GetById(bookedroom.Room.Id);

        if (oldValue == null)
            return false;

        oldValue.Client = bookedroom.Client;
        oldValue.Room = bookedroom.Room;
        oldValue.DateArrival = bookedroom.DateArrival;
        oldValue.DateEvection = bookedroom.DateEvection;
        oldValue.PeriodInDays = bookedroom.PeriodInDays;
        return true;
    }

    /// <inheritdoc />
    public bool Delete(int id)
    {
        var bookedroom = GetById(id);
        if (bookedroom == null)
            return false;
        _ = context.BookedRooms.Remove(bookedroom);
        return true;
    }
}