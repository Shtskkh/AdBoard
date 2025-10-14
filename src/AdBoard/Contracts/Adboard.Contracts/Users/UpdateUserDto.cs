namespace Adboard.Contracts.Users;

public class UpdateUserDto
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string? LastName { get; set; }
    public int? AccountStatusId { get; set; }
    public int? RoleId { get; set; }
}