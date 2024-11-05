using Microsoft.AspNetCore.Mvc;
using HotelBooking.API.Dto;
using HotelBooking.API.Service;

namespace HotelBooking.API.Controllers;

/// <summary>
/// Контроллер для работы с клиентами
/// </summary>
[ApiController]
[Route("[controller]")]
public class ClientController(ClientService service) : ControllerBase
{
    /// <summary>
    /// Получение информации об о всех клиентах
    /// </summary>
    [HttpGet]
    public ActionResult<IEnumerable<ClientGetDto>> GetAll()
    {
        var client = service.GetAll();
        return Ok(client);
    }

    /// <summary>
    /// Получение информации о клиентах через id
    /// </summary>
    [HttpGet("{id}")]
    public ActionResult<ClientGetDto> GetById(int id)
    {
        var client = service.GetById(id);
        if (client == null)
            return NotFound($"Client with id {id} not found.");
        return Ok(client);
    }

    /// <summary>
    /// Добавление нового клиента
    /// </summary>
    [HttpPost]
    public ActionResult<object> Post([FromBody] ClientPostDto postDto)
    {
        var newId = service.Post(postDto);
        return Ok(new { id = newId });
    }

    /// <summary>
    /// Изменение данных о клиенте через id
    /// </summary>
    [HttpPut("{id}")]
    public ActionResult<ClientGetDto> Put(int id, [FromBody] ClientPostDto putDto)
    {
        var updatedClient = service.Put(id, putDto);
        if (updatedClient == null)
            return NotFound($"Клиента с таким id {id} не существует.");

        return Ok(updatedClient);
    }

    /// <summary>
    /// Удаление клиента по id
    /// </summary>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var isDeleted = service.Delete(id);
        if (!isDeleted)
            return NotFound($"Клиента с таким id {id} не существует.");

        return Ok($"Клиента с таким id {id} удалён.");
    }
}
