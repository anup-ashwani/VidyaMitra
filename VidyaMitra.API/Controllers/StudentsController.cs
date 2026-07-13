using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VidyaMitra.API.ApiUtility;
using VidyaMitra.API.Auth.Dto;
using VidyaMitra.API.Auth.Services.Interface;
using VidyaMitra.Application.Interfaces;
using VidyaMitra.Domain.Dto;

namespace VidyaMitra.API.Controllers;

[ApiController]
[Route("api/stu/[action]")]
[Authorize]
public class StudentsController : ControllerBase
{
    private readonly ResponseDto _response;
    private readonly IStudentService _studentService;
    private readonly IAuthService _authService;
    private readonly ITokenProvider _tokenProvider;

    public StudentsController(IStudentService studentService, IAuthService authService, ITokenProvider tokenProvider)
    {
        _response = new ResponseDto { IsSuccess = true };
        _studentService = studentService;      
        _authService = authService;
        _tokenProvider = tokenProvider;
    }

    [HttpGet]
    public async Task<IActionResult> GetProfileDetail()
    {
        try
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            _response.Result = await _studentService.GetStudentDetailAsync(email);
            return Ok(_response);
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.Message = ex.Message;
            return BadRequest();
        }
    }

    //[HttpGet]
    //[Route("GetProfileDetail/{name}")]
    //public async Task<IActionResult> GetProfileDetail(string name)
    //{
    //    try
    //    {
    //        _response.Result = await _studentService.GetStudentDetailAsync(0, name);
    //        return Ok(_response);
    //    }
    //    catch (Exception ex)
    //    {
    //        _response.IsSuccess = false;
    //        _response.Message = ex.Message;
    //        return BadRequest();
    //    }
    //}

    [HttpPost]
    //[Authorize(Roles = "Admin")]
    [AllowAnonymous]
    public async Task<IActionResult> Register([FromBody] ProfileDetailDto student)
    {
        try
        {
            ResponseDto result = await RegisterUserAndRole(student); //For Authentication
            
            if (result != null && result.IsSuccess)
            {
                student.PersonalInfo.UserId = result.Message;
                var res = await _studentService.SaveStudentDetail(student);

                if (res.IsSuccess)
                    res.Message = "Student registered successfully";

                return Ok(res);
            }
            else
            {
                return BadRequest(result);
            }
        }
        catch (Exception ex)
        {
            return BadRequest();
        }
    }

    //------------------------------------------
    private AuthRegRequestDto GetAuthRegRequest(ProfileDetailDto dto)
    {
        AuthRegRequestDto request = new AuthRegRequestDto();
        if(dto.PersonalInfo != null)
        {
            request.Email = dto.PersonalInfo.LoginEmail;
            request.Name = $"{dto.PersonalInfo.FirstName} {dto.PersonalInfo.LastName}";
        }
        if (dto.ContactDetail != null)
        {
            request.PhoneNumber = dto.ContactDetail.PhoneNumber;
        }
        request.Role = SD.RoleStudent;

        return request;
    }

    private async Task<ResponseDto> RegisterUserAndRole(ProfileDetailDto dto)
    {
        AuthRegRequestDto request = GetAuthRegRequest(dto);
        ResponseDto authResult = await _authService.RegisterAsync(request);

        if (authResult != null && authResult.IsSuccess)
        {
            var assignRole = await _authService.AssignRoleAsync(request);
            if (assignRole != null && !assignRole.IsSuccess)
            {
                authResult.IsSuccess = false;
                authResult.Message = assignRole.Message;
            }
        }

        return authResult;
    }
}
