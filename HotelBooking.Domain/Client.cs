namespace HotelBooking.Domain;

/// <summary>
///     Данные клиента
/// </summary>
public class Client 
{
    /// <summary>
    ///     Id клиента
    /// </summary>
    public required int ID { get; set; }

    /// <summary>
    ///     ФИО 
    /// </summary>
    public required string FullName { get; set; }

    /// <summary>
    ///     Пасспорт
    /// </summary>
    public required Passport PasportData { get; set; }

    /// <summary>
    ///     Дата рождения
    /// </summary>
    public required DateOnly BirthOfDay { get; set; }
}
