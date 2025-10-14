namespace Adboard.AppServices.Utilities.Tokens;

public interface ITokenService
{
    string GenerateEmailConfirmationToken(string email);
    Task<string> VerifyEmailConfirmationTokenAsync(string token);
}