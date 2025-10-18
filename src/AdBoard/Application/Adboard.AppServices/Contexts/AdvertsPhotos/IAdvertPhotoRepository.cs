using Adboard.Contracts.AdvertsPhotos;
using Adboard.Domain.Entities;

namespace Adboard.AppServices.Contexts.AdvertsPhotos;

public interface IAdvertPhotoRepository
{
    Task<IReadOnlyCollection<AdvertPhoto>> GetByAdvertIdAsync(Guid advertId);
    Task<IReadOnlyCollection<Guid>> AddAsync(IEnumerable<CreateAdvertPhotoDto> photos);
}