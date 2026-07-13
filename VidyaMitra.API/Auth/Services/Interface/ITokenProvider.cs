namespace VidyaMitra.API.Auth.Services.Interface
{
    public interface ITokenProvider
    {
        void SetToken(string token);
        string? GetToken();
        void ClearToken();
    }
}
