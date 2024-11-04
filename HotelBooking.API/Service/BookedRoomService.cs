using AutoMapper;
using HotelBooking.API.Dto;
using HotelBooking.API.Repository;

namespace HotelBooking.API.Service;
public class BookedRoomService(BookedRoomRepository repository, IMapper mapper) : IService<BookedRoomGetDto, BookedRoomPostDto>
{
    /// <inheritdoc />
    public IEnumerable<BookedRoomGetDto> GetAll()
    {
        return repository.GetAll();
    }

    /// <inheritdoc />
    public BookedRoomGetDto? GetById(int id)
    {
        return repository.GetById(id);
    }

    /// <inheritdoc />
    public int Post(BookedRoomPostDto postDto)
    {
        return repository.Post(mapper.Map<BookedRoomGetDto>(postDto));
    }

    /// <inheritdoc />
    public BookedRoomGetDto? Put(BookedRoomGetDto putDto)
    {
        var bookedroom = mapper.Map<BookedRoomGetDto>(putDto);
        bool isUpdated = repository.Put(bookedroom);
        if (isUpdated)
            return repository.GetById(bookedroom.Room.Id);
        return null;
    }

    /// <inheritdoc />
    public bool Delete(int id)
    {
        return repository.Delete(id);
    }


}