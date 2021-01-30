using Trust.Auth.Entities;

namespace Trust.Auth.ResponseModels
{
    public class AuthResponse
    {
        public Role   Role         { get; set; }
        public string Email        { get; set; }
        public string JwtToken     { get; set; }
        public string RefreshToken { get; set; }
    }
}
