using VidyaMitra.API.Auth.Dto;
using VidyaMitra.API.Auth.Services.Interface;
using VidyaMitra.API.Dto;
using VidyaMitra.API.ApiUtility;
using static VidyaMitra.API.ApiUtility.SD;
using VidyaMitra.Domain.Dto;

namespace VidyaMitra.API.Auth.Services
{
    public class AuthService : IAuthService
    {
        private readonly IBaseService _baseService;

        public AuthService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> AssignRoleAsync(AuthRegRequestDto registrationRequestDto)
        {
            return await _baseService.SendAsync(new ApiRequestDto()
            {
                ApiType = ApiType.POST,
                Data = registrationRequestDto,
                Url = SD.AuthApiBase + "/api/auth/AssignRole"
            });
        }

        public async Task<ResponseDto?> LoginAsync(LoginRequestDto loginRequestDto)
        {
            return await _baseService.SendAsync(new ApiRequestDto()
            {
                ApiType = ApiType.POST,
                Data = loginRequestDto,
                Url = SD.AuthApiBase + "/api/auth/Login"
            }, withBearer: false);
        }

        public async Task<ResponseDto?> RegisterAsync(AuthRegRequestDto registrationRequestDto)
        {
            return await _baseService.SendAsync(new ApiRequestDto()
            {
                ApiType = ApiType.POST,
                Data = registrationRequestDto,
                Url = SD.AuthApiBase + "/api/auth/Register"
            }, withBearer: false);
        }
    }
}
