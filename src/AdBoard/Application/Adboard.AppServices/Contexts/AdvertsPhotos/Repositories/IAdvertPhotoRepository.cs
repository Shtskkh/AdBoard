using Adboard.Contracts.AdvertsPhotos;
using Adboard.Domain.Entities;

namespace Adboard.AppServices.Contexts.AdvertsPhotos.Repositories;

public interface IAdvertPhotoRepository
{
    Task<IReadOnlyCollection<AdvertPhoto>> GetByAdvertIdAsync(Guid advertId);
    Task<Guid> AddAsync(CreateAdvertPhotoDto createDto);
    Task<IReadOnlyCollection<Guid>> AddRangeAsync(IEnumerable<CreateAdvertPhotoDto> photos);
}