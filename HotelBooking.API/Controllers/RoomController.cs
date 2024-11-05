using Microsoft.AspNetCore.Mvc;
using HotelBooking.API.Dto;
using HotelBooking.API.Service;

namespace HotelBooking.API.Controllers;

/// <summary>
/// Контроллер для работы с номерами
/// </summary>
[ApiController]
[Route("[controller]")]
public class RoomController(RoomService service) : ControllerBase
{
    /// <summary>
    /// Получение информации об о всех номерах
    /// </summary>
    [HttpGet]
    public ActionResult<IEnumerable<RoomGetDto>> GetAll()
    {
        var room = service.GetAll();
        return Ok(room);
    }

    /// <summary>
    /// Получение информации о номере через id
    /// </summary>
    [HttpGet("{id}")]
    public ActionResult<RoomGetDto> GetById(int id)
    {
        var room = service.GetById(id);
        if (room == null)
            return NotFound($"Номера с id {id} нет.");
        return Ok(room);
    }

    /// <summary>
    /// Добавление нового номера
    /// </summary>
    [HttpPost]
    public ActionResult<object> Post([FromBody] RoomPostDto postDto)
    {
        var newId = service.Post(postDto);
        return Ok(new { id = newId });
    }

    /// <summary>
    /// Изменение данных о номере через id
    /// </summary>
    [HttpPut("{id}")]
    public ActionResult<RoomGetDto> Put(int id, [FromBody] RoomPostDto putDto)
    {
        var updatedRoom = service.Put(id, putDto);
        if (updatedRoom == null)
            return NotFound($"Номера с id {id} нет.");

        return Ok(updatedRoom);
    }

    /// <summary>
    /// Удаление номера по id
    /// </summary>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var isDeleted = service.Delete(id);
        if (!isDeleted)
            return NotFound($"Номера с id {id} нет.");

        return Ok($"Номер удалён");
    }
}