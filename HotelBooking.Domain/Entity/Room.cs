using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Domain.Entity;

/// <summary>
/// Инофрмация о номере
/// </summary>
[Table("Room")]
public class Room
{
    /// <summary>
    /// Идентификатор номера
    /// </summary>
    [Key]
    [Column("Id")]
    public required int Id { get; set; }

    /// <summary>
    /// Тип номера
    /// </summary>
    public required RoomType Type { get; set; }

    /// <summary>
    /// Внешний ключ типа номера
    /// </summary>
    [Column("TypeId")]
    public required int TypeId { get; set; }

    /// <summary>
    /// Вместимость
    /// </summary>
    [Column("Capacity")]
    public required int Capacity { get; set; }

    /// <summary>
    /// Цена
    /// </summary>
    [Column("Cost")]
    public required decimal Cost { get; set; }

    /// <summary>
    /// Id отеля
    /// </summary>
    public required Hotel Hotel { get; set; }

    /// <summary>
    /// Id отеля
    /// </summary>
    [Column("HotelId")]
    public required int HotelId { get; set; }
}