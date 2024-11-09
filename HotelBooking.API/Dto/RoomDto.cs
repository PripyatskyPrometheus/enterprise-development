namespace HotelBooking.API.Dto;

/// <summary>
/// DTO класс для возвращения значений Room
/// </summary>
public class RoomDto
{
    /// <summary>
    /// Тип номера
    /// </summary>
    public required int TypeId { get; set; }

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
