using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SurveyBasket.Authentication
{
    public class JwtProvider : IJwtProvider
    {
        public (string token, int expiresIn) GenerateToken(ApplicationUser user)
        {
            Claim[] claims =
            [
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email!),
                new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            ];
            
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(""));

            var signingCredintials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var expiresIn = 60;

            var token = new JwtSecurityToken(
                issuer: "SurveyBasketApp",
                audience: "SurveyBasketApp users",
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expiresIn),
                signingCredentials: signingCredintials

                );
            return (token:new JwtSecurityTokenHandler().WriteToken(token),expiresIn:expiresIn * 60);
        }
    }
}
