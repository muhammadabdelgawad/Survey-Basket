
using SurveyBasket.Authentication;
using System.Security.Cryptography;

namespace SurveyBasket.Services
{
    public class AuthService(UserManager<ApplicationUser> userManager, IJwtProvider jwtProvider) : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager = userManager;
        private readonly IJwtProvider _jwtProvider = jwtProvider;
        private readonly int _refreshTokenExpiryDays = 14;

        public async Task<AuthResponse?> GetTokenAsync(string email, string password,
            CancellationToken cancellationToken = default)
        {
            
            var user = await _userManager.FindByEmailAsync(email);
            if (user is null)
                return null;
            
            var isValidPassword = await _userManager.CheckPasswordAsync(user, password);
            if (!isValidPassword)
                return null;
            
            var (token, expiresIn) = _jwtProvider.GenerateToken(user);

            var refreshToken = GenerateResfreshToken();

            var refreshTokenExpiration = DateTime.UtcNow.AddDays(_refreshTokenExpiryDays);

            user.RefreshTokens.Add(new RefreshToken
            {
                Token = refreshToken,
                ExpiresOn = refreshTokenExpiration
            });
            await _userManager.UpdateAsync(user);

            return new AuthResponse(user.Id, user.Email, user.FirstName, user.LastName,
                token, expiresIn,refreshToken, refreshTokenExpiration);

        }

        private static string GenerateResfreshToken()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        }
    
    }
}
