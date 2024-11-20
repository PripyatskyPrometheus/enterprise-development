namespace HotelBooking.API.Dto;

/// <summary>
/// DTO класс для возвращения значений Room
/// </summary>
public class RoomGetDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Тип номера
    /// </summary>
    public required RoomGetDto Type { get; set; }

    /// <summary>
    /// Вместимость
    /// </summary>
    public required int Capacity { get; set; }

    /// <summary>
    /// Цена
    /// </summary>
    public required decimal Cost { get; set; }

    /// <summary>
    /// Id отеля
    /// </summary>
    public required int HotelId { get; set; }
}
