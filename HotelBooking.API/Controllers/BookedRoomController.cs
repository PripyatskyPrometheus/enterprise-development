using Microsoft.AspNetCore.Mvc;
using HotelBooking.API.Dto;
using HotelBooking.API.Repository;
using HotelBooking.API.Services;
using HotelBooking.Domain.Entity;
using AutoMapper;
using HotelBooking.API.Application;

namespace HotelBooking.API.Controllers;

/// <summary>
/// Контроллер для работы с забранированными номерами.
/// </summary>
[Route("[controller]")]
[ApiController]
public class BookedRoomController(IRepository<BookedRoom> repository,
    IRepository<Room> repositoryRoom,
    IRepository<Client> repositoryClient,
    IBookedRoomService service,
    IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Получение информации о всех забронированных номерах.
    /// </summary>
    [HttpGet]
    public ActionResult<IEnumerable<BookedRoomDto>> GetAll()
    {
        var bookedRoom = repository.GetAll();
        return Ok(mapper.Map<IEnumerable<BookedRoomDto>>(bookedRoom));
    }

    /// <summary>
    /// Получение информации по id о комнате
    /// </summary>
    [HttpGet("{id}")]
    public ActionResult<BookedRoomDto> GetById(int id)
    {
        var bookedRoom = repository.GetById(id);
        if (bookedRoom == null)
            return NotFound("Брони с таким Id не существует");
        return Ok(mapper.Map<IEnumerable<BookedRoomDto>>(bookedRoom));
    }

    /// <summary>
    /// Добавление новой брони
    /// </summary>
    [HttpPost]
    public IActionResult Post([FromBody] BookedRoomDto bookedRoomDto)
    {
        var bookedRoom = mapper.Map<BookedRoom>(bookedRoomDto);
        var client = repositoryClient.GetById(bookedRoomDto.ClientId);
        var room = repositoryRoom.GetById(bookedRoomDto.RoomId);
        if (client == null)
            return NotFound("Клиента с таким Id не существует");
        bookedRoom.Client = client;
        if (room == null)
            return NotFound("Номера с таким Id не существует");
        bookedRoom.Room = room;
        bookedRoom.DateEvection = DateOnly.ParseExact(bookedRoomDto.DateEvection, "yyyy-mm-dd");
        bookedRoom.DateArrival = DateOnly.ParseExact(bookedRoomDto.DateArrival, "yyyy-mm-dd");
        return Ok(repository.Post(bookedRoom));
    }

    /// <summary>
    /// Изменение в брони
    /// </summary>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] BookedRoomDto bookedRoomDto)
    {
        if (repository.GetById(id) == null)
            return NotFound("Брони с таким Id не существует");
        var bookedRoom = mapper.Map<BookedRoom>(bookedRoomDto);
        var client = repositoryClient.GetById(bookedRoomDto.ClientId);
        var room = repositoryRoom.GetById(bookedRoomDto.RoomId);
        if (client == null)
            return NotFound("Клиента с таким Id не существует");
        bookedRoom.Client = client;
        if (room == null)
            return NotFound("Номера с таким Id не существует");
        bookedRoom.Room = room;
        bookedRoom.DateEvection = DateOnly.ParseExact(bookedRoomDto.DateEvection, "yyyy-mm-dd");
        bookedRoom.DateArrival = DateOnly.ParseExact(bookedRoomDto.DateArrival, "yyyy-mm-dd");
        return Ok(repository.Put(bookedRoom, id));
    }

    /// <summary>
    /// Удаление брони по Id
    /// </summary>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (repository.GetById(id) == null)
            return NotFound("Брони с таким Id не существует");
        repository.Delete(id);
        return Ok();
    }

    /// <summary>
    /// Возвращает всех клиентов в отеле
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("get_all_client_in_hotel/{id}")]
    public ActionResult<IEnumerable<Client>> GetAllClientInHotel(int id)
    {
        var hotel = service.GetHotelById(id);
        if (hotel == null)
            return NotFound("Отеля с таким названием не существует");
        var roomsInHotel = service.GetRoomsInHotel([id]);
        if (roomsInHotel == null)
            return NotFound("Номера для данного отеля не найдены");
        return Ok(service.ReturnAllClientInHotel(id, roomsInHotel));
    }

    /// <summary>
    /// Возвращает все свободные номера в выбранном городе
    /// </summary>
    /// <param name="city"></param>
    /// <returns>Список свободных комнат</returns>
    [HttpGet("get_all_free_rooms/{city}")]
    public ActionResult<IEnumerable<RoomDto>> GetFreeRoomInCity(string city)
    {
        var hotelsInCity = service.GetHotelsByCity(city);
        if (hotelsInCity.Count() == 0)
            return NotFound();
        var roomsInCity = service.GetRoomsInHotel(hotelsInCity);
        var freeRooms = service.GetFreeRoomInCity(roomsInCity);
        return Ok(mapper.Map<IEnumerable<RoomDto>>(freeRooms));
    }

    /// <summary>
    /// Возвращает клиентов с наибольшим временем проживания в отелях
    /// </summary>
    /// <returns>Список клиентов</returns>
    [HttpGet("get_clients_with_the_longest_hotel_stays")]
    public ActionResult<IEnumerable<DataBookedRoom>> GetLongLiversClient()
    {
        return Ok(service.GetLongLiversHotel());
    }
}