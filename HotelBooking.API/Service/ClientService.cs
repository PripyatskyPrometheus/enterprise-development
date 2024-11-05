using AutoMapper;
using HotelBooking.API.Dto;
using HotelBooking.API.Repository;
using HotelBooking.Domain.Entity;

namespace HotelBooking.API.Service;


public class ClientService(ClientRepository repository, IMapper mapper) : IService<ClientGetDto, ClientPostDto>
{
    /// <inheritdoc />
    public IEnumerable<ClientGetDto> GetAll()
    {
        return repository.GetAll();
    }

    /// <inheritdoc />
    public ClientGetDto? GetById(int id)
    {
        return repository.GetById(id);
    }

    /// <inheritdoc />
    public int Post(ClientPostDto postDto)
    {
        return repository.Post(mapper.Map<ClientGetDto>(postDto));
    }

    /// <inheritdoc />
    public ClientGetDto? Put(int id, ClientPostDto putDto)
    {
        var client = mapper.Map<ClientGetDto>(putDto);
        client.Id = id;
        bool isUpdated = repository.Put(client);
        if (isUpdated)
            return repository.GetById(client.Id);
        return null;
    }

    /// <inheritdoc />
    public bool Delete(int id)
    {
        return repository.Delete(id);
    }
}
