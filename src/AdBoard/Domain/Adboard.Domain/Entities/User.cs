using Adboard.Domain.SeedWorks;

namespace Adboard.Domain.Entities;

public class User : IEntity<Guid>
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime CreatedAt { get; set; }
    
    // FKs
    public int RoleId { get; set; }
    public int AccountStatusId { get; set; }

    // Navigation Properties
    public Role Role { get; set; }
    public AccountStatus AccountStatus { get; set; }
    public ICollection<Advert> Adverts { get; set; }
    public ICollection<AdvertComment> AdvertComments { get; set; }
}