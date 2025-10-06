using Adboard.Domain.SeedWorks;

namespace Adboard.Domain.Entities;

public class Advert : IEntity<Guid>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid PreviewPhoto { get; set; }
    public double Price { get; set; }
    public DateTime CreatedAt { get; set; }
    
    // FKs
    public Guid UserId { get; set; }

    // Navigation Properties
    public User User { get; set; }
    public ICollection<AdvertPhoto> Photos { get; set; }
    public ICollection<Subcategory> Subcategories { get; set; }
    public ICollection<AdvertComment> AdvertComments { get; set; }
}