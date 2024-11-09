namespace HotelBooking.API.Dto;

/// <summary>
/// DTO класс для возвращения значений класса Client
/// </summary>
public class ClientDto
{
    /// <summary>
    /// ФИО 
    /// </summary>
    public required string FullName { get; set; }

    /// <summary>
    /// Паспорт
    /// </summary>
    public required int PassportDataId { get; set; }

    /// <summary>
    /// Дата рождения
    /// </summary>
    public required string BirthOfDay { get; set; }
}