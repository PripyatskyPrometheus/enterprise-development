namespace HotelArmor.Domain;
/// <summary>
///     Паспортные данные клиента
/// </summary>
public class Pasport {
    /// <summary>
    ///     ID паспорта
    /// </summary>
    public required int ID { get; set; }

/// <summary>
    /// Серия
    /// </summary>
    public required int Series { get; set; }

    /// <summary>
    ///     Номер
    /// </summary>
    public required int Number { get; set; }
}
