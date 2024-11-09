using HotelBooking.API.Dto;
using Microsoft.AspNetCore.Mvc;
using HotelBooking.Domain.Entity;
using HotelBooking.API.Repository;
using AutoMapper;


namespace HotelBooking.API.Controllers;

/// <summary>
/// Контроллер для управления отелями
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class HotelController(IRepository<Hotel> repository, IRepository<BookedRoom> repositoryBookedRoom,
    IRepository<Room> repositoryRoom, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Получить все отели
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public ActionResult<IEnumerable<Hotel>> GetAll()
    {
        var hotels = repository.GetAll();
        return Ok(hotels);
    }

    /// <summary>
    /// Получить отель по Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<Hotel> GetById(int id)
    {
        var hotel = repository.GetById(id);
        if (hotel == null)
            return NotFound("Отеля с таким Id не существует");
        return Ok(hotel);
    }

    /// <summary>
    /// Добавить новый отель
    /// </summary>
    /// <param name="value"></param>
    [HttpPost]
    public IActionResult Post([FromBody] HotelDto value)
    {
        var hotel = mapper.Map<Hotel>(value);
        repository.Post(hotel);
        return Ok();
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
        repository.Put(hotel, id);
        return Ok();
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
        return Ok(GetTopFiveHotelById(GetTopFiveHotelId()));
    }

    /// <summary>
    /// Запрос возвращающий минимальную максимальную и среднюю цену комнат для каждого отеля
    /// </summary>
    /// <returns>структура {отель, минимальная цена комнаты, максимальная цена, средняя цена}</returns>
    [HttpGet("cost_info_about_hotels")]
    public ActionResult<IEnumerable<T>> GetTop()
    {
        return Ok(GetMaxAvgMinForHotels(repositoryRoom.GetAll()));
    }

    [NonAction]
    public int GetCountHotels() => repository.GetAll().Count();

    [NonAction]
    public IEnumerable<Hotel> GetTopFiveHotelById(IEnumerable<int> id)
    {
        return repository.GetAll().Where(h => id.Contains(h.Id));
    }

    [NonAction]
    public IEnumerable<T> GetMaxAvgMinForHotels(IEnumerable<Room> rooms)
    {
        var hotelCosts = repository.GetAll().Select(h => new T
        (
            (repository.GetAll().Where(hotel => hotel.Id == h.Id).Select(hotel => hotel)),
            rooms.Where(r => r.HotelId == h.Id).Select(r => r).ToList().Min(rm => rm.Cost),
            rooms.Where(r => r.HotelId == h.Id).Select(r => r).ToList().Max(rm => rm.Cost),
            rooms.Where(r => r.HotelId == h.Id).Select(r => r).ToList().Average(rm => rm.Cost)
        )).AsEnumerable();

        return hotelCosts;
    }

    [NonAction]
    public IEnumerable<int> GetTopFiveHotelId() => repositoryBookedRoom.GetAll().GroupBy(r => r.Room.HotelId).Select(r => r.Key).Take(5);
}