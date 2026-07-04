using Microsoft.AspNetCore.Mvc;
using VidyaMitra.Application.Interfaces;

namespace VidyaMitra.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IIdentityService identityService) : ControllerBase
{
    private readonly IIdentityService _identityService = identityService;

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        // Simple placeholder credential evaluation. 
        // In real-world projects, evaluate these values against hashes saved inside PostgreSQL.
        if (request.Email == "admin@college.com" && request.Password == "Password123")
        {
            var token = _identityService.GenerateToken("1", request.Email, "Admin");
            return Ok(new { Token = token });
        }

        return Unauthorized("Invalid credentials.");
    }
}
public record LoginRequest(string Email, string Password);
