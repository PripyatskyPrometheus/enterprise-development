using HotelBooking.Domain.Entity;

namespace HotelBooking.API.Dto;

/// <summary>
/// Класс DTO для метода POST для забронированных комнат
/// </summary>
public class BookedRoomPostDto
{
    /// <summary>
    /// Клиент  
    /// </summary>
    public required ClientPostDto Client { get; set; }

    /// <summary>
    /// Комната
    /// </summary
    public required RoomPostDto Room { get; set; }

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
