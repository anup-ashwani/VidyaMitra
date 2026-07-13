using static VidyaMitra.API.ApiUtility.SD;

namespace VidyaMitra.API.Auth.Dto
{
    public class ApiRequestDto
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }
    }
}
