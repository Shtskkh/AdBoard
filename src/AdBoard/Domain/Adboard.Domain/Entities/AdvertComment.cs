using Adboard.Domain.SeedWorks;

namespace Adboard.Domain.Entities;

public class AdvertComment : IEntity<Guid>
{
    public Advert Advert { get; set; }
    public User User { get; set; }
    public Guid Id { get; set; }
    public string Text { get; set; }
    public DateTime CreatedAt { get; set; }
}