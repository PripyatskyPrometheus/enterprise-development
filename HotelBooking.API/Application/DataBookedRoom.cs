using HotelBooking.Domain.Entity;

namespace HotelBooking.API.Application;

/// <summary>
/// Преступление против здравого смысла:))
/// </summary>
public class DataBookedRoom(Client client, int total)
{
    public Client Client { get; set; } = client;
    public int Total { get; set; } = total;
}