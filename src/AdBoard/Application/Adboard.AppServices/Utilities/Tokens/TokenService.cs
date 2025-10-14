using System.Security.Claims;
using System.Text;
using Adboard.AppServices.Utilities.Jwt;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace Adboard.AppServices.Utilities.Tokens;

public class TokenService(IOptions<JwtOptions> jwtOptions, ILogger<TokenService> logger) : ITokenService
{

    private readonly string _emailSecretKey = jwtOptions.Value.EmailSecretKey;
    
    public string GenerateEmailConfirmationToken(Guid id)
    {
        var claims = new Dictionary<string, object>
        {
            [ClaimTypes.NameIdentifier] =  id.ToString(),
        };
        
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_emailSecretKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


        var descriptor = new SecurityTokenDescriptor
        {
            Issuer = "MyIssuer",
            Audience = "MyAudience",
            Claims = claims,
            Expires = DateTime.UtcNow.AddHours(24),
            SigningCredentials = credentials
        };

        return new JsonWebTokenHandler().CreateToken(descriptor);
    }

    public async Task<string> VerifyEmailConfirmationTokenAsync(string token)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_emailSecretKey));
        var handler = new JsonWebTokenHandler();
        
        var tokenValidationResult = await handler.ValidateTokenAsync(token, new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = "MyIssuer",
            ValidAudience = "MyAudience",
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = key,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
        });

        if (!tokenValidationResult.IsValid)
        {
            logger.LogError("Invalid token: {ExceptionMessage}", tokenValidationResult.Exception.Message);
            throw new SecurityTokenValidationException(tokenValidationResult.Exception.Message);
        }

        tokenValidationResult.Claims.TryGetValue(ClaimTypes.NameIdentifier, out var guid);
        
        logger.LogInformation("Token verified");
        
        return guid?.ToString() ?? throw new SecurityTokenValidationException("Guid is not present.");
    }
}