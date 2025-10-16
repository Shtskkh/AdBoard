namespace Adboard.Contracts.Users;

public class UserAuthInfoDto
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}