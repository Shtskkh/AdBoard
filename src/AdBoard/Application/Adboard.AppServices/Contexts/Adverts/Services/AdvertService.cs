using Adboard.AppServices.Contexts.Adverts.Repositories;
using Adboard.Contracts.Adverts;
using Adboard.Domain.Entities;
using AutoMapper;

namespace Adboard.AppServices.Contexts.Adverts.Services;

public class AdvertService(IAdvertRepository advertRepository, IMapper mapper) : IAdvertService
{
    public async Task<Guid> AddAsync(CreateAdvertDto createDto)
    {
        return await advertRepository.AddAsync(createDto);
    }
}