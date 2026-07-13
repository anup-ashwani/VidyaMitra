using AuthApi.Model.Dto;
using AuthApi.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthApi.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthApiController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ResponseDto _response;

        public AuthApiController(IAuthService authService)
        {
            _authService = authService;
            _response = new ResponseDto { IsSuccess = true };
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] AuthRegRequestDto model)
        {
            var result = await _authService.Register(model);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto model)
        {
            var loginResponse = await _authService.Login(model);
            if (loginResponse.User == null)
            {
                _response.IsSuccess = false;
                _response.Message = "Username or Password is incorrect.";
                return BadRequest(_response);
            }

            _response.Result = loginResponse;
            return Ok(_response);
        }

        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRole([FromBody] AuthRegRequestDto model)
        {
            var assignRole = await _authService.AssignRole(model.Email, model.Role);
            if (!assignRole)
            {
                _response.IsSuccess = false;
                _response.Message = "Error encountered while assign role";
                return BadRequest(_response);
            }
            return Ok(_response);
        }


    }
}
