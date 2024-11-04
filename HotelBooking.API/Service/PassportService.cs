using AutoMapper;
using HotelBooking.API.Dto;
using HotelBooking.API.Repository;

namespace HotelBooking.API.Service;


public class PassportService(PassportRepository repository, IMapper mapper) : IService<PassportGetDto, PassportPostDto>
{
    /// <inheritdoc />
    public IEnumerable<PassportGetDto> GetAll()
    {
        return repository.GetAll();
    }

    /// <inheritdoc />
    public PassportGetDto? GetById(int id)
    {
        return repository.GetById(id);
    }

    /// <inheritdoc />
    public int Post(PassportPostDto postDto)
    {
        return repository.Post(mapper.Map<PassportGetDto>(postDto));
    }

    /// <inheritdoc />
    public PassportGetDto? Put(PassportGetDto putDto)
    {
        var passport = mapper.Map<PassportGetDto>(putDto);
        bool isUpdated = repository.Put(passport);
        if (isUpdated)
            return repository.GetById(passport.Id);
        return null;
    }

    /// <inheritdoc />
    public bool Delete(int id)
    {
        return repository.Delete(id);
    }
}
