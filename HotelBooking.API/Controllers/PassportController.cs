using Microsoft.AspNetCore.Mvc;
using HotelBooking.API.Dto;
using HotelBooking.API.Repository;
using HotelBooking.Domain.Entity;
using AutoMapper;

namespace HotelBooking.API.Controllers;

/// <summary>
/// Контроллер для работы с паспортами
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class PassportController(IRepository<Passport> repository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Получение информации об о всех клиентах
    /// </summary>
    [HttpGet]
    public ActionResult<IEnumerable<Passport>> GetAll()
    {
        var passports = repository.GetAll();
        return Ok(passports);
    }

    /// <summary>
    /// Получение информации о паспорте через id
    /// </summary>
    [HttpGet("{id}")]
    public ActionResult<Passport> GetById(int id)
    {
        var passport = repository.GetById(id);
        if (passport == null)
            return NotFound("Паспорта с Таким Id нет");
        return Ok(passport);
    }

    /// <summary>
    /// Добавление нового паспорта
    /// </summary>
    [HttpPost]
    public IActionResult Post([FromBody] PassportDto value)
    {
        var passport = mapper.Map<Passport>(value);
        repository.Post(passport);
        return Ok();
    }

    /// <summary>
    /// Изменение данных через id
    /// </summary>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] PassportDto value)
    {
        var passport = mapper.Map<Passport>(value);
        if (!repository.Put(passport, id))
            return NotFound("Паспорта с Таким Id нет");
        repository.Put(passport, id);
        return Ok(passport);
    }

    /// <summary>
    /// Удаление клиента по id
    /// </summary>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (repository.GetById(id) == null)
            return NotFound("Паспорта с таким Id не существует");
        repository.Delete(id);
        return Ok();
    }
}