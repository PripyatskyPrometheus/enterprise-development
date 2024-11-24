using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Domain.Entity;

/// <summary>
/// Забронированные номера
/// </summary>
[Table("BookedRoom")]
public class BookedRoom
{
    /// <summary>
    /// Идентификатор забронированных комнат
    /// </summary>
    [Key]
    [Column("Id")]
    public required int Id { get; set; }

    /// <summary>
    /// Клиент  
    /// </summary>
    public required Client Client { get; set; }

    /// <summary>
    /// Внешний ключ клиента  
    /// </summary>
    [Column("ClientId")]
    public required int ClientId { get; set; }

    /// <summary>
    /// Комната
    /// </summary>
    public required Room Room { get; set; }

    /// <summary>
    /// Внешний ключ комнаты
    /// </summary>
    [Column("RoomId")]
    public required int RoomId { get; set; }

    /// <summary>
    /// Дата заселения
    /// </summary>
    [Column("DateArrival")]
    public required DateOnly DateArrival { get; set; }

    /// <summary>
    /// Дата выселения
    /// </summary>
    [Column("DateEvection")]
    public required DateOnly DateEvection { get; set; }

    /// <summary>
    /// Период
    /// </summary>
    [Column("PeriodInDays")]
    public required int PeriodInDays { get; set; }
}