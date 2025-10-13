namespace Adboard.AppServices.Utilities.Tokens;

public interface ITokenService
{
    Task<string> GenerateEmailConfirmationToken(string email);
}