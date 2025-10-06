using Adboard.Domain.SeedWorks;

namespace Adboard.Domain.Entities;

public class Advert : IEntity<Guid>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public User User { get; set; }
    public DateTime CreatedAt { get; set; }
    public Category Category { get; set; }
    public ICollection<Subcategory> Subcategories { get; set; }
}