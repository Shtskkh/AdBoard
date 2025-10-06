using Adboard.Domain.SeedWorks;

namespace Adboard.Domain.Entities;

public class AccountStatus : IEntity<int>
{
    public int Id { get; set; }
    public string Title { get; set; }
    
    // Navigation Properties
    public ICollection<User> Users { get; set; }
}