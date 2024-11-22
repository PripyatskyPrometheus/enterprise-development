using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Domain.Entity;

/// <summary>
/// Паспортные данные клиента
/// </summary>
[Table("Passport")]
public class Passport
{
    /// <summary>
    /// Идентификатор паспорта
    /// </summary>
    [Key]
    [Column("Id")]
    public required int Id { get; set; }

    /// <summary>
    /// Серия
    /// </summary>
    [Column("Series")]
    public required int Series { get; set; }

    /// <summary>
    /// Номер
    /// </summary>
    [Column("Number")]
    public required int Number { get; set; }
}