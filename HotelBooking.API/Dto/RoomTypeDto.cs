namespace HotelBooking.API.Dto;

/// <summary>
/// DTO класс для возвращения значений RoomType
/// </summary>
public class RoomTypeDto
{
    /// <summary>
    /// Название
    /// </summary>
    public required string TypeName { get; set; }
}