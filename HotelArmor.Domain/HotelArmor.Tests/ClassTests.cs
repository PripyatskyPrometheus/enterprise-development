using HotelArmor.Domain;
namespace HotelArmor.Tests;

/// <summary>
/// Класс с шестью тестами
/// </summary>
public class Test(HotelArmorData data) : IClassFixture<HotelArmorData> {
    private readonly HotelArmorData data_a = data;

    /// <summary>
    /// Тест на вывод сведений о всех отелях
    /// </summary>
    [Fact]
    public void ReturnAllHotels() {
        var countHotels = data_a.Hotels.Select(h => h).ToList();
        var expectedHotels = new List<Hotel> {
            data_a.Hotels[0],
            data_a.Hotels[1],
            data_a.Hotels[2],
            data_a.Hotels[3],
            data_a.Hotels[4],
            data_a.Hotels[5]
        };
        Assert.Equal(expectedHotels, countHotels);
    }

    /// <summary>
    /// Тест на вывод клиентов, проживающих в указанном отеле
    /// </summary>
    [Fact]
    public void ReturnAllClientInHotel() {
        var expecteClients = new List<Client> {
            data_a.Clients[9],
            data_a.Clients[10],
            data_a.Clients[8],
            data_a.Clients[11]
        };
        var hotelId = data_a.Hotels.Where(h => h.Name == "Hilton").Select(h => h.ID).First();
        var clientInHotel = data_a.ArmoredRooms
            .OrderBy(r => r.Client.FullName)
            .Where(r => data_a.Rooms
            .Where(r => r.HotelID == hotelId)
            .Select(r => r).ToList().Contains(r.Room))
            .Select(r => r.Client)
            .ToList();
        Assert.Equal(clientInHotel, expecteClients);
    }

    /// <summary>
    /// Тест на вывод топа 5 отелей по числу бронирования
    /// </summary>
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

    /// <summary>
    /// Тест на вывод информации о свободных номерах, в указанном городе
    /// </summary>
    [Fact]
    public void ReturnFreeRooms() {
        var expectedRooms = new List<Room> { 
            data_a.Rooms[4] 
        };
        var city = "New York";
        var bookedRoomIds = data_a.ArmoredRooms
           .Where(r => r.DateEvection == DateOnly.ParseExact("0001-01-01", "yyyy-mm-dd"))
           .Select(r => r.Room.ID)
           .ToList();

        var freeRooms = data_a.Rooms
            .Where(r => bookedRoomIds.Contains(r.ID)
                && data_a.Hotels.Any(h => h.City == city && h.ID == r.HotelID)
            )
            .ToList();

        Assert.Equal(expectedRooms, freeRooms);
    }

    /// <summary>
    /// Тест на возврат сведений о клиентах, занявших номера на самое продолжительное время
    /// </summary>
    [Fact]
    public void ReturnLongLiversHotel() {
        var expecteClients = new List<Client> {
            data_a.Clients[4],
            data_a.Clients[13]
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

    /// <summary>
    /// Тест на вывод сведений о минимальной, максимальной и средней ценах за комнаты в каждом отеле
    /// </summary>
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
        Assert.Equal(4500, hotelCosts[0].Avg);
        Assert.Equal(6000, hotelCosts[0].Max);
    }
}