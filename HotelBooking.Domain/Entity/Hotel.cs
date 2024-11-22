using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Domain.Entity;

/// <summary>
/// Отель
/// </summary>
[Table("Hotel")]
public class Hotel
{
    /// <summary>
    /// Идентификатор отеля
    /// </summary>
    [Key]
    [Column("Id")]
    public required int Id { get; set; }

    /// <summary>
    /// Название
    /// </summary>
    [Column("Name")]
    public required string Name { get; set; }

    /// <summary>
    /// Адрес
    /// </summary>
    [Column("Address")]
    public required string Address { get; set; }

    /// <summary>
    /// Город
    /// </summary>
    [Column("City")]
    public required string City { get; set; }
}