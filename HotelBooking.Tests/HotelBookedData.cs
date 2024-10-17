using HotelBooking.Domain;
namespace HotelBooking.Tests;

public class HotelBookedData 
{

    public List<RoomType> TypesRoom = 
    [
        new(){ Id = 1,  NameRoom = "Luxary"},
        new(){ Id = 2,  NameRoom = "Economy"},
        new(){ Id = 3,  NameRoom = "Comfort"}
    ];

    public List<Passport> Passports = 
        [
        new(){Id = 1, Series = 6313, Number = 123421},
        new(){Id = 2, Series = 1234, Number = 567890 },
        new(){Id = 3, Series = 5678, Number = 987654},
        new(){Id = 4, Series = 7890, Number = 234567},
        new(){Id = 5, Series = 3456, Number = 876543},
        new(){Id = 6, Series = 9012, Number = 345678},
        new(){Id = 7, Series = 2345, Number = 765432},
        new(){Id = 8, Series = 6789, Number = 654321},
        new(){Id = 9, Series = 4321, Number = 123456},
        new(){Id = 10, Series = 0987, Number = 456789},
        new(){Id = 11, Series = 8765, Number = 789012 },
        new(){Id = 12, Series = 6543, Number = 345678},
        new(){Id = 13, Series = 2109, Number = 890123},
        new(){Id = 14, Series = 8765, Number = 456789},
        new(){Id = 15, Series = 5432, Number = 321098},
        new(){Id = 16, Series = 6789, Number = 901234},
        new(){Id = 17, Series = 1234, Number = 345678},
        new(){Id = 18, Series = 9876, Number = 567890},
        new(){Id = 19, Series = 3456, Number = 789012},
        new(){Id = 20, Series = 6789, Number = 890123},
        ];

    public List<Room> Rooms;
    public List<Hotel> Hotels;
    public List<Client> Clients;
    public List<BookedRoom> BookedRooms;

