namespace HotelBooking.Domain.Enity;

/// <summary>
/// Типы номеров
/// </summary>
public class RoomType
{
    /// <summary>
    /// Идентификатор типа номера
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Название
    /// </summary>
    public required string TypeName { get; set; }
}
