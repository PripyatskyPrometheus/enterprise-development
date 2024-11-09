using Microsoft.AspNetCore.Mvc;
using HotelBooking.API.Dto;
using HotelBooking.API.Repository;
using HotelBooking.Domain.Entity;
using AutoMapper;

namespace HotelBooking.API.Controllers;

/// <summary>
/// Контроллер для работы с клиентами
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ClientController(IRepository<Client> repository, IRepository<Passport> repositoryPassport, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Получение информации об о всех клиентах
    /// </summary>
    [HttpGet]
    public ActionResult<IEnumerable<ClientDto>> GetAll()
    {
        return Ok(repository.GetAll());
    }

    /// <summary>
    /// Получение информации о клиентах через id
    /// </summary>
    [HttpGet("{id}")]
    public ActionResult<ClientDto> GetById(int id)
    {
        var client = repository.GetById(id);
        if (client == null)
            return NotFound("Клиента с таким Id не существует");
        return Ok(client);
    }

    /// <summary>
    /// Добавление нового клиента
    /// </summary>
    [HttpPost]
    public IActionResult Post([FromBody] ClientDto value, PassportDto value1)
    {
        if (repositoryPassport.GetById(value.PassportDataId) == null)
            return NotFound();
        var client = mapper.Map<Client>(value);
        if (mapper.Map<Passport>(value1) != repositoryPassport.GetById(value.PassportDataId))
            NotFound();
        client.PassportData = mapper.Map<Passport>(value1);
        repository.Post(client);
        return Ok();
    }

    /// <summary>
    /// Изменение данных о клиенте через id
    /// </summary>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ClientDto value, PassportDto value1)
    {
        if (repository.GetById(id) == null)
            return NotFound("Клиента с таким Id не существует");
        if (repositoryPassport.GetById(value.PassportDataId) == null)
            return NotFound();
        var client = mapper.Map<Client>(value);
        if (mapper.Map<Passport>(value1) != repositoryPassport.GetById(value.PassportDataId))
            NotFound();
        client.PassportData = mapper.Map<Passport>(value1);
        repository.Put(client, id);
        return Ok();
    }

    /// <summary>
    /// Удаление клиента по id
    /// </summary>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (repository.GetById(id) == null)
            return NotFound("Клиента с таким Id не существует");
        repository.Delete(id);
        return Ok();
    }
}