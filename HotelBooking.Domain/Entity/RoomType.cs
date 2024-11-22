using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Domain.Entity;

/// <summary>
/// Типы номеров
/// </summary>
[Table("RoomType")]
public class RoomType
{
    /// <summary>
    /// Идентификатор типа номера
    /// </summary>
    [Key]
    [Column("Id")]
    public required int Id { get; set; }

    /// <summary>
    /// Название
    /// </summary>
    [Column("TypeName")]
    public required string TypeName { get; set; }
}