    public HotelBookedData() 
    {
        Clients = 
            [
            new() 
            {
                Id = 1,
                FullName = "Иванов Иван Иванович",
                PassportData = Passports[0],
                BirthOfDay =  new DateOnly(2003, 1, 1)
            },
            new() 
            {
                Id = 2,
                FullName = "Петров Петр Петрович",
                PassportData = Passports[1],
                BirthOfDay =  new DateOnly(2002, 5, 15 )
            },
            new() 
            {
                Id = 3,
                FullName = "Сидоров Сидор Сидорович",
                PassportData = Passports[2],
                BirthOfDay =  new DateOnly(2001, 9, 20 )
            },
            new() 
            {
                Id = 4,
                FullName = "Кузнецов Алексей Владимирович",
                PassportData = Passports[3],
                BirthOfDay =  new DateOnly(2004, 3, 10)
            },
            new() 
            {
                Id = 5,
                FullName = "Смирнов Дмитрий Александрович",
                PassportData = Passports[4],
                BirthOfDay =  new DateOnly(2000, 8, 27)
            },
            new() 
            {
                Id = 6,
                FullName = "Козлов Игорь Сергеевич",
                PassportData = Passports[5],
                BirthOfDay =  new DateOnly(2005, 2, 18)
            },
            new() 
            {
                Id = 7,
                FullName = "Лебедев Владислав Денисович",
                PassportData = Passports[6],
                BirthOfDay =  new DateOnly(2003, 10, 05)
            },
            new() 
            {
                Id = 8,
                FullName = "Никитин Андрей Алексеевич",
                PassportData = Passports[7],
                BirthOfDay =  new DateOnly(2001, 12, 30)
            },
            new() 
            {
                Id = 9,
                FullName = "Морозов Кирилл Васильевич",
                PassportData = Passports[8],
                BirthOfDay =  new DateOnly(2000, 4, 09)
            },
            new() 
            {
                Id = 10,
                FullName = "Андреев Евгений Дмитриевич",
                PassportData = Passports[9],
               BirthOfDay =  new DateOnly(2002, 7, 14)
            },
            new() 
            {
                Id = 11,
                FullName = "Богданова Елена Игоревна",
                PassportData = Passports[10],
                BirthOfDay =  new DateOnly(2004, 11, 21)
            },
            new() 
            {
                Id = 12,
                FullName = "Семенов Максим Павлович",
                PassportData = Passports[11],
                BirthOfDay =  new DateOnly(2003, 6, 2)
            },
            new() 
            {
                Id = 13,
                FullName = "Козлова Виктория Алексеевна",
                PassportData = Passports[12],
                BirthOfDay =  new DateOnly(2000, 12, 15)
            },
            new() 
            {
                Id = 14,
                FullName = "Новикова Анастасия Сергеевна",
                PassportData = Passports[13],
                BirthOfDay =  new DateOnly(2001, 3, 25)
            },
            new() 
            {
                Id = 15,
                FullName = "Гаврилова Ольга Владимировна",
                PassportData = Passports[14],
                BirthOfDay =  new DateOnly(2002, 9, 12)
            },
            new() 
            {
                Id = 16,
                FullName = "Белякова Светлана Ивановна",
                PassportData = Passports[15],
                BirthOfDay =  new DateOnly(2004, 7, 3)
            },
            new() 
            {
                Id = 17,
                FullName = "Федорова Екатерина Дмитриевна",
                PassportData = Passports[16],
                BirthOfDay =  new DateOnly(2003, 4, 28)
            },
            new() 
            {
                Id = 18,
                FullName = "Алексеева Ирина Александровна",
                PassportData = Passports[17],
                BirthOfDay =  new DateOnly(2001, 10, 17)
            },
            new() 
            {
                Id = 19,
                FullName = "Тихонова Татьяна Васильевна",
                PassportData = Passports[18],
                BirthOfDay =  new DateOnly(2001, 10, 17)
            },
            new()
            {
                Id = 20,
                FullName = "Жмурова Мелания Максимова",
                PassportData = Passports[19],
                BirthOfDay =  new DateOnly(2002, 02, 17)
            }
        ];

        Rooms = 
        [
            new(){Id = 1, Capacity = 2, Decimal = 3000, Type = TypesRoom[0], HotelId = 0},
            new(){Id = 2, Capacity = 1, Decimal = 4000, Type = TypesRoom[1], HotelId = 0},
            new(){Id = 3, Capacity = 3, Decimal = 5000, Type = TypesRoom[2], HotelId = 0},
            new(){Id = 4, Capacity = 2, Decimal = 6000, Type = TypesRoom[0], HotelId = 0},
            new(){Id = 5, Capacity = 1, Decimal = 7000, Type = TypesRoom[1], HotelId = 1},
            new(){Id = 6, Capacity = 5, Decimal = 8000, Type = TypesRoom[2], HotelId = 1},
            new(){Id = 7, Capacity = 3, Decimal = 9000, Type = TypesRoom[0], HotelId = 1},
            new(){Id = 8, Capacity = 2, Decimal = 10000, Type = TypesRoom[1], HotelId = 1},
            new(){Id = 9, Capacity = 1, Decimal = 11000, Type = TypesRoom[2], HotelId = 2},
            new(){Id = 10, Capacity = 4, Decimal = 12000, Type = TypesRoom[0], HotelId = 2},
            new(){Id = 11, Capacity = 2, Decimal = 13000, Type = TypesRoom[1], HotelId = 2},
            new(){Id = 12, Capacity = 1, Decimal = 14000, Type = TypesRoom[2], HotelId = 2},
            new(){Id = 13, Capacity = 3, Decimal = 15000, Type = TypesRoom[0], HotelId = 3},
            new(){Id = 14, Capacity = 2, Decimal = 16000, Type = TypesRoom[1], HotelId = 3},
            new(){Id = 15, Capacity = 5, Decimal = 17000, Type = TypesRoom[2], HotelId = 3},
            new(){Id = 16, Capacity = 1, Decimal = 18000, Type = TypesRoom[0], HotelId = 3},
            new(){Id = 17, Capacity = 4, Decimal = 19000, Type = TypesRoom[1], HotelId = 4},
            new(){Id = 18, Capacity = 3, Decimal = 20000, Type = TypesRoom[2], HotelId = 4},
            new(){Id = 19, Capacity = 2, Decimal = 21000, Type = TypesRoom[0], HotelId = 4},
            new(){Id = 20, Capacity = 1, Decimal = 22000, Type = TypesRoom[1], HotelId = 4},
            new(){Id = 21, Capacity = 5, Decimal = 23000, Type = TypesRoom[2], HotelId = 5},
        ];

        Hotels = 
        [
            new(){Id = 0, Name = "Гостиница Москва", Address = "Новосадовая 34Э", City = "Вашингтон"},
            new(){Id = 1, Name = "Grand Hotel", Address = "Park Avenue 123", City = "New York"},
            new(){Id = 2, Name = "Hilton", Address = "Main Street 55", City = "Chicago"},
            new(){Id = 3, Name = "Marriott", Address = "Sunset Boulevard 87", City = "Los Angeles"},
            new(){Id = 4, Name = "Hyatt Regency", Address = "Lake Shore Drive 100", City = "Chicago"},
            new(){Id = 5, Name = "Ritz-Carlton", Address = "Michigan Avenue 160", City = "Chicago"},
        ];

       BookedRooms = 
       [
            new(){ Client = Clients[0], DateArrival = new DateOnly(2024, 4, 28), PeriodInDays = 10, Room = Rooms[0], DateEvection =  new DateOnly(2024, 5, 8)},
            new(){ Client = Clients[11], DateArrival = new DateOnly(2024, 4, 28), PeriodInDays = 10, Room = Rooms[11], DateEvection =  new DateOnly(2024, 05, 8)},
            new(){ Client = Clients[1], DateArrival = new DateOnly(2024, 5, 5), PeriodInDays = 5, Room = Rooms[1], DateEvection =  new DateOnly(2024, 5, 10)},
            new(){ Client = Clients[2], DateArrival = new DateOnly(2024, 5, 15), PeriodInDays = 7, Room= Rooms[2], DateEvection =  new DateOnly(2024, 5, 22)},
            new(){ Client = Clients[3], DateArrival = new DateOnly(2024, 6, 1), PeriodInDays = 3, Room= Rooms[3], DateEvection =  new DateOnly(2024, 6, 4)},
            new(){ Client = Clients[5], DateArrival = new DateOnly(2024, 6, 20), PeriodInDays = 9, Room= Rooms[5], DateEvection =  new DateOnly(2024, 06, 29)},
            new(){ Client = Clients[6], DateArrival = new DateOnly(2024, 7, 1), PeriodInDays = 6, Room= Rooms[6], DateEvection =  new DateOnly(2024, 7, 7)},
            new(){ Client = Clients[7], DateArrival = new DateOnly(2024, 7, 10), PeriodInDays = 11, Room= Rooms[7], DateEvection =  new DateOnly(2024, 7, 21)},
            new(){ Client = Clients[8], DateArrival = new DateOnly(2024, 7, 20), PeriodInDays = 8, Room= Rooms[8], DateEvection =  new DateOnly(2024, 7, 28)},
            new(){ Client = Clients[9], DateArrival = new DateOnly(2024, 8, 1), PeriodInDays = 4, Room= Rooms[9], DateEvection =  new DateOnly(2024, 8, 5)},
            new(){ Client = Clients[10], DateArrival = new DateOnly(2024, 8, 10), PeriodInDays = 12, Room= Rooms[10], DateEvection =  new DateOnly(2024, 8, 22)},
            new(){ Client = Clients[12], DateArrival = new DateOnly(2024, 6, 1), PeriodInDays= 3, Room= Rooms[14], DateEvection =  new DateOnly(2024, 6, 4)},
            new(){ Client = Clients[13], DateArrival = new DateOnly(2024, 6 ,10), PeriodInDays = 14, Room= Rooms[15], DateEvection =  new DateOnly(2024, 6, 24)},
            new(){ Client = Clients[14], DateArrival = new DateOnly(2024, 6, 20), PeriodInDays = 9, Room= Rooms[20], DateEvection =  new DateOnly(2024, 6, 29)},
            new(){ Client = Clients[15], DateArrival = new DateOnly(2024 ,7, 1), PeriodInDays = 6, Room= Rooms[16],  DateEvection =  new DateOnly(2024, 7, 7)}
        ];
    }
}