﻿using HotelBooking.API.Dto;
using Microsoft.AspNetCore.Mvc;
using HotelBooking.Domain.Entity;
using HotelBooking.API.Repository;
using AutoMapper;
using HotelBooking.API.Services;
using HotelBooking.API.Application;

namespace HotelBooking.API.Controllers;

/// <summary>
/// Контроллер для управления отелями
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class HotelController(IRepository<Hotel> repository, IRepository<Room> repositoryRoom, 
    IHotelService service, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Получить все отели
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public ActionResult<IEnumerable<HotelDto>> GetAll()
    {
        var hotels = repository.GetAll();
        return Ok(mapper.Map<IEnumerable<HotelDto>>(hotels));
    }

    /// <summary>
    /// Получить отель по Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<HotelDto> GetById(int id)
    {
        var hotel = repository.GetById(id);
        if (hotel == null)
            return NotFound("Отеля с таким Id не существует");
        return Ok(mapper.Map<IEnumerable<HotelDto>>(hotel));
    }

    /// <summary>
    /// Добавить новый отель
    /// </summary>
    /// <param name="value"></param>
    [HttpPost]
    public IActionResult Post([FromBody] HotelDto value)
    {
        var hotel = mapper.Map<Hotel>(value);
        return Ok(repository.Post(hotel));
    }

    /// <summary>
    /// Изменияем старый отель
    /// </summary>
    /// <param name="id"></param>
    /// <param name="value"></param>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] HotelDto value)
    {
        if (repository.GetById(id) == null) 
            return NotFound("Отеля с таким Id не существует"); 
        var hotel = mapper.Map<Hotel>(value);
        return Ok(repository.Put(hotel, id));
    }

    /// <summary>
    /// Удаляем отель
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (repository.GetById(id) == null)
            return NotFound("Отеля с таким Id не существует"); 
        repository.Delete(id);
        return Ok();
    }

    /// <summary>
    /// Запрос возвращающий топ 5 отелей по количеству бронирований
    /// </summary>
    [HttpGet("top_5_hotels_by_number_of_bookings")]
    public ActionResult<IEnumerable<Hotel>> GetTopFiveHotels()
    {
        return Ok(service.GetTopFiveHotelById(service.GetTopFiveHotelId()));
    }

    /// <summary>
    /// Запрос возвращающий минимальную максимальную и среднюю цену комнат для каждого отеля
    /// </summary>
    /// <returns>структура {отель, минимальная цена комнаты, максимальная цена, средняя цена}</returns>
    [HttpGet("cost_info_about_hotels")]
    public ActionResult<IEnumerable<DataHotelMinMaxAvgCost>> GetTop()
    {
        return Ok(service.GetMaxAvgMinForHotels(repositoryRoom.GetAll()));
    }
}