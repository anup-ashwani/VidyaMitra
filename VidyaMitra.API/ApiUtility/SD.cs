namespace VidyaMitra.API.ApiUtility
{
    public class SD //static details 
    {
        public static string AuthApiBase { get; set; } = string.Empty;

        public static string RoleAdmin { get; set; } = "Admin";
        public static string RoleGuest { get; set; } = "Guest";
        public static string RoleStudent { get; set; } = "Student";

        public static string TokenCookie { get; set; } = "JWTToken";

        public enum ApiType
        {
            GET, POST, PUT, DELETE
        }
    }
}
