using Adboard.AppServices.Contexts.Adverts.Repositories;
using Adboard.AppServices.Exceptions;
using Adboard.Contracts.Adverts;
using Adboard.Domain.Entities;
using Adboard.Infrastructure.DataAccess.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Adboard.Infrastructure.DataAccess.Context.Adverts.Repositories;

public class AdvertRepository 
    (IRepository<Advert, Guid, ApplicationDbContext> repository, IMapper mapper): IAdvertRepository
{
    public async Task<Guid> AddAsync(CreateAdvertDto createDto)
    {
        var advert = mapper.Map<Advert>(createDto);
        await repository.AddAsync(advert);
        
        return advert.Id;
    }
}