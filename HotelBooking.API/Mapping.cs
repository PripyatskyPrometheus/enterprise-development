using AutoMapper;
using HotelBooking.API.Dto;
using HotelBooking.Domain.Entity;
using System.Globalization;
namespace HotelBooking.API;

public class Mapping : Profile
{
    public Mapping()
    {
        CreateMap<Hotel, HotelDto>().ReverseMap();
        CreateMap<Passport, PassportDto>().ReverseMap();
        CreateMap<Client, ClientDto>();
        CreateMap<RoomType, RoomTypeDto>().ReverseMap();
        CreateMap<Room, RoomDto>().ReverseMap();
        CreateMap<BookedRoom, BookedRoomDto>()
            .ForMember("DateArrival", opt => opt.MapFrom(r => r.DateArrival.ToString("yyyy-mm-dd")))
            .ForMember("DateEvection", opt => opt.MapFrom(r => r.DateEvection.ToString("yyyy-mm-dd")));
        CreateMap<BookedRoomDto, BookedRoom>()
            .ForMember("DateArrival", opt => opt.MapFrom(r => DateOnly.ParseExact(r.DateArrival, "yyyy-mm-dd")))
            .ForMember("DateEvection", opt => opt.MapFrom(r => DateOnly.ParseExact(r.DateEvection, "yyyy-mm-dd")));
        CreateMap<Client, ClientDto>()
            .ForMember("BirthOfDay", opt => opt.MapFrom(c => c.BirthOfDay.ToString("yyyy-mm-dd")));
        CreateMap<Client, ClientDto>().ReverseMap()
            .ForMember("BirthOfDay", opt => opt.MapFrom(с => DateOnly.ParseExact(с.BirthOfDay, "yyyy-mm-dd")));
    }
}