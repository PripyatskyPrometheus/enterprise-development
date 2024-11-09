using AutoMapper;
using HotelBooking.API.Dto;
using HotelBooking.Domain.Entity;
namespace HotelBooking.API;

public class Mapping : Profile
{
    public Mapping()
    {
        _ = CreateMap<Hotel, HotelDto>().ReverseMap();
        _ = CreateMap<Passport, PassportDto>().ReverseMap();
        _ = CreateMap<Client, ClientDto>().ReverseMap();
        _ = CreateMap<RoomType, RoomTypeDto>().ReverseMap();
        _ = CreateMap<Room, RoomDto>().ReverseMap();
        _ = CreateMap<BookedRoom, BookedRoomDto>().ReverseMap();
    }
}