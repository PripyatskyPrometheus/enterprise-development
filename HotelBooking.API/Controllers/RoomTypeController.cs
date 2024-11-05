using Microsoft.AspNetCore.Mvc;
using HotelBooking.API.Dto;
using HotelBooking.API.Service;

namespace HotelBooking.API.Controllers;

/// <summary>
/// Контроллер для работы с типами номеров
/// </summary>
[ApiController]
[Route("[controller]")]
public class RoomTypeController(RoomTypeService service) : ControllerBase
{
    /// <summary>
    /// Получение информации об о всех типах
    /// </summary>
    [HttpGet]
    public ActionResult<IEnumerable<RoomTypeGetDto>> GetAll()
    {
        var type = service.GetAll();
        return Ok(type);
    }

    /// <summary>
    /// Получение информации о номере через id
    /// </summary>
    [HttpGet("{id}")]
    public ActionResult<RoomTypeGetDto> GetById(int id)
    {
        var type = service.GetById(id);
        if (type == null)
            return NotFound($"Номера с id {id} нет.");
        return Ok(type);
    }

    /// <summary>
    /// Добавление нового номера
    /// </summary>
    [HttpPost]
    public ActionResult<object> Post([FromBody] RoomTypePostDto postDto)
    {
        var newId = service.Post(postDto);
        return Ok(new { id = newId });
    }

    /// <summary>
    /// Изменение данных о номере через id
    /// </summary>
    [HttpPut("{id}")]
    public ActionResult<RoomTypeGetDto> Put(int id, [FromBody] RoomTypePostDto putDto)
    {
        var updatedType = service.Put(id, putDto);
        if (updatedType == null)
            return NotFound($"Типа с id {id} нет.");

        return Ok(updatedType);
    }

    /// <summary>
    /// Удаление типа по id
    /// </summary>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var isDeleted = service.Delete(id);
        if (!isDeleted)
            return NotFound($"Типа с id {id} нет.");

        return Ok($"Тип удалён");
    }
}