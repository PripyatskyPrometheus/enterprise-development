namespace HotelArmor.Domain;

/// <summary>
///     Забронированные номера
/// </summary>
public class ArmoredRoom {
    /// <summary>
    ///     Клиент  
    /// </summary>
    public required Client Client { get; set; }

    /// <summary>
    ///     Комната
    /// </summary
    public required Room Room { get; set; }

    /// <summary>
    ///     Дата заселения
    /// </summary>
    public required DateOnly DateArrival { get; set; }

    /// <summary>
    ///     Дата выселения
    /// </summary>
    public DateOnly DateEvection { get; set; }

    /// <summary>
    ///     Период
    /// </summary>
    public required int Period { get; set; }
}
