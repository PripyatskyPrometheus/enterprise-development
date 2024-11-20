namespace HotelBooking.API.Dto;

/// <summary>
/// DTO класс для возвращения значений RoomType
/// </summary>
public class RoomTypeGetDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Название
    /// </summary>
    public required string TypeName { get; set; }
}