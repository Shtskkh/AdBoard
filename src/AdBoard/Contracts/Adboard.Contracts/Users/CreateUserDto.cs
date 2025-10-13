using Adboard.Domain.Enums;

namespace Adboard.Contracts.Users;

public class CreateUserDto
{
    public string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int RoleId { get; set; } = (int)RoleType.User;
}