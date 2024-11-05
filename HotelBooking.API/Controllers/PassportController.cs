using Microsoft.AspNetCore.Mvc;
using HotelBooking.API.Dto;
using HotelBooking.API.Service;

namespace HotelBooking.API.Controllers;

/// <summary>
/// Контроллер для работы с паспортами
/// </summary>
[ApiController]
[Route("[controller]")]
public class PassportController(PassportService service) : ControllerBase
{
    /// <summary>
    /// Получение информации об о всех клиентах
    /// </summary>
    [HttpGet]
    public ActionResult<IEnumerable<PassportGetDto>> GetAll()
    {
        var passports = service.GetAll();
        return Ok(passports);
    }

    /// <summary>
    /// Получение информации о паспорте через id
    /// </summary>
    [HttpGet("{id}")]
    public ActionResult<PassportGetDto> GetById(int id)
    {
        var passport = service.GetById(id);
        if (passport == null)
            return NotFound($"Паспорта с id {id} нет.");
        return Ok(passport);
    }

    /// <summary>
    /// Добавление нового паспорта
    /// </summary>
    [HttpPost]
    public ActionResult<object> Post([FromBody] PassportPostDto postDto)
    {
        var newId = service.Post(postDto);
        return Ok(new { id = newId });
    }

    /// <summary>
    /// Изменение данных о клиенте через id
    /// </summary>
    [HttpPut("{id}")]
    public ActionResult<PassportGetDto> Put(int id, [FromBody] PassportPostDto putDto)
    {
        var updatedPassport = service.Put(id, putDto);
        if (updatedPassport == null)
            return NotFound($"Паспорта с id {id} нет.");

        return Ok(updatedPassport);
    }

    /// <summary>
    /// Удаление клиента по id
    /// </summary>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var isDeleted = service.Delete(id);
        if (!isDeleted)
            return NotFound($"Паспорта с id {id} нет.");

        return Ok($"Паспорт удалён");
    }
}