using HotelArmor.Domain;
namespace HotelArmor.Tests;

public class HotelArmorData {

    public List<TypeRoom> TypesRoom = [
       new(){ ID = 0, NameRoom = "Luxury"},
       new(){ID = 1, NameRoom ="Economy"},
       new(){ID = 2, NameRoom ="Comfort"}
        ];

    public List<Pasport> Pasports = [
        new(){ID = 0, Series = 6112, Number = 100503},
        new(){ID = 1, Series = 6212, Number = 305610},
        new(){ID = 2, Series = 6312, Number = 678390},
        new(){ID = 3, Series = 6412, Number = 875567},
        new(){ID = 4, Series = 6512, Number = 903490}
        ];

    public List<Room> Rooms;
    public List<Client> Clients;
    public List<Hotel> Hotels;
    public List<ArmoredRoom> ArmoredRooms;

    public HotelArmorData() {
        Clients = [
            new(){
                ID = 0,
                FullName = "Жмуриков Анатолий Степанович",
                PasportData = Pasports[0],
                BirthOfDay = new DateOnly(1986, 12, 30)
            },
            new(){
                ID = 1,
                FullName = "Морозов Сергей Владиславович",
                PasportData = Pasports[1],
                BirthOfDay = new DateOnly(1972, 5, 12)
            },
            new(){
                ID = 2,
                FullName = "Османов Мехмед Ибрагимович",
                PasportData = Pasports[2],
                BirthOfDay = new DateOnly(1990, 4, 7)
            },
            new(){
                ID = 3,
                FullName = "Уханов Никита Олегович",
                PasportData = Pasports[3],
                BirthOfDay = new DateOnly(1989, 10, 17)
            },
            new(){
                ID = 4,
                FullName = "Андреев Данила Валерьевич",
                PasportData = Pasports[4],
                BirthOfDay = new DateOnly(2000, 7, 18)
            }
            ];

        Hotels = [
            new() {
                ID = 0,
                Name = "Россия",
                Address = "Ленина 32",
                City = "Санкт-Пеербург"
            },
            new() {
                ID = 1,
                Name = "Москва",
                Address = "Лукачёва 65",
                City = "Самара"
            },
            new() {
                ID = 2,
                Name = "Лаза",
                Address = "Гагарин 55",
                City = "Новосибирск"
            }
        ];

        Rooms = [
            new() {
                ID = 0, 
                Type = TypesRoom[0],
                Capacity = 2, 
                Cost = 5000, 
                HotelID = 0
            },
            new() {
                ID = 1,
                Type = TypesRoom[1],
                Capacity = 2,
                Cost = 1000,
                HotelID = 1
            },
            new() {
                ID = 2,
                Type = TypesRoom[2],
                Capacity = 3,
                Cost = 3000,
                HotelID = 2
            },
            new() {
                ID = 3,
                Type = TypesRoom[0],
                Capacity = 3,
                Cost = 5000,
                HotelID = 1
            },
            new() {
                ID = 4,
                Type = TypesRoom[1],
                Capacity = 3,
                Cost = 1200,
                HotelID = 2
            },
            new() {
                ID = 5,
                Type = TypesRoom[2],
                Capacity = 5,
                Cost = 3500,
                HotelID = 0
            }
        ];

        ArmoredRooms = [
            new() { 
                Client = Clients[0], 
                Room = Rooms[0],
                DateArrival = new DateOnly(2024, 4, 20),
                DateEvection = new DateOnly(2024, 5, 10),
                Period = 30
            },
            new() { 
                Client = Clients[1], 
                Room= Rooms[1], 
                DateArrival= new DateOnly(2024, 12, 28),
                DateEvection = new DateOnly(2025, 1, 5),
                Period= 8
            },
            new() { 
                Client = Clients[2], 
                Room= Rooms[2],
                DateArrival= new DateOnly(2024, 5, 8),
                DateEvection = new DateOnly(2024, 5, 10),
                Period= 2
            },
            new() { 
                Client = Clients[3], 
                Room= Rooms[3],
                DateArrival= new DateOnly(2024, 6, 1),
                DateEvection = new DateOnly(2024, 6, 15),
                Period= 14
            },
            new() {
                Client = Clients[4], 
                Room= Rooms[4],
                DateArrival= new DateOnly(2024, 8, 1),
                DateEvection = new DateOnly(2024, 8, 30),
                Period= 29
            }
        ];
    }
}