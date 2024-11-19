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
        var client = repository.GetAll();
        return Ok(mapper.Map<IEnumerable<ClientDto>>(client));
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
        return Ok(mapper.Map<IEnumerable<ClientDto>>(client));
    }

    /// <summary>
    /// Добавление нового клиента
    /// </summary>
    [HttpPost]
    public IActionResult Post([FromBody] ClientDto clientDto)
    {
        var client = mapper.Map<Client>(clientDto);
        var passport = repositoryPassport.GetById(clientDto.PassportDataId);
        if (passport == null)
            return NotFound("Паспортных данных не существует");
        client.PassportData = passport;
        return Ok(repository.Post(client));
    }

    /// <summary>
    /// Изменение данных о клиенте через id
    /// </summary>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ClientDto value)
    {
        if (repository.GetById(id) == null)
            return NotFound("Клиента с таким Id не существует");
        var client = mapper.Map<Client>(value);
        var passport = repositoryPassport.GetById(value.PassportDataId);
        if (passport == null)
            return NotFound("Паспортных данных не существует");
        client.PassportData = passport;
        return Ok(repository.Put(client, id));
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