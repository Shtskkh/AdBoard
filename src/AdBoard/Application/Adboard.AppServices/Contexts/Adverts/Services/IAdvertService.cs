using Adboard.Contracts.Adverts;

namespace Adboard.AppServices.Contexts.Adverts.Services;

public interface IAdvertService
{
    Task<Guid> AddAsync(CreateAdvertDto createDto);
}