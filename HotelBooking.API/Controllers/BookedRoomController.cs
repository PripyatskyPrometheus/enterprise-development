using Microsoft.AspNetCore.Mvc;
using HotelBooking.API.Dto;
using HotelBooking.API.Repository;
using HotelBooking.Domain.Entity;
using AutoMapper;

namespace HotelBooking.API.Controllers;

/// <summary>
/// Контроллер для работы с забранированными номерами.
/// </summary>
[Route("[controller]")]
[ApiController]
public class BookedRoomController(IRepository<BookedRoom> repository, 
    IRepository<Room> repositoryRoom, 
    IRepository<Client> repositoryClient,
    IRepository<Hotel> repositoryHotel,
    IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Получение информации о всех забронированных номерах.
    /// </summary>
    [HttpGet]
    public ActionResult<IEnumerable<BookedRoom>> GetAll()
    {
        var bookedRoom = repository.GetAll();
        return Ok(bookedRoom);
    }

    /// <summary>
    /// Получение информации по id о комнате
    /// </summary>
    [HttpGet("{id}")]
    public ActionResult<BookedRoom> GetById(int id)
    {
        var bookedRoom = repository.GetById(id);
        if (bookedRoom == null)
            return NotFound("Брони с таким Id не существует");
        return Ok(bookedRoom);
    }

    /// <summary>
    /// Добавление новой брони
    /// </summary>
    [HttpPost]
    public IActionResult Post([FromBody] BookedRoomDto value,
        ClientDto value1, RoomDto value2)
    {
        if (repositoryRoom.GetById(value.RoomId) == null || repositoryClient.GetById(value.ClientId) == null)
            NotFound();
        var bookedRoom = mapper.Map<BookedRoom>(value);
        bookedRoom.Client = mapper.Map<Client>(value1);
        bookedRoom.Room = mapper.Map<Room>(value2);
        bookedRoom.DateEvection = DateOnly.ParseExact(value.DateEvection, "yyyy-mm-dd");
        bookedRoom.DateArrival = DateOnly.ParseExact(value.DateArrival, "yyyy-mm-dd");
        if (bookedRoom.Client == null)
            return NotFound("Клиент не найден по заданному id");
        if (bookedRoom.Room == null)
            return NotFound("Комната по заданному id не найдена");
        repository.Post(bookedRoom);
        return Ok();
    }

    /// <summary>
    /// Изменение в брони
    /// </summary>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] BookedRoomDto value,
        ClientDto value1, RoomDto value2)
    {
        if (repository.GetById(id) == null)
            return NotFound("Брони с таким Id не сущесвует");
        if (repositoryRoom.GetById(value.RoomId) == null || repositoryClient.GetById(value.ClientId) == null)
            NotFound();
        var bookedRoom = mapper.Map<BookedRoom>(value);
        bookedRoom.Client = mapper.Map<Client>(value1);
        bookedRoom.Room = mapper.Map<Room>(value2);
        bookedRoom.DateEvection = DateOnly.ParseExact(value.DateEvection, "yyyy-mm-dd");
        bookedRoom.DateArrival = DateOnly.ParseExact(value.DateArrival, "yyyy-mm-dd");
        repository.Put(bookedRoom, id);
        return Ok();
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
    /// Возвращает всех клиентов отеля
    /// </summary>
    /// <param name="name"></param>
    /// <returns>Список клиентов</returns>
    [HttpGet("get_all_client_in_hotel/{name}")]
    public ActionResult<IEnumerable<Client>> GetAllClientInHotel(string name)
    {
        var hotelId = GetHotelIdByName(name);
        if (hotelId == null)
            return NotFound("Отель с таким названием не найден");
        var roomsInHotel = GetRoomsInHotel([hotelId]);
        if (roomsInHotel == null)
            return NotFound("Комнаты для данного отеля не найдены");
        return Ok(ReturnAllClientInHotel(hotelId, roomsInHotel));
    }

    /// <summary>
    /// Возвращает все свободные комнаты в выбранном городе
    /// </summary>
    /// <param name="city"></param>
    /// <returns>Список свободных комнат</returns>
    [HttpGet("get_all_free_rooms/{city}")]
    public ActionResult<IEnumerable<Room>> GetFreeRoomInCity(string city)
    {
        var hotelsInCity = GetHotelsByCity(city);
        if (hotelsInCity.Count() == 0)
            return NotFound("Отели в выбранном городе не найдены");
        var roomsInCity = GetRoomsInHotel(hotelsInCity);
        return Ok(GetFreeRoomInCity(roomsInCity));
    }

    /// <summary>
    /// Возвращает клиентов с наибольшим временем проживания в отелях
    /// </summary>
    /// <returns>Список клиентов</returns>
    [HttpGet("get_clients_with_the_longest_hotel_stays")]
    public ActionResult<IEnumerable<M>> GetLongLiversClient()
    {
        return Ok(GetLongLiversHotel());
    }

    [NonAction]
    public IEnumerable<Client> ReturnAllClientInHotel(int hotelId, IEnumerable<Room> rooms)
    {
        var clientInHotel = repository.GetAll()
            .OrderBy(r => r.Client.FullName)
            .Where(r => rooms.ToList().Contains(r.Room))
            .Select(r => r.Client)
            .ToList();
        return clientInHotel;
    }

    [NonAction]
    public IEnumerable<Room> GetFreeRoomInCity(IEnumerable<Room> rooms)
    {
        var reservRooms = repository.GetAll().Where(r => rooms.Contains(r.Room) &&
        r.DateEvection == null).Select(r => r.Room);
        var freeRooms = rooms.Where(r => !reservRooms.Contains(r)).Select(r => r);
        return freeRooms;
    }

    [NonAction]
    public IEnumerable<M> GetLongLiversHotel()
    {
        var longerPeriods = repository.GetAll()
            .GroupBy(c => c.Client)
            .Select(c => new
            {
                Client = c.Key,
                Total = c.Sum(r => r.PeriodInDays)
            }).Max(c => c.Total);

        var clientWithLongerPer = repository.GetAll()
            .GroupBy(c => c.Client)
            .Select(c => new
            {
                Client = c.Key,
                Total = c.Sum(r => r.PeriodInDays)
            }).Where(c => c.Total == longerPeriods).Select(c => new M(c.Client, c.Total)).ToList();
        return clientWithLongerPer;
    }

    [NonAction]
    public int GetHotelIdByName(string name)
    {
        return repositoryHotel.GetAll().Where(h => h.Name == name).Select(h => h.Id).First();
    }

    [NonAction]
    public IEnumerable<int> GetHotelsByCity(string city) => repositoryHotel.GetAll().Where(h => h.City == city).Select(h => h.Id);

    [NonAction]
    public IEnumerable<Room> GetRoomsInHotel(IEnumerable<int> id) => repositoryRoom.GetAll().Where(r => id.Contains(r.HotelId)).Select(r => r);
}