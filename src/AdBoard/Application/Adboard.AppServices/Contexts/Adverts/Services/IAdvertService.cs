using Adboard.Contracts.Adverts;

namespace Adboard.AppServices.Contexts.Adverts.Services;

public interface IAdvertService
{
    Task<AdvertDto> GetByIdAsync(Guid id);
    Task<Guid> AddAsync(CreateAdvertDto createDto);
}