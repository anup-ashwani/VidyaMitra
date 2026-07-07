using Microsoft.AspNetCore.Mvc;
using VidyaMitra.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using VidyaMitra.Repository.Data;
using VidyaMitra.Domain.Dto;

namespace VidyaMitra.API.Controllers;

[ApiController]
[Route("api/stu")]
//[Authorize]
public class StudentsController : ControllerBase
{
    //private readonly IUnitOfWork _unitOfWork;
    private readonly ResponseDto _response;
    private readonly IStudentService _studentService;

    public StudentsController(IStudentService studentService )
    {
        //_unitOfWork = unitOfWork;
        _studentService = studentService;
        _response = new ResponseDto { IsSuccess = true};
    }

    //[HttpGet("{id}/history")]
    //public async Task<IActionResult> GetStudentAcademicHistory(int id)
    //{
    //    var student = await _unitOfWork.Students.GetStudentWithEnrollmentsAsync(id);

    //    if (student == null)
    //        return NotFound($"Student with ID {id} does not exist.");

    //    return Ok(student);

    //}


    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            _response.Result = await _studentService.GetStudentDetailAsync(id, "");
            return Ok(_response);
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.Message = ex.Message;
            return BadRequest();
        }
    }

    [HttpGet]
    [Route("GetByName/{name}")]
    public async Task<IActionResult> GetByName(string name)
    {
        try
        {
            _response.Result = await _studentService.GetStudentDetailAsync(0, name);
            return Ok(_response);
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.Message = ex.Message;
            return BadRequest();
        }
    }

    [HttpPost]
    [Authorize(Roles = "ADMIN")]
    public ResponseDto Post([FromBody] InitialDetailDto student)
    {
        return _response;
    }
}
