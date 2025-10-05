using Adboard.Domain.SeedWorks;

namespace Adboard.Domain.Entities;

public class User : IEntity<Guid>
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public AccountStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public ICollection<Advert> Adverts { get; set; }
    
}