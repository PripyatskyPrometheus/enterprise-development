using HotelBooking.API.Dto;
using HotelBooking.API.Service;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.API.Controllers;

/// <summary>
/// Контроллер для управления отелями
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class HotelController(HotelService service) : ControllerBase
{
    /// <summary>
    /// Получить все отели
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public ActionResult<IEnumerable<HotelGetDto>> GetAll()
    {
        var hotels = service.GetAll();
        return Ok(hotels);
    }

    /// <summary>
    /// Получить отель по Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<HotelGetDto> GetById(int id)
    {
        var hotel = service.GetById(id);
        if (hotel == null)
            return NotFound($"Отель с таким id {id} не найден.");
        return Ok(hotel);
    }

    /// <summary>
    /// Добавить новый отель
    /// </summary>
    /// <param name="value"></param>
    [HttpPost]
    public ActionResult<object> Post([FromBody] HotelPostDto postDto)
    {
        var newId = service.Post(postDto);
        return Ok(new { id = newId });
    }

    /// <summary>
    /// Изменияем старый отель
    /// </summary>
    /// <param name="id"></param>
    /// <param name="value"></param>
    [HttpPut("{id}")]
    public ActionResult<HotelGetDto> Put(int id, [FromBody] HotelPostDto putDto)
    {
        var updatedHotel = service.Put(id, putDto);
        if (updatedHotel == null)
            return NotFound($"Отель с таким id {id} не найден."); 
        return Ok(updatedHotel); 
    }

    /// <summary>
    /// Удаляем отель
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var isDeleted = service.Delete(id);
        if (!isDeleted)
            return NotFound($"Отель с таким id {id} не найден."); 

        return Ok();
    }
}
