using HotelBooking.Domain.Entity;

namespace HotelBooking.API.Application;

public class DataBookedRoom(Client client, int total)
{
    public Client Client { get; set; } = client;

    public int Total { get; set; } = total;
}