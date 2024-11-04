using AutoMapper;
using HotelBooking.API.Dto;
using HotelBooking.API.Repository;

namespace HotelBooking.API.Service;

public class HotelService(HotelRepository repository, IMapper mapper) : IService<HotelGetDto, HotelPostDto>
{
    /// <inheritdoc />
    public IEnumerable<HotelGetDto> GetAll()
    {
        return repository.GetAll();
    }

    /// <inheritdoc />
    public HotelGetDto? GetById(int id)
    {
        return repository.GetById(id);
    }

    /// <inheritdoc />
    public int Post(HotelPostDto postDto)
    {
        return repository.Post(mapper.Map<HotelGetDto>(postDto));

    }

    /// <inheritdoc />
    public HotelGetDto? Put(HotelGetDto putDto)
    {
        var hotel = mapper.Map<HotelGetDto>(putDto);
        bool isUpdated = repository.Put(hotel);
        if (isUpdated)
            return isUpdated ? repository.GetById(hotel.Id) : null;
        return null;
    }

    /// <inheritdoc />
    public bool Delete(int id)
    {
        return repository.Delete(id);
    }
}