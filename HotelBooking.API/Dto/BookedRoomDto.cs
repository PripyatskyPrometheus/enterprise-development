namespace HotelBooking.API.Dto;

/// <summary>
/// DTO класс для возвращения значений класса BookedRoom
/// </summary>
public class BookedRoomDto
{
    /// <summary>
    /// Клиент  
    /// </summary>
    public required int ClientId { get; set; }

    /// <summary>
    /// Комната
    /// </summary>
    public required int RoomId { get; set; }

    /// <summary>
    /// Дата въезда
    /// </summary>
    public required string DateArrival { get; set; }

    /// <summary>
    /// Дата выселения
    /// </summary>
    public required string DateEvection { get; set; }

    /// <summary>
    /// Период
    /// </summary>
    public required int PeriodInDays { get; set; }
}