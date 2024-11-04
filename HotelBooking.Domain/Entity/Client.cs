namespace HotelBooking.Domain.Entity;

/// <summary>
/// Данные клиента
/// </summary>
public class Client
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
    public required Passport PassportData { get; set; }

    /// <summary>
    /// Дата рождения
    /// </summary>
    public required DateOnly BirthOfDay { get; set; }
}
