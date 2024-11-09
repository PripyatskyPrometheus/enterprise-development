namespace HotelBooking.Domain.Entity;

/// <summary>
/// Забронированные номера
/// </summary>
public class BookedRoom
{
    /// <summary>
    /// Идентификатор забронированных комнат
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Клиент  
    /// </summary>
    public required Client Client { get; set; }

    /// <summary>
    /// Комната
    /// </summary
    public required Room Room { get; set; }

    /// <summary>
    /// Дата заселения
    /// </summary>
    public required DateOnly DateArrival { get; set; }

    /// <summary>
    /// Дата выселения
    /// </summary>
    public required DateOnly DateEvection { get; set; }

    /// <summary>
    /// Период
    /// </summary>
    public required int PeriodInDays { get; set; }
}