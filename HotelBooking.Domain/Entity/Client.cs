using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Domain.Entity;

/// <summary>
/// Данные клиента
/// </summary>
[Table("Client")]
public class Client
{
    /// <summary>
    /// Идентификатор клиента
    /// </summary>
    [Key]
    [Column("Id")]
    public required int Id { get; set; }

    /// <summary>
    /// ФИО 
    /// </summary>
    [Column("FullName")]
    public required string FullName { get; set; }

    /// <summary>
    /// Паспорт
    /// </summary>
    public required Passport PassportData { get; set; }

    /// <summary>
    /// Внешний ключ паспорта для таблицы
    /// </summary>
    [Column("PassportId")]
    public required int PassportId { get; set; }

    /// <summary>
    /// Дата рождения
    /// </summary>
    [Column("BirthOfDay")]
    public required DateOnly BirthOfDay { get; set; }
}