using Adboard.Contracts.Users;

namespace Adboard.Contracts.Adverts;

public class AdvertDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public ShortUserDto User { get; set; }
}