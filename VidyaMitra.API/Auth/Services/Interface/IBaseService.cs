
using VidyaMitra.API.Auth.Dto;
using VidyaMitra.Domain.Dto;

namespace VidyaMitra.API.Auth.Services.Interface
{
    public interface IBaseService
    {
        Task<ResponseDto?> SendAsync(ApiRequestDto requestDto, bool withBearer = true);
    }
}
