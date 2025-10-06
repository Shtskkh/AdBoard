using Adboard.Domain.SeedWorks;

namespace Adboard.Domain.Entities;

public class AdvertPhoto : IEntity<Guid>
{
    public Guid Id { get; set; }
    
    // FKs
    public Guid AdvertId { get; set; }
    
    // Navigation Properties
    public Advert Advert { get; set; }
}