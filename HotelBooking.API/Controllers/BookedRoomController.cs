using Microsoft.AspNetCore.Mvc;
using HotelBooking.API.Dto;
using HotelBooking.API.Service;

namespace HotelBooking.API.Controllers;

/// <summary>
/// Контроллер для работы с забранированными номерами.
/// </summary>
[ApiController]
[Route("[controller]")]
public class BookedRoomController(BookedRoomService service) : ControllerBase
{
    /// <summary>
    /// Получение информации о всех забронированных номерах.
    /// </summary>
    [HttpGet]
    public ActionResult<IEnumerable<BookedRoomGetDto>> GetAll()
    {
        var book = service.GetAll();
        return Ok(book);
    }

    /// <summary>
    /// Получение информации по id о комнате
    /// </summary>
    [HttpGet("{id}")]
    public ActionResult<BookedRoomGetDto> GetById(int id)
    {
        var book = service.GetById(id);
        if (book == null)
            return NotFound($"Брони с id {id} нет.");
        return Ok(book);
    }

    /// <summary>
    /// Добавление новой брони
    /// </summary>
    [HttpPost]
    public ActionResult<object> Post([FromBody] BookedRoomPostDto postDto)
    {
        var newId = service.Post(postDto);
        return Ok(new { id = newId });
    }

    /// <summary>
    /// Изменение в брони
    /// </summary>
    [HttpPut("{id}")]
    public ActionResult<BookedRoomGetDto> Put(int id, [FromBody] BookedRoomPostDto putDto)
    {
        var updatedBookedRoom = service.Put(id, putDto);
        if (updatedBookedRoom == null)
            return NotFound($"Брони с id {id} нет.");
        return Ok(updatedBookedRoom);
    }

    /// <summary>
    /// Удаление брони по Id
    /// </summary>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var isDeleted = service.Delete(id);
        if (!isDeleted)
            return NotFound($"Брони с id {id} нет.");
        return Ok($"Бронь удалена");
    }
}
