using AuthApi.Data;
using AuthApi.Model;
using AuthApi.Model.Dto;
using AuthApi.Services.Interface;
using Azure;
using Microsoft.AspNetCore.Identity;
using System.Globalization;

namespace AuthApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly AuthDbContext _authDbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly ResponseDto _response;

        public AuthService(AuthDbContext authDbContext, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IJwtTokenGenerator jwtTokenGenerator)
        {
            _authDbContext = authDbContext;
            _userManager   = userManager;
            _roleManager= roleManager;
            _jwtTokenGenerator = jwtTokenGenerator;
            _response = new ResponseDto { IsSuccess = false};
        }

        public async Task<ResponseDto> Register(AuthRegRequestDto registrationRequestDto)
        {
            ApplicationUser user = new()
            {
                UserName = registrationRequestDto.Email,
                NormalizedUserName = registrationRequestDto.Email,
                Email = registrationRequestDto.Email,
                NormalizedEmail = registrationRequestDto.Email.ToUpper(),
                PhoneNumber = registrationRequestDto.PhoneNumber,
                FullName = registrationRequestDto.Name
            };

            try
            {
                var result = await _userManager.CreateAsync(user, GeneratePassword(registrationRequestDto.Name));
                

                if (result.Succeeded)
                {
                    var userToReturn = _authDbContext.ApplicationUsers.First(u => u.UserName == registrationRequestDto.Email);
                    //UserDto userDto = new()
                    //{
                    //    Email = userToReturn.Email,
                    //    Id = userToReturn.Id,
                    //    Name = userToReturn.Name,
                    //    PhoneNumber = userToReturn.PhoneNumber
                    //};
                    //return userDto;

                    _response.IsSuccess = true;
                    _response.Message = userToReturn.Id;
                }
                else
                {
                    if (string.Equals(result.Errors.FirstOrDefault().Code, "DuplicateUserName"))
                    {
                        var registeredUser = await _userManager.FindByEmailAsync(registrationRequestDto.Email);

                        if (registeredUser != null)
                        {
                            _response.IsSuccess = true;
                            _response.Message = registeredUser.Id;
                        }
                    }
                    else
                    {
                        _response.Message = result.Errors.FirstOrDefault().Description;
                    }
                }
            }
            catch (Exception ex)
            {
                _response.Message = "Error encountered. Please contact administrator.";
            }

            return _response;
        }

        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            var user = _authDbContext.ApplicationUsers.First(u => u.UserName.ToLower() == loginRequestDto.Username.ToLower());
            bool isValid = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);
            if(user == null || !isValid)
            {
                return new LoginResponseDto { User = null, Token = string.Empty };
            }

            //if user found, Generate Jwt Token
            var roles = await _userManager.GetRolesAsync(user);
            var token = _jwtTokenGenerator.GenerateToken(user, roles);
            LoginResponseDto response = new LoginResponseDto()
            {
                User = new()
                {
                    Id = user.Id,
                    Name = user.FullName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                },
                Token = token
            };

            return response;
        }
        public async Task<bool> AssignRole(string email, string roleName)
        {
            var user = _authDbContext.ApplicationUsers.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());
            if(user != null)
            {
                if(!_roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult())
                {
                    _roleManager.CreateAsync(new IdentityRole(roleName)).GetAwaiter().GetResult();
                }
                await _userManager.AddToRoleAsync(user, roleName.ToUpper());
                return true;
            }
            return false;

        }

        //----------------------------------------------------------------------------

        private string GeneratePassword(string name)
        {
            string password = "";
            if (string.IsNullOrEmpty(name))
                return null;
            else
            {
                TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
                name = textInfo.ToTitleCase(name);
                
                password = name.Length >= 4 ? $"{name.Substring(0, 4)}@{123}"  
                    : $"{name.PadRight(4, '0')}@{123}"; 
            }
            return password;
        }


    }
}
