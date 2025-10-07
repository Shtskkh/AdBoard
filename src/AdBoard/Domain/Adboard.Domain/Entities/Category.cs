using Adboard.Domain.SeedWorks;

namespace Adboard.Domain.Entities;

public class Category : IEntity<int>
{
    public int Id { get; set; }
    public string Title { get; set; }
    
    // Navigation Properties
    public ICollection<Subcategory> Subcategories { get; set; }
}