using AutoMapper;
using HotelBooking.API.Dto;
using HotelBooking.Domain.Entity;
namespace HotelBooking.API;

public class Mapping : Profile
{
    public Mapping()
    {
        CreateMap<Hotel, HotelDto>().ReverseMap();
        CreateMap<Passport, PassportDto>().ReverseMap();
        CreateMap<Client, ClientDto>().ReverseMap()
            .ForMember("Birthday", opt => opt.MapFrom(c => DateOnly.ParseExact(c.BirthOfDay, "yyyy-mm-dd"))); ;
        CreateMap<RoomType, RoomTypeDto>().ReverseMap();
        CreateMap<Room, RoomDto>().ReverseMap();
        CreateMap<BookedRoom, BookedRoomDto>().ReverseMap()
            .ForMember("DateArrival", opt => opt.MapFrom(r => DateOnly.ParseExact(r.DateArrival, "yyyy-mm-dd")))
            .ForMember("DateEvection", opt => opt.MapFrom(r => DateOnly.ParseExact(r.DateEvection, "yyyy-mm-dd")));
    }
}