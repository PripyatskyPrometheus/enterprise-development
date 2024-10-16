namespace HotelBooking.Domain;

/// <summary>
///     Типы номеров
/// </summary>
public class TypeRoom 
{
    /// <summary>
    ///     ID типа
    /// </summary>
    public required int ID { get; set; }

    /// <summary>
    ///     Название
    /// </summary>
    public required string NameRoom { get; set; }
}
