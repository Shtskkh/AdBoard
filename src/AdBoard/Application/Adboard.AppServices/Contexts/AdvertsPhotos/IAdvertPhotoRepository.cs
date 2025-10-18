

using Adboard.Contracts.AdvertsPhotos;

namespace Adboard.AppServices.Contexts.AdvertsPhotos;

public interface IAdvertPhotoRepository
{
    Task<IReadOnlyCollection<Guid>> AddAsync(IEnumerable<CreateAdvertPhotoDto> photos);
}