
using Microsoft.AspNetCore.Identity;

namespace SurveyBasket.Services
{
    public class AuthService(UserManager<ApplicationUser>userManager) : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager = userManager;

        public async Task<AuthResponse?> GetTokenAsync(string email, string password,
            CancellationToken cancellationToken)
        {
            //check user in db
            var user = await _userManager.FindByEmailAsync(email);
            if (user is null)
                return null;
            //check password
            var isValidPassword = await _userManager.CheckPasswordAsync(user, password);
            if(!isValidPassword)
                return null;
            //generate jwt token


            //return AuthResponse
            return new AuthResponse(Guid.NewGuid().ToString(),"test123@gmail.com", "Muhammad", "Ahmed", 
                "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiYWRtaW4iOnRydWUsImlhdCI6MTUxNjIzOTAyMn0.KMUFsIDTnFmyG3nMiGM6H9FNFUROf3wh7SmqJp-QV30", 3600);

        }
    }
}
