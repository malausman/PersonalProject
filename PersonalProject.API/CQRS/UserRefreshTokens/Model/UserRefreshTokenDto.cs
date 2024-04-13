namespace PersonalProject.API.CQRS.UserRefreshTokens.Model
{
    public class UserRefreshTokenDto
    {
        public string UserId { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
