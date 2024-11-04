using AutoMapper;
using HotelBooking.API.Dto;
using HotelBooking.API.Repository;

namespace HotelBooking.API.Service;

public class RoomTypeService(RoomTypeRepository repository, IMapper mapper) : IService<RoomTypeGetDto, RoomTypePostDto>
{
    /// <inheritdoc />
    public IEnumerable<RoomTypeGetDto> GetAll()
    {
        return repository.GetAll();
    }

    /// <inheritdoc />
    public RoomTypeGetDto? GetById(int id)
    {
        return repository.GetById(id);
    }

    /// <inheritdoc />
    public int Post(RoomTypePostDto postDto)
    {
        return repository.Post(mapper.Map<RoomTypeGetDto>(postDto));
    }

    /// <inheritdoc />
    public RoomTypeGetDto? Put(RoomTypeGetDto putDto)
    {
        var type = mapper.Map<RoomTypeGetDto>(putDto);
        bool isUpdated = repository.Put(type);
        if (isUpdated)
            return repository.GetById(type.Id);
        return null;
    }

    /// <inheritdoc />
    public bool Delete(int id)
    {
        return repository.Delete(id);
    }
}

