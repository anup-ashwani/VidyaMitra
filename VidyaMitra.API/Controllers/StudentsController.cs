using Microsoft.AspNetCore.Mvc;
using VidyaMitra.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace VidyaMitra.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class StudentsController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public StudentsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet("{id}/history")]
    public async Task<IActionResult> GetStudentAcademicHistory(int id)
    {
        var student = await _unitOfWork.Students.GetStudentWithEnrollmentsAsync(id);
        
        if (student == null) 
            return NotFound($"Student with ID {id} does not exist.");

        return Ok(student);
    }
}
