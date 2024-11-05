using HotelBooking.API.Dto;

namespace HotelBooking.API;

public class HotelBookingDbContext
{
    public List<HotelGetDto> Hotels { get; set; }

    public List<ClientGetDto> Clients { get; set; }

    public List<PassportGetDto> Passports { get; set; }

    public List<RoomGetDto> Rooms { get; set; }

    public List<BookedRoomGetDto> BookedRooms { get; set; }

    public List<RoomTypeGetDto> RoomTypes { get; set; }

    public HotelBookingDbContext()
    {
        RoomTypes =
        [
            new RoomTypeGetDto { Id = 1,  TypeName = "Luxary" },
            new RoomTypeGetDto { Id = 2,  TypeName = "Economy" },
            new RoomTypeGetDto { Id = 3,  TypeName = "Comfort" }
        ];

        Passports =
        [
            new PassportGetDto { Id = 1, Series = 6313, Number = 123421 },
            new PassportGetDto { Id = 2, Series = 1234, Number = 567890 },
            new PassportGetDto { Id = 3, Series = 5678, Number = 987654 },
            new PassportGetDto { Id = 4, Series = 7890, Number = 234567 },
            new PassportGetDto { Id = 5, Series = 3456, Number = 876543 },
            new PassportGetDto { Id = 6, Series = 9012, Number = 345678 },
            new PassportGetDto { Id = 7, Series = 2345, Number = 765432 },
            new PassportGetDto { Id = 8, Series = 6789, Number = 654321 },
            new PassportGetDto { Id = 9, Series = 4321, Number = 123456 },
            new PassportGetDto { Id = 10, Series = 0987, Number = 456789 },
            new PassportGetDto { Id = 11, Series = 8765, Number = 789012 },
            new PassportGetDto { Id = 12, Series = 6543, Number = 345678 },
            new PassportGetDto { Id = 13, Series = 2109, Number = 890123 },
            new PassportGetDto { Id = 14, Series = 8765, Number = 456789 },
            new PassportGetDto { Id = 15, Series = 5432, Number = 321098 },
            new PassportGetDto { Id = 16, Series = 6789, Number = 901234 },
            new PassportGetDto { Id = 17, Series = 1234, Number = 345678 },
            new PassportGetDto { Id = 18, Series = 9876, Number = 567890 },
            new PassportGetDto { Id = 19, Series = 3456, Number = 789012 },
            new PassportGetDto { Id = 20, Series = 6789, Number = 890123 },
        ];

            Clients =
            [
                new ClientGetDto
                {
                    Id = 1,
                    FullName = "Иванов Иван Иванович",
                    PassportData = Passports[0],
                    BirthOfDay =  new DateOnly(2003, 1, 1)
                },
                new ClientGetDto
                {
                    Id = 2,
                    FullName = "Петров Петр Петрович",
                    PassportData = Passports[1],
                    BirthOfDay =  new DateOnly(2002, 5, 15)
                },
                new ClientGetDto
                {
                    Id = 3,
                    FullName = "Сидоров Сидор Сидорович",
                    PassportData = Passports[2],
                    BirthOfDay =  new DateOnly(2001, 9, 20)
                },
                new ClientGetDto
                {
                    Id = 4,
                    FullName = "Кузнецов Алексей Владимирович",
                    PassportData = Passports[3],
                    BirthOfDay =  new DateOnly(2004, 3, 10)
                },
                new ClientGetDto
                {
                    Id = 5,
                    FullName = "Смирнов Дмитрий Александрович",
                    PassportData = Passports[4],
                    BirthOfDay =  new DateOnly(2000, 8, 27)
                },
                new ClientGetDto
                {
                    Id = 6,
                    FullName = "Козлов Игорь Сергеевич",
                    PassportData = Passports[5],
                    BirthOfDay =  new DateOnly(2005, 2, 18)
                },
                new ClientGetDto
                {
                    Id = 7,
                    FullName = "Лебедев Владислав Денисович",
                    PassportData = Passports[6],
                    BirthOfDay =  new DateOnly(2003, 10, 05)
                },
                new ClientGetDto
                {
                    Id = 8,
                    FullName = "Никитин Андрей Алексеевич",
                    PassportData = Passports[7],
                    BirthOfDay =  new DateOnly(2001, 12, 30)
                },
                new ClientGetDto
                {
                    Id = 9,
                    FullName = "Морозов Кирилл Васильевич",
                    PassportData = Passports[8],
                    BirthOfDay =  new DateOnly(2000, 4, 09)
                },
                new ClientGetDto
                {
                    Id = 10,
                    FullName = "Андреев Евгений Дмитриевич",
                    PassportData = Passports[9],
                    BirthOfDay =  new DateOnly(2002, 7, 14)
                },
                new ClientGetDto
                {
                    Id = 11,
                    FullName = "Богданова Елена Игоревна",
                    PassportData = Passports[10],
                    BirthOfDay =  new DateOnly(2004, 11, 21)
                },
                new ClientGetDto
                {
                    Id = 12,
                    FullName = "Семенов Максим Павлович",
                    PassportData = Passports[11],
                    BirthOfDay =  new DateOnly(2003, 6, 2)
                },
                new ClientGetDto
                {
                    Id = 13,
                    FullName = "Козлова Виктория Алексеевна",
                    PassportData = Passports[12],
                    BirthOfDay =  new DateOnly(2000, 12, 15)
                },
                new ClientGetDto
                {
                    Id = 14,
                    FullName = "Новикова Анастасия Сергеевна",
                    PassportData = Passports[13],
                    BirthOfDay =  new DateOnly(2001, 3, 25)
                },
                new ClientGetDto
                {
                    Id = 15,
                    FullName = "Гаврилова Ольга Владимировна",
                    PassportData = Passports[14],
                    BirthOfDay =  new DateOnly(2002, 9, 12)
                },
                new ClientGetDto
                {
                    Id = 16,
                    FullName = "Белякова Светлана Ивановна",
                    PassportData = Passports[15],
                    BirthOfDay =  new DateOnly(2004, 7, 3)
                },
                new ClientGetDto
                {
                    Id = 17,
                    FullName = "Федорова Екатерина Дмитриевна",
                    PassportData = Passports[16],
                    BirthOfDay =  new DateOnly(2003, 4, 28)
                },
                new ClientGetDto
                {
                    Id = 18,
                    FullName = "Алексеева Ирина Александровна",
                    PassportData = Passports[17],
                    BirthOfDay =  new DateOnly(2001, 10, 17)
                },
                new ClientGetDto
                {
                    Id = 19,
                    FullName = "Тихонова Татьяна Васильевна",
                    PassportData = Passports[18],
                    BirthOfDay =  new DateOnly(2001, 10, 17)
                },
                new ClientGetDto
                {
                    Id = 20,
                    FullName = "Жмурова Мелания Максимова",
                    PassportData = Passports[19],
                    BirthOfDay =  new DateOnly(2002, 02, 17)
                }
            ];

            Rooms =
            [
                new RoomGetDto { Id = 1, Capacity = 2, Cost = 3000m, Type = RoomTypes[0], HotelId = 0 },
                new RoomGetDto { Id = 2, Capacity = 1, Cost = 4000m, Type = RoomTypes[1], HotelId = 0 },
                new RoomGetDto { Id = 3, Capacity = 3, Cost = 5000m, Type = RoomTypes[2], HotelId = 0 },
                new RoomGetDto { Id = 4, Capacity = 2, Cost = 6000m, Type = RoomTypes[0], HotelId = 0 },
                new RoomGetDto { Id = 5, Capacity = 1, Cost = 7000m, Type = RoomTypes[1], HotelId = 1 },
                new RoomGetDto { Id = 6, Capacity = 5, Cost = 8000m, Type = RoomTypes[2], HotelId = 1 },
                new RoomGetDto { Id = 7, Capacity = 3, Cost = 9000m, Type = RoomTypes[0], HotelId = 1 },
                new RoomGetDto { Id = 8, Capacity = 2, Cost = 10000m, Type = RoomTypes[1], HotelId = 1 },
                new RoomGetDto { Id = 9, Capacity = 1, Cost = 11000m, Type = RoomTypes[2], HotelId = 2 },
                new RoomGetDto { Id = 10, Capacity = 4, Cost = 12000m, Type = RoomTypes[0], HotelId = 2 },
                new RoomGetDto { Id = 11, Capacity = 2, Cost = 13000m, Type = RoomTypes[1], HotelId = 2 },
                new RoomGetDto { Id = 12, Capacity = 1, Cost = 14000m, Type = RoomTypes[2], HotelId = 2 },
                new RoomGetDto { Id = 13, Capacity = 3, Cost = 15000m, Type = RoomTypes[0], HotelId = 3 },
                new RoomGetDto { Id = 14, Capacity = 2, Cost = 16000m, Type = RoomTypes[1], HotelId = 3 },
                new RoomGetDto { Id = 15, Capacity = 5, Cost = 17000m, Type = RoomTypes[2], HotelId = 3 },
                new RoomGetDto { Id = 16, Capacity = 1, Cost = 18000m, Type = RoomTypes[0], HotelId = 3 },
                new RoomGetDto { Id = 17, Capacity = 4, Cost = 19000m, Type = RoomTypes[1], HotelId = 4 },
                new RoomGetDto { Id = 18, Capacity = 3, Cost = 20000m, Type = RoomTypes[2], HotelId = 4 },
                new RoomGetDto { Id = 19, Capacity = 2, Cost = 21000m, Type = RoomTypes[0], HotelId = 4 },
                new RoomGetDto { Id = 20, Capacity = 1, Cost = 22000m, Type = RoomTypes[1], HotelId = 4 },
                new RoomGetDto { Id = 21, Capacity = 5, Cost = 23000m, Type = RoomTypes[2], HotelId = 5 },
            ];

            Hotels =
            [
                new  HotelGetDto { Id = 0, Name = "Гостиница Москва", Address = "Новосадовая 34Э", City = "Вашингтон" },
                new  HotelGetDto { Id = 1, Name = "Grand Hotel", Address = "Park Avenue 123", City = "New York" },
                new  HotelGetDto { Id = 2, Name = "Hilton", Address = "Main Street 55", City = "Chicago" },
                new  HotelGetDto { Id = 3, Name = "Marriott", Address = "Sunset Boulevard 87", City = "Los Angeles" },
                new  HotelGetDto { Id = 4, Name = "Hyatt Regency", Address = "Lake Shore Drive 100", City = "Chicago" },
                new  HotelGetDto { Id = 5, Name = "Ritz-Carlton", Address = "Michigan Avenue 160", City = "Chicago" },
            ];

            BookedRooms =
            [
                new BookedRoomGetDto { Client = Clients[0], DateArrival = new DateOnly(2024, 4, 28), PeriodInDays = 10, Room = Rooms[0], DateEvection =  new DateOnly(2024, 5, 8) },
                new BookedRoomGetDto { Client = Clients[11], DateArrival = new DateOnly(2024, 4, 28), PeriodInDays = 10, Room = Rooms[11], DateEvection =  new DateOnly(2024, 05, 8) },
                new BookedRoomGetDto { Client = Clients[1], DateArrival = new DateOnly(2024, 5, 5), PeriodInDays = 5, Room = Rooms[1], DateEvection =  new DateOnly(2024, 5, 10) },
                new BookedRoomGetDto { Client = Clients[2], DateArrival = new DateOnly(2024, 5, 15), PeriodInDays = 7, Room = Rooms[2], DateEvection =  new DateOnly(2024, 5, 22) },
                new BookedRoomGetDto { Client = Clients[3], DateArrival = new DateOnly(2024, 6, 1), PeriodInDays = 3, Room = Rooms[3], DateEvection =  new DateOnly(2024, 6, 4) },
                new BookedRoomGetDto { Client = Clients[5], DateArrival = new DateOnly(2024, 6, 20), PeriodInDays = 9, Room = Rooms[5], DateEvection =  new DateOnly(2024, 06, 29) },
                new BookedRoomGetDto { Client = Clients[6], DateArrival = new DateOnly(2024, 7, 1), PeriodInDays = 6, Room = Rooms[6], DateEvection =  new DateOnly(2024, 7, 7) },
                new BookedRoomGetDto { Client = Clients[7], DateArrival = new DateOnly(2024, 7, 10), PeriodInDays = 11, Room = Rooms[7], DateEvection =  new DateOnly(2024, 7, 21) },
                new BookedRoomGetDto { Client = Clients[8], DateArrival = new DateOnly(2024, 7, 20), PeriodInDays = 8, Room = Rooms[8], DateEvection =  new DateOnly(2024, 7, 28) },
                new BookedRoomGetDto { Client = Clients[9], DateArrival = new DateOnly(2024, 8, 1), PeriodInDays = 4, Room = Rooms[9], DateEvection =  new DateOnly(2024, 8, 5) },
                new BookedRoomGetDto { Client = Clients[10], DateArrival = new DateOnly(2024, 8, 10), PeriodInDays = 12, Room = Rooms[10], DateEvection =  new DateOnly(2024, 8, 22) },
                new BookedRoomGetDto { Client = Clients[12], DateArrival = new DateOnly(2024, 6, 1), PeriodInDays= 3, Room = Rooms[14], DateEvection =  new DateOnly(2024, 6, 4) },
                new BookedRoomGetDto { Client = Clients[13], DateArrival = new DateOnly(2024, 6 ,10), PeriodInDays = 14, Room = Rooms[15], DateEvection =  new DateOnly(2024, 6, 24) },
                new BookedRoomGetDto { Client = Clients[14], DateArrival = new DateOnly(2024, 6, 20), PeriodInDays = 9, Room = Rooms[20], DateEvection =  new DateOnly(2024, 6, 29) },
                new BookedRoomGetDto { Client = Clients[15], DateArrival = new DateOnly(2024 ,7, 1), PeriodInDays = 6, Room = Rooms[16],  DateEvection =  new DateOnly(2024, 7, 7) }
            ];
    }
}
