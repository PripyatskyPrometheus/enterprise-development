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
    public ActionResult<IEnumerable<PassportGetDto>> GetAll()
    {
        var passports = repository.GetAll();
        return Ok(mapper.Map<IEnumerable<PassportGetDto>>(passports));
    }

    /// <summary>
    /// Получение информации о паспорте через id
    /// </summary>
    [HttpGet("{id}")]
    public ActionResult<PassportGetDto> GetById(int id)
    {
        var passport = repository.GetById(id);
        if (passport == null)
            return NotFound("Паспорт с таким Id не существует");
        return Ok(mapper.Map<PassportGetDto>(passport));
    }

    /// <summary>
    /// Добавление нового паспорта
    /// </summary>
    [HttpPost]
    public IActionResult Post([FromBody] PassportDto value)
    {
        var passport = mapper.Map<Passport>(value);
        return Ok(repository.Post(passport));
    }

    /// <summary>
    /// Изменение данных через id
    /// </summary>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] PassportDto value)
    {
        var passport = mapper.Map<Passport>(value);
        if (repository.GetById(id) == null)
            return NotFound("Паспорта с Таким Id не существует");
        return Ok(repository.Put(passport, id));
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