namespace HotelBooking.API.Dto;


public class BookedRoomGetDto
{
    /// <summary>
    /// Клиент  
    /// </summary>
    public required ClientGetDto Client { get; set; }

    /// <summary>
    /// Комната
    /// </summary
    public required RoomGetDto Room { get; set; }

    /// <summary>
    /// Дата заселения
    /// </summary>
    public required DateOnly DateArrival { get; set; }

    /// <summary>
    /// Дата выселения
    /// </summary>
    public DateOnly? DateEvection { get; set; }

    /// <summary>
    /// Период
    /// </summary>
    public required int PeriodInDays { get; set; }
}
