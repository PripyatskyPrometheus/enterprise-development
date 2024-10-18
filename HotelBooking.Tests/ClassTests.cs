namespace HotelBooking.Tests;

/// <summary>
/// Класс с шестью тестами
/// </summary>
public class Test(HotelBookedData testData) : IClassFixture<HotelBookedData>
{
    private readonly HotelBookedData _testData = testData;

    /// <summary>
    /// Тест на вывод сведений о всех отелях
    /// </summary>
    [Fact]
    public void ReturnAllHotels()
    {
        var countHotels = _testData.Hotels.Select(h => h).ToList();
        Assert.NotEmpty(countHotels);
        Assert.Equal(6, countHotels.Count);
    }

    /// <summary>
    /// Тест на вывод клиентов, проживающих в указанном отеле
    /// </summary>
    [Fact]
    public void ReturnAllClientInHotel()
    {
        var hotelId = _testData.Hotels.Where(h => h.Name == "Hilton").Select(h => h.Id).First();
        var clientInHotel = _testData.BookedRooms
            .OrderBy(r => r.Client.FullName)
            .Where(r => _testData.Rooms
            .Where(r => r.HotelId == hotelId)
            .Select(r => r).ToList().Contains(r.Room))
            .Select(r => r.Client)
            .ToList();
        Assert.NotEmpty(clientInHotel);
        Assert.Equal(4, clientInHotel.Count);
    }

    /// <summary>
    /// Тест на вывод топа 5 отелей по числу бронирования
    /// </summary>
    [Fact]
    public void ReturnTopFiveHotel()
    {
        var topFiveHotel = _testData.BookedRooms
            .GroupBy(r => r.Room.HotelId)
            .Select(r => r.Key)
            .Take(5)
            .Join(_testData.Hotels,
            roomId => roomId,
            hotel => hotel.Id,
            (roomId, hotel) => hotel)
            .OrderBy(r => r.Id)
            .ToList();
        Assert.NotEmpty(topFiveHotel);
        Assert.Equal(5, topFiveHotel.Count);
    }

    /// <summary>
    /// Тест на вывод информации о свободных номерах, в указанном городе
    /// </summary>
    [Fact]
    public void ReturnFreeRooms()
    {
        var city = "Chicago";
        var bookedRoomId = _testData.BookedRooms
            .Select(r => r.Room.Id)
            .ToList();
        var freeRooms = _testData.Rooms
            .Where(r => !bookedRoomId.Contains(r.Id)
                && _testData.Hotels.Any(h => h.City == city && h.Id == r.HotelId)
            )
            .ToList();

        Assert.NotEmpty(freeRooms);
        Assert.Equal(3, freeRooms.Count);
    }

    /// <summary>
    /// Тест на возврат сведений о клиентах, занявших номера на самое продолжительное время
    /// </summary>
    [Fact]
    public void ReturnLongLiversHotel()
    {
        var longerPeriods = _testData.BookedRooms
            .GroupBy(c => c.Client)
            .Select(c => new
            {
                Client = c.Key,
                Total = c.Sum(r => r.PeriodInDays)
            }).Max(c => c.Total);

        var clientWithLongerPer = _testData.BookedRooms
            .GroupBy(c => c.Client)
            .Select(c => new
            {
                Client = c.Key,
                Total = c.Sum(r => r.PeriodInDays)
            }).Where(c => c.Total == longerPeriods).Select(c => c.Client).ToList();
        Assert.NotEmpty(clientWithLongerPer);
        _ = Assert.Single(clientWithLongerPer);
    }

    /// <summary>
    /// Тест на вывод сведений о минимальной, максимальной и средней ценах за комнаты в каждом отеле
    /// </summary>
    [Fact]
    public void MinAvgMaxDecimalInHotel()
    {
        var hotels = _testData.Hotels.Select(h => h);

        var hotelDecimals = hotels.Select(h => new
        {
            Hotel = _testData.Hotels.Where(hotel => hotel.Id == h.Id).Select(hotel => hotel),
            Min = _testData.Rooms.Where(r => r.HotelId == h.Id).Select(r => r).ToList().Min(rm => rm.Cost),
            Max = _testData.Rooms.Where(r => r.HotelId == h.Id).Select(r => r).ToList().Max(rm => rm.Cost),
            Avg = _testData.Rooms.Where(r => r.HotelId == h.Id).Select(r => r).ToList().Average(rm => rm.Cost)
        }).ToList();
        Assert.NotEmpty(hotelDecimals);
        Assert.Equal(6, hotelDecimals.Count);
        Assert.Equal(3000, hotelDecimals[0].Min);
        Assert.Equal(4500, hotelDecimals[0].Avg);
        Assert.Equal(6000, hotelDecimals[0].Max);
    }
}