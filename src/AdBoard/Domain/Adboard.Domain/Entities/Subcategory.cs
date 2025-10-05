using Adboard.Domain.SeedWorks;

namespace Adboard.Domain.Entities;

public class Subcategory : IEntity<int>
{
    public int Id { get; set; }
    public string Title { get; set; }
    
}