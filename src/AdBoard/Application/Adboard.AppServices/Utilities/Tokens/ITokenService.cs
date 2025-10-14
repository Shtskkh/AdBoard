namespace Adboard.AppServices.Utilities.Tokens;

public interface ITokenService
{
    string GenerateEmailConfirmationToken(Guid id);
    Task<string> VerifyEmailConfirmationTokenAsync(string token);
}