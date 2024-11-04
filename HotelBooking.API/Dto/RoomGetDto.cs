namespace HotelBooking.API.Dto;

public class RoomGetDto
{
    /// <summary>
    /// Идентификатор номера
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Тип номера
    /// </summary>
    public required RoomTypeGetDto Type { get; set; }

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
