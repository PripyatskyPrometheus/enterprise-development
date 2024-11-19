using Microsoft.AspNetCore.Mvc;
using HotelBooking.API.Dto;
using HotelBooking.API.Repository;
using HotelBooking.Domain.Entity;
using AutoMapper;

namespace HotelBooking.API.Controllers;

/// <summary>
/// Контроллер для работы с номерами
/// </summary>
[Route("[controller]")]
[ApiController]
public class RoomController(IRepository<Room> repository, IRepository<RoomType> repositoryRoomType, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Получение информации об о всех номерах
    /// </summary>
    [HttpGet]
    public ActionResult<IEnumerable<RoomDto>> GetAll()
    {
        var room = repository.GetAll();
        return Ok(room);
    }

    /// <summary>
    /// Получение информации о номере через id
    /// </summary>
    [HttpGet("{id}")]
    public ActionResult<RoomDto> GetById(int id)
    {
        var room = repository.GetById(id);
        if (room == null)
            return NotFound("Номера с таким Id не существует");
        return Ok(room);
    }

    /// <summary>
    /// Добавление нового номера
    /// </summary>
    [HttpPost]
    public ActionResult Post([FromBody] RoomDto roomDto)
    {   
        var room = mapper.Map<Room>(roomDto);
        var roomType = repositoryRoomType.GetById(roomDto.TypeId);
        if (roomType == null)
            NotFound("Типа с таким Id не существует");
        return Ok(repository.Post(room));
    }

    /// <summary>
    /// Изменение данных о номере через id
    /// </summary>
    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] RoomDto roomDto)
    {
        if (repository.GetById(id) == null)
            NotFound("Номера с таким Id не существует");
        var room = mapper.Map<Room>(roomDto);
        var roomType = repositoryRoomType.GetById(roomDto.TypeId);
        if (roomType == null)
            NotFound("Типа с таким Id не существует");
        repository.Put(room, id);
        return Ok(room);
    }

    /// <summary>
    /// Удаление номера по id
    /// </summary>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (repository.GetById(id) == null)
            return NotFound("Номера с таким Id не существует");
        repository.Delete(id);
        return Ok();
    }
}