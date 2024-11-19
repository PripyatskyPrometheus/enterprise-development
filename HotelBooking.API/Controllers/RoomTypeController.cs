using Microsoft.AspNetCore.Mvc;
using HotelBooking.API.Dto;
using HotelBooking.API.Repository;
using HotelBooking.Domain.Entity;
using AutoMapper;

namespace HotelBooking.API.Controllers;

/// <summary>
/// Контроллер для работы с типами номеров
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class RoomTypeController(IRepository<RoomType> repository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Получение информации об о всех типах
    /// </summary>
    [HttpGet]
    public ActionResult<IEnumerable<RoomType>> GetAll()
    {
        var roomType = repository.GetAll();
        return Ok(mapper.Map<IEnumerable<RoomTypeDto>>(roomType));
    }

    /// <summary>
    /// Получение информации о номере через id
    /// </summary>
    [HttpGet("{id}")]
    public ActionResult<RoomTypeDto> GetById(int id)
    {
        var roomType = repository.GetById(id);
        if (roomType == null)
            return NotFound("Типа с таким Id не существует");
        return Ok(mapper.Map<IEnumerable<RoomTypeDto>>(roomType));
    }

    /// <summary>
    /// Добавление нового номера
    /// </summary>
    [HttpPost]
    public ActionResult Post([FromBody] RoomTypeDto roomTypeDto)
    {
        var roomType = mapper.Map<RoomType>(roomTypeDto);
        return Ok(repository.Post(roomType));
    }

    /// <summary>
    /// Изменение данных о номере через id
    /// </summary>
    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] RoomTypeDto roomTypeDto)
    {
        if (repository.GetById(id) == null) 
            return NotFound("Типа с таким Id не существует");
        var roomType = mapper.Map<RoomType>(roomTypeDto);
        return Ok(repository.Put(roomType, id));
    }

    /// <summary>
    /// Удаление типа по id
    /// </summary>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (repository.GetById(id) ==null)
            return NotFound("Типа с таким Id не существует");
         repository.Delete(id);
        return Ok();
    }
}