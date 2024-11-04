namespace HotelBooking.API.Dto;


public class ClientGetDto
{
    /// <summary>
    /// Идентификатор клиента
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// ФИО 
    /// </summary>
    public required string FullName { get; set; }

    /// <summary>
    /// Паспорт
    /// </summary>
    public required PassportGetDto PassportData { get; set; }

    /// <summary>
    /// Дата рождения
    /// </summary>
    public required DateOnly BirthOfDay { get; set; }
}
