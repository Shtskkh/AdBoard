using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Adboard.AppServices.Utilities.Jwt;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Adboard.AppServices.Utilities.Tokens;

public class TokenService(IOptions<JwtOptions> jwtOptions) : ITokenService
{

    private readonly string _emailSecretKey = jwtOptions.Value.EmailSecretKey;
    
    public string GenerateEmailConfirmationToken(string email)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Email, email),
        };
        
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_emailSecretKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddHours(24),
            signingCredentials: credentials
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public async Task<string> VerifyEmailConfirmationTokenAsync(string token)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_emailSecretKey));
        var handler = new JwtSecurityTokenHandler();
        
        var tokenValidationResult = await handler.ValidateTokenAsync(token, new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = key,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
        });

        if (!tokenValidationResult.IsValid)
        {
            throw new SecurityTokenValidationException(tokenValidationResult.Exception.Message);
        }

        tokenValidationResult.Claims.TryGetValue(ClaimTypes.Email, out var email);
        
        return email.ToString() ?? throw new SecurityTokenValidationException("Email is not represented.");
    }
}