namespace HotelBooking.API.Dto;

/// <summary>
/// DTO класс для возвращения значений класса Hotel
/// </summary>
public class HotelDto
{
    /// <summary>
    /// Название
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Адрес
    /// </summary>
    public required string Address { get; set; }

    /// <summary>
    /// Город
    /// </summary>
    public required string City { get; set; }
}
