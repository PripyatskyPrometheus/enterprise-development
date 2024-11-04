namespace HotelBooking.API.Dto;


public class RoomTypeGetDto
{
    /// <summary>
    /// Идентификатор типа номера
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Название
    /// </summary>
    public required string TypeName { get; set; }
}
