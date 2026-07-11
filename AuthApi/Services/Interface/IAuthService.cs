using AuthApi.Model.Dto;

namespace AuthApi.Services.Interface
{
    public interface IAuthService
    {
        Task<ResponseDto> Register(AuthRegRequestDto registrationRequestDto);
        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
        Task<bool> AssignRole(string email, string roleName);
    }
}
