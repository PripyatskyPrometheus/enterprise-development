namespace HotelBooking.API.Dto;

/// <summary>
/// Класс DTO для метода POST для типа комнат
/// </summary>
public class RoomTypePostDto
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
