using HotelBooking.Domain.Enity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelBooking.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HotelController : ControllerBase
{
    // GET: api/<HotelController>
    [HttpGet]
    public IEnumerable<Hotel> Get()
    {
        return
        [
            new Hotel { Name = "ff", Address = "ff", City = "ff", Id = 1 }
        ];
    }

    // GET api/<HotelController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<HotelController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<HotelController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<HotelController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
