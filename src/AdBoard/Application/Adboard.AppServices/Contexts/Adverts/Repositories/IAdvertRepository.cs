using Adboard.Contracts.Adverts;
using Adboard.Domain.Entities;

namespace Adboard.AppServices.Contexts.Adverts.Repositories;

public interface IAdvertRepository
{
    Task<Guid> AddAsync(CreateAdvertDto createDto);
}