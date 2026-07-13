namespace AuthApi.Model
{
    public sealed class JwtOptions
    {
        public string? Secret { get; set; } = string.Empty;
        public string? Issuer { get; set; } = string.Empty;
        public string? Audience { get; set; } = string.Empty;
        public int ExpiryInMinutes { get; set; } = 60;

    }
}
