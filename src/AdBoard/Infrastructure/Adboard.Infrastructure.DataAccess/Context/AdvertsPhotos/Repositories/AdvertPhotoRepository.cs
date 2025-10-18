using Adboard.AppServices.Contexts.AdvertsPhotos;
using Adboard.AppServices.Contexts.AdvertsPhotos.Repositories;
using Adboard.Contracts.AdvertsPhotos;
using Adboard.Domain.Entities;
using Adboard.Infrastructure.DataAccess.Repositories;
using Adboard.Infrastructure.DataAccess.Repositories.EntitiesRepositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Adboard.Infrastructure.DataAccess.Context.AdvertsPhotos.Repositories;

public class AdvertPhotoRepository
    (IRepository<AdvertPhoto, Guid, ApplicationDbContext> repository, IMapper mapper) : IAdvertPhotoRepository
{
    public async Task<IReadOnlyCollection<AdvertPhoto>> GetByAdvertIdAsync(Guid advertId)
    {
        var photos = await repository.GetAllAsync()
            .Where(p => p.AdvertId == advertId)
            .OrderBy(p => p.Order)
            .ToListAsync();
        
        return photos;
    }

    public async Task<Guid> AddAsync(CreateAdvertPhotoDto createDto)
    {
        var photo = mapper.Map<AdvertPhoto>(createDto);
        await repository.AddAsync(photo);
        
        return photo.Id;
    }

    public async Task<IReadOnlyCollection<Guid>> AddRangeAsync(IEnumerable<CreateAdvertPhotoDto> photosDto)
    {
        var photos = mapper.Map<IReadOnlyCollection<AdvertPhoto>>(photosDto);
        await repository.AddRangeAsync(photos);

        var guids = photos.Select(s => s.Id).ToList();
        
        return guids.AsReadOnly();
    }
}