namespace HotelBooking.Domain;

/// <summary>
///    Инофрмация о номере
/// </summary>
public class Room 
{
    /// <summary>
    ///     Id номера
    /// </summary>
    public required int ID { get; set; }

    /// <summary>
    ///     Тип номера
    /// </summary>
    public required TypeRoom Type { get; set; }

    /// <summary>
    ///     Вместимость
    /// </summary>
    public required int Capacity { get; set; }

    /// <summary>
    ///     Цена
    /// </summary>
    public required int Cost { get; set; }

    /// <summary>
    /// Id отеля
    /// </summary>
    public required int HotelID { get; set; }
}
