using Trust.Auth.RequestModels;
using Trust.Auth.ResponseModels;

namespace Trust.Auth.Services
{
    public interface IAuthService
    {
        AuthResponse Register(RegisterRequest model);
        AuthResponse Login(LoginRequest model, string ipAddress);
        void Logout();
        int GetIdFromToken(string token);
    }
}
