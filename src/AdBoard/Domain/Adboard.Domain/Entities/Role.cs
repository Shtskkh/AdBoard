using Adboard.Domain.SeedWorks;

namespace Adboard.Domain.Entities;

public class Role : IEntity<int>
{
    public int Id { get; set; }
    public string Title { get; set; }
    
    // Navigation properties
    public ICollection<User> Users { get; set; }
}