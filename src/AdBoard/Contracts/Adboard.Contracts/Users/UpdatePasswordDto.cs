namespace Adboard.Contracts.Users;

public class UpdatePasswordDto
{
    public Guid Id { get; set; }
    public string OldPassword { get; set; }
    public string NewPassword { get; set; }
}