using HotelArmor.Domain;
using System.Linq;
using System.Runtime.InteropServices;
using Xunit.Sdk;

namespace HotelArmor.Tests;

public class ClassTests (HotelArmorData data) : IClassFixture<HotelBookingDetailsData> {
    private readonly HotelArmorData data_a = data;

    [Fact]
    public void ReturnAllHotels() {
        var countHotels = data_a.Hotels.Select(h => h.Name).ToList();
        var expectedNumber = 3;
        Assert.Equal(expectedNumber, countHotels.Count);
    }

    [Fact]
    public void ReturnAllClientInHotel() {
        var expecteClients = new List<Client> {
            data_a.Clients[0],
            data_a.Clients[1],
            data_a.Clients[2],
            data_a.Clients[3],
            data_a.Clients[4],
        };

        var hotelId = data_a.Hotels.Where(h => h.Name == "Россия").Select(h => h.ID).First();
        var clientInHotel = data_a.ArmoredRooms
            .OrderBy(r => r.Client.FullName)
            .Where(r => data_a.Rooms
            .Where(r => r.HotelID == hotelId)
            .Select(r => r).ToList().Contains(r.Room))
            .Select(r => r.Client)
            .ToList();
        Assert.Equal(clientInHotel, expecteClients);
    }

    [Fact]
    public void ReturnTopFiveHotel() {
        var expecteHhotels = new List<Hotel> {
            data_a.Hotels[0],
            data_a.Hotels[1],
            data_a.Hotels[2],
            data_a.Hotels[3],
            data_a.Hotels[5]
        };

        var topFiveHotel = data_a.ArmoredRooms
            .GroupBy(r => r.Room.HotelID)
            .Select(r => r.Key)
            .Take(5)
            .Join(data_a.Hotels,
            roomId => roomId,
            hotel => hotel.ID,
            (roomId, hotel) => hotel)
            .OrderBy(r => r.ID)
            .ToList();
        Assert.Equal(expecteHhotels, topFiveHotel);

    }

    [Fact]
    public void ReturnFreeRooms() {
        var expectedRooms = new List<Room> {
            data_a.Rooms[0],
            data_a.Rooms[2],
            data_a.Rooms[4],
        };

        var city = "Москва";
        var freeRooms = data_a.ArmoredRooms
            .Where(r => !data_a.ArmoredRooms.Where(r => r.DateEvection == DateOnly.ParseExact("0001-01-01", "yyyy-mm-dd"))
                .Select(r => r).ToList().Contains(r)
                &&
                data_a.Rooms.Where(r => (data_a.Hotels.Where(h => h.City == city).Select(h => h.ID).ToList()).Contains(r.HotelID))
                .Select(h => h).ToList().Contains(r.Room)
                ).Select(r => r.Room).ToList();
        Assert.Equal(expectedRooms, freeRooms);
    }

    [Fact]
    public void ReturnLongLiversHotel() {

        var expecteClients = new List<Client> {
            data_a.Clients[0],
            data_a.Clients[1],
            data_a.Clients[2],
            data_a.Clients[3],
            data_a.Clients[4]
        };

        var longerPeriods = data_a.ArmoredRooms
            .GroupBy(c => c.Client)
            .Select(c => new {
                Client = c.Key,
                Total = c.Sum(r => r.Period)
            }).Max(c => c.Total);

        var clientWithLongerPer = data_a.ArmoredRooms
            .GroupBy(c => c.Client)
            .Select(c => new {
                Client = c.Key,
                Total = c.Sum(r => r.Period)
            }).Where(c => c.Total == longerPeriods).Select(c => c.Client).ToList();

        Assert.Equal(expecteClients, clientWithLongerPer);
    }

    [Fact]
    public void MinAvgMaxCostInHotel() {
        var hotels = data_a.Hotels.Select(h => h);
         
        var hotelCosts = hotels.Select(h => new {
            Hotel = (data_a.Hotels.Where(hotel => hotel.ID == h.ID).Select(hotel => hotel)),
            Min = data_a.Rooms.Where(r => r.HotelID == h.ID).Select(r => r).ToList().Min(rm => rm.Cost),
            Max = data_a.Rooms.Where(r => r.HotelID == h.ID).Select(r => r).ToList().Max(rm => rm.Cost),
            Avg = data_a.Rooms.Where(r => r.HotelID == h.ID).Select(r => r).ToList().Average(rm => rm.Cost)
        }).ToList();

        Assert.Equal(3000, hotelCosts[0].Min);
        Assert.Equal(4500.00, hotelCosts[0].Avg, 2);
        Assert.Equal(6000, hotelCosts[0].Max);
    }
}
