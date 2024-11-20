using AutoMapper;
using HotelBooking.API.Dto;
using HotelBooking.Domain.Entity;
namespace HotelBooking.API;

public class Mapping : Profile
{
    public Mapping()
    {
        CreateMap<HotelGetDto, HotelDto>().ReverseMap();
        CreateMap<HotelGetDto, Hotel>().ReverseMap();
        CreateMap<HotelDto, Hotel>().ReverseMap();

        CreateMap<PassportGetDto, PassportDto>().ReverseMap();
        CreateMap<PassportGetDto, Passport>().ReverseMap();
        CreateMap<PassportDto, Passport>().ReverseMap();

        CreateMap<RoomTypeGetDto, RoomTypeDto>().ReverseMap();
        CreateMap<RoomTypeGetDto, RoomType>().ReverseMap();
        CreateMap<RoomTypeDto, RoomType>().ReverseMap();

        
        CreateMap<RoomGetDto, RoomDto>().ReverseMap();
        CreateMap<RoomGetDto, Room>().ReverseMap();
        CreateMap<RoomDto, Room>().ReverseMap();

        CreateMap<BookedRoomGetDto, BookedRoomDto>().ReverseMap();
        CreateMap<BookedRoomGetDto, BookedRoom>().ReverseMap();
        CreateMap<BookedRoomDto, BookedRoom>().ReverseMap();

        CreateMap<ClientGetDto, ClientDto>().ReverseMap();
        CreateMap<ClientGetDto, Client>().ReverseMap();
        CreateMap<ClientDto, Client>().ReverseMap();

        CreateMap<BookedRoomDto, BookedRoom>()
            .ForMember("DateArrival", opt => opt.MapFrom(r => DateOnly.ParseExact(r.DateArrival, "yyyy-mm-dd")))
            .ForMember("DateEvection", opt => opt.MapFrom(r => DateOnly.ParseExact(r.DateEvection, "yyyy-mm-dd")));
        CreateMap<ClientDto, Client>()
            .ForMember("BirthOfDay", opt => opt.MapFrom(с => DateOnly.ParseExact(с.BirthOfDay, "yyyy-mm-dd")));
    }
}