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
    public async Task<Advert> GetByIdAsync(Guid id)
    {
        var advert = await repository.GetAllAsync()
            .Where(a => a.Id == id)
            .Include(a => a.User)
            .Include(a => a.AdvertPhotos)
            .Include(a => a.Subcategories)
            .ThenInclude(a => a.Category)
            .FirstOrDefaultAsync();
            
        return advert ?? throw new NotFoundException($"Advert with id: {id} was not found.");
    }

    public async Task<Guid> AddAsync(CreateAdvertDto createDto)
    {
        var advert = mapper.Map<Advert>(createDto);
        await repository.AddAsync(advert);
        
        return advert.Id;
    }

    public async Task DeleteAsync(Guid id)
    {
        await repository.DeleteAsync(id);
    }
}