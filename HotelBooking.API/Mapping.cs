using AutoMapper;
using HotelBooking.API.Dto;

namespace HotelBooking.API;

public class Mapping : Profile
{
    public Mapping()
    {
        _ = CreateMap<BookedRoomGetDto, BookedRoomPostDto>().ReverseMap();
        _ = CreateMap<HotelGetDto, HotelPostDto>().ReverseMap();
        _ = CreateMap<ClientGetDto, ClientPostDto>().ReverseMap();
        _ = CreateMap<PassportGetDto, PassportPostDto>().ReverseMap();
        _ = CreateMap<RoomGetDto, RoomPostDto>().ReverseMap();
        _ = CreateMap<RoomTypeGetDto, RoomTypePostDto>().ReverseMap();
    }
}
