using HotelBooking.Domain;
namespace HotelBooking.Tests;

public class HotelBookedData 
{

    public List<TypeRoom> TypesRoom = 
    [
        new(){ ID = 1,  NameRoom = "Luxary"},
        new(){ ID = 2,  NameRoom = "Economy"},
        new(){ ID = 3,  NameRoom = "Comfort"}
    ];

    public List<Passport> Passports = 
        [
        new(){ID = 1, Series = 6313, Number = 123421},
        new(){ID = 2, Series = 1234, Number = 567890 },
        new(){ID = 3, Series = 5678, Number = 987654},
        new(){ID = 4, Series = 7890, Number = 234567},
        new(){ID = 5, Series = 3456, Number = 876543},
        new(){ID = 6, Series = 9012, Number = 345678},
        new(){ID = 7, Series = 2345, Number = 765432},
        new(){ID = 8, Series = 6789, Number = 654321},
        new(){ID = 9, Series = 4321, Number = 123456},
        new(){ID = 10, Series = 0987, Number = 456789},
        new(){ID = 11, Series = 8765, Number = 789012 },
        new(){ID = 12, Series = 6543, Number = 345678},
        new(){ID = 13, Series = 2109, Number = 890123},
        new(){ID = 14, Series = 8765, Number = 456789},
        new(){ID = 15, Series = 5432, Number = 321098},
        new(){ID = 16, Series = 6789, Number = 901234},
        new(){ID = 17, Series = 1234, Number = 345678},
        new(){ID = 18, Series = 9876, Number = 567890},
        new(){ID = 19, Series = 3456, Number = 789012},
        new(){ID = 20, Series = 6789, Number = 890123},
        ];

    public List<Room> Rooms;
    public List<Hotel> Hotels;
    public List<Client> Clients;
    public List<BookedRoom> ArmoredRooms;

