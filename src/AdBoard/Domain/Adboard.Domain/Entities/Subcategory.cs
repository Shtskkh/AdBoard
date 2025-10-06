using Adboard.Domain.SeedWorks;

namespace Adboard.Domain.Entities;

public class Subcategory : IEntity<int>
{
    public int Id { get; set; }
    public string Title { get; set; }
    
    // FKs
    public int CategoryId { get; set; }
    
    // Navigation Properties
    public Category Category { get; set; }
    public ICollection<Advert> Adverts { get; set; }
}