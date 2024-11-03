using HotelBooking.Domain.Enity;
namespace HotelBooking.API.Dto;

/// <summary>
/// Класс DTO для метода POST для комнат
/// </summary>
public class RoomPostDto
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
    public required decimal Cost { get; set; }

    /// <summary>
    /// Id отеля
    /// </summary>
    public required int HotelId { get; set; }
}
