namespace HotelBooking.Domain.Entity;

/// <summary>
/// Паспортные данные клиента
/// </summary>
public class Passport
{
    /// <summary>
    /// Идентификатор паспорта
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Серия
    /// </summary>
    public required int Series { get; set; }

    /// <summary>
    /// Номер
    /// </summary>
    public required int Number { get; set; }
}