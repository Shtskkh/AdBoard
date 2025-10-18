using Adboard.AppServices.Contexts.AdvertsPhotos;
using Adboard.Contracts.AdvertsPhotos;
using Adboard.Domain.Entities;
using Adboard.Infrastructure.DataAccess.Repositories;
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

    public async Task<IReadOnlyCollection<Guid>> AddAsync(IEnumerable<CreateAdvertPhotoDto> photosDto)
    {
        var photos = mapper.Map<IReadOnlyCollection<AdvertPhoto>>(photosDto);
        await repository.AddRangeAsync(photos);

        var guids = photos.Select(s => s.Id).ToList();
        
        return guids.AsReadOnly();
    }
}