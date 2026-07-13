using VidyaMitra.API.Auth.Dto;
using VidyaMitra.Domain.Dto;

namespace VidyaMitra.API.Auth.Services.Interface
{
    public interface IAuthService
    {
        Task<ResponseDto?> LoginAsync(LoginRequestDto loginRequestDto);
        Task<ResponseDto?> RegisterAsync(AuthRegRequestDto registrationRequestDto);
        Task<ResponseDto?> AssignRoleAsync(AuthRegRequestDto registrationRequestDto);
    }
}
