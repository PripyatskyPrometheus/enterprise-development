namespace HotelBooking.Domain;

/// <summary>
/// Инофрмация о номере
/// </summary>
public class Room 
{
    /// <summary>
    /// Идентификатор номера
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Тип номера
    /// </summary>
    public required RoomType Type { get; set; }

    /// <summary>
    /// Вместимость
    /// </summary>
    public required int Capacity { get; set; }

    /// <summary>
    /// Цена
    /// </summary>
    public required int Decimal { get; set; }

    /// <summary>
    /// Id отеля
    /// </summary>
    public required int HotelId { get; set; }
}