    public HotelBookedData() 
    {
        Clients = 
            [
            new() 
            {
                ID = 1,
                FullName = "Иванов Иван Иванович",
                PasportData = Passports[0],
                BirthOfDay =  new DateOnly(2003, 1, 1)
            },
            new() 
            {
                ID = 2,
                FullName = "Петров Петр Петрович",
                PasportData = Passports[1],
                BirthOfDay =  new DateOnly(2002, 5, 15 )
            },
            new() 
            {
                ID = 3,
                FullName = "Сидоров Сидор Сидорович",
                PasportData = Passports[2],
                BirthOfDay =  new DateOnly(2001, 9, 20 )
            },
            new() 
            {
                ID = 4,
                FullName = "Кузнецов Алексей Владимирович",
                PasportData = Passports[3],
                BirthOfDay =  new DateOnly(2004, 3, 10)
            },
            new() 
            {
                ID = 5,
                FullName = "Смирнов Дмитрий Александрович",
                PasportData = Passports[4],
                BirthOfDay =  new DateOnly(2000, 8, 27)
            },
            new() 
            {
                ID = 6,
                FullName = "Козлов Игорь Сергеевич",
                PasportData = Passports[5],
                BirthOfDay =  new DateOnly(2005, 2, 18)
            },
            new() 
            {
                ID = 7,
                FullName = "Лебедев Владислав Денисович",
                PasportData = Passports[6],
                BirthOfDay =  new DateOnly(2003, 10, 05)
            },
            new() 
            {
                ID = 8,
                FullName = "Никитин Андрей Алексеевич",
                PasportData = Passports[7],
                BirthOfDay =  new DateOnly(2001, 12, 30)
            },
            new() 
            {
                ID = 9,
                FullName = "Морозов Кирилл Васильевич",
                PasportData = Passports[8],
                BirthOfDay =  new DateOnly(2000, 4, 09)
            },
            new() 
            {
                ID = 10,
                FullName = "Андреев Евгений Дмитриевич",
                PasportData = Passports[9],
               BirthOfDay =  new DateOnly(2002, 7, 14)
            },
            new() 
            {
                ID = 11,
                FullName = "Богданова Елена Игоревна",
                PasportData = Passports[10],
                BirthOfDay =  new DateOnly(2004, 11, 21)
            },
            new() 
            {
                ID = 12,
                FullName = "Семенов Максим Павлович",
                PasportData = Passports[11],
                BirthOfDay =  new DateOnly(2003, 6, 2)
            },
            new() 
            {
                ID = 13,
                FullName = "Козлова Виктория Алексеевна",
                PasportData = Passports[12],
                BirthOfDay =  new DateOnly(2000, 12, 15)
            },
            new() 
            {
                ID = 14,
                FullName = "Новикова Анастасия Сергеевна",
                PasportData = Passports[13],
                BirthOfDay =  new DateOnly(2001, 3, 25)
            },
            new() 
            {
                ID = 15,
                FullName = "Гаврилова Ольга Владимировна",
                PasportData = Passports[14],
                BirthOfDay =  new DateOnly(2002, 9, 12)
            },
            new() 
            {
                ID = 16,
                FullName = "Белякова Светлана Ивановна",
                PasportData = Passports[15],
                BirthOfDay =  new DateOnly(2004, 7, 3)
            },
            new() 
            {
                ID = 17,
                FullName = "Федорова Екатерина Дмитриевна",
                PasportData = Passports[16],
                BirthOfDay =  new DateOnly(2003, 4, 28)
            },
            new() 
            {
                ID = 18,
                FullName = "Алексеева Ирина Александровна",
                PasportData = Passports[17],
                BirthOfDay =  new DateOnly(2001, 10, 17)
            },
            new() 
            {
                ID = 19,
                FullName = "Тихонова Татьяна Васильевна",
                PasportData = Passports[18],
                BirthOfDay =  new DateOnly(2001, 10, 17)
            },
            new()
            {
                ID = 20,
                FullName = "Жмурова Мелания Максимова",
                PasportData = Passports[19],
                BirthOfDay =  new DateOnly(2002, 02, 17)
            }
        ];

        Rooms = 
        [
            new(){ID = 1, Capacity = 2, Cost = 3000, Type = TypesRoom[0], HotelID = 0},
            new(){ID = 2, Capacity = 1, Cost = 4000, Type = TypesRoom[1], HotelID = 0},
            new(){ID = 3, Capacity = 3, Cost = 5000, Type = TypesRoom[2], HotelID = 0},
            new(){ID = 4, Capacity = 2, Cost = 6000, Type = TypesRoom[0], HotelID = 0},
            new(){ID = 5, Capacity = 1, Cost = 7000, Type = TypesRoom[1], HotelID = 1},
            new(){ID = 6, Capacity = 5, Cost = 8000, Type = TypesRoom[2], HotelID = 1},
            new(){ID = 7, Capacity = 3, Cost = 9000, Type = TypesRoom[0], HotelID = 1},
            new(){ID = 8, Capacity = 2, Cost = 10000, Type = TypesRoom[1], HotelID = 1},
            new(){ID = 9, Capacity = 1, Cost = 11000, Type = TypesRoom[2], HotelID = 2},
            new(){ID = 10, Capacity = 4, Cost = 12000, Type = TypesRoom[0], HotelID = 2},
            new(){ID = 11, Capacity = 2, Cost = 13000, Type = TypesRoom[1], HotelID = 2},
            new(){ID = 12, Capacity = 1, Cost = 14000, Type = TypesRoom[2], HotelID = 2},
            new(){ID = 13, Capacity = 3, Cost = 15000, Type = TypesRoom[0], HotelID = 3},
            new(){ID = 14, Capacity = 2, Cost = 16000, Type = TypesRoom[1], HotelID = 3},
            new(){ID = 15, Capacity = 5, Cost = 17000, Type = TypesRoom[2], HotelID = 3},
            new(){ID = 16, Capacity = 1, Cost = 18000, Type = TypesRoom[0], HotelID = 3},
            new(){ID = 17, Capacity = 4, Cost = 19000, Type = TypesRoom[1], HotelID = 4},
            new(){ID = 18, Capacity = 3, Cost = 20000, Type = TypesRoom[2], HotelID = 4},
            new(){ID = 19, Capacity = 2, Cost = 21000, Type = TypesRoom[0], HotelID = 4},
            new(){ID = 20, Capacity = 1, Cost = 22000, Type = TypesRoom[1], HotelID = 4},
            new(){ID = 21, Capacity = 5, Cost = 23000, Type = TypesRoom[2], HotelID = 5},
        ];

        Hotels = 
        [
            new(){ID = 0, Name = "Гостиница Москва", Address = "Новосадовая 34Э", City = "Вашингтон"},
            new(){ID = 1, Name = "Grand Hotel", Address = "Park Avenue 123", City = "New York"},
            new(){ID = 2, Name = "Hilton", Address = "Main Street 55", City = "Chicago"},
            new(){ID = 3, Name = "Marriott", Address = "Sunset Boulevard 87", City = "Los Angeles"},
            new(){ID = 4, Name = "Hyatt Regency", Address = "Lake Shore Drive 100", City = "Chicago"},
            new(){ID = 5, Name = "Ritz-Carlton", Address = "Michigan Avenue 160", City = "Chicago"},
        ];

       ArmoredRooms = 
       [
            new(){ Client = Clients[0], DateArrival = new DateOnly(2024, 4, 28), Period = 10, Room = Rooms[0], DateEvection =  new DateOnly(2024, 5, 8)},
            new(){ Client = Clients[11], DateArrival = new DateOnly(2024, 4, 28), Period= 10, Room = Rooms[11], DateEvection =  new DateOnly(2024, 05, 8)},
            new(){ Client = Clients[1], DateArrival = new DateOnly(2024, 5, 5), Period= 5, Room = Rooms[1], DateEvection =  new DateOnly(2024, 5, 10)},
            new(){ Client = Clients[2], DateArrival = new DateOnly(2024, 5, 15), Period= 7, Room= Rooms[2], DateEvection =  new DateOnly(2024, 5, 22)},
            new(){ Client = Clients[3], DateArrival = new DateOnly(2024, 6, 1), Period= 3, Room= Rooms[3], DateEvection =  new DateOnly(2024, 6, 4)},
            new(){ Client = Clients[4], DateArrival = new DateOnly(2024, 6, 10), Period= 14, Room= Rooms[4], DateEvection =  new DateOnly(2024, 6, 24)},
            new(){ Client = Clients[5], DateArrival = new DateOnly(2024, 6, 20), Period= 9, Room= Rooms[5], DateEvection =  new DateOnly(2024, 06, 29)},
            new(){ Client = Clients[6], DateArrival = new DateOnly(2024, 7, 1), Period= 6, Room= Rooms[6], DateEvection =  new DateOnly(2024, 7, 7)},
            new(){ Client = Clients[7], DateArrival = new DateOnly(2024, 7, 10), Period= 11, Room= Rooms[7], DateEvection =  new DateOnly(2024, 7, 21)},
            new(){ Client = Clients[8], DateArrival = new DateOnly(2024, 7, 20), Period= 8, Room= Rooms[8], DateEvection =  new DateOnly(2024, 7, 28)},
            new(){ Client = Clients[9], DateArrival = new DateOnly(2024, 8, 1), Period= 4, Room= Rooms[9], DateEvection =  new DateOnly(2024, 8, 5)},
            new(){ Client = Clients[10], DateArrival = new DateOnly(2024, 8, 10), Period= 12, Room= Rooms[10], DateEvection =  new DateOnly(2024, 8, 22)},
            new(){ Client = Clients[12], DateArrival = new DateOnly(2024, 6, 1), Period= 3, Room= Rooms[14], DateEvection =  new DateOnly(2024, 6, 4)},
            new(){ Client = Clients[13], DateArrival = new DateOnly(2024, 6 ,10), Period = 14, Room= Rooms[15], DateEvection =  new DateOnly(2024, 6, 24)},
            new(){ Client = Clients[14], DateArrival = new DateOnly(2024, 6, 20), Period = 9, Room= Rooms[20], DateEvection =  new DateOnly(2024, 6, 29)},
            new(){ Client = Clients[15], DateArrival = new DateOnly(2024 ,7, 1), Period = 6, Room= Rooms[16],  DateEvection =  new DateOnly(2024, 7, 7)}
        ];
    }
}