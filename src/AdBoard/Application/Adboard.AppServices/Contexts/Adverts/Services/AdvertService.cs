using Adboard.AppServices.Contexts.Adverts.Repositories;
using Adboard.Contracts.Adverts;
using Adboard.Domain.Entities;
using AutoMapper;

namespace Adboard.AppServices.Contexts.Adverts.Services;

public class AdvertService(IAdvertRepository advertRepository, IMapper mapper) : IAdvertService
{
    public async Task<AdvertDto> GetByIdAsync(Guid id)
    {
        var advert = await advertRepository.GetByIdAsync(id);
        var dto = mapper.Map<AdvertDto>(advert);
        
        return dto;
    }

    public async Task<Guid> AddAsync(CreateAdvertDto createDto)
    {
        return await advertRepository.AddAsync(createDto);
    }
}