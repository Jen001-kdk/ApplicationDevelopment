using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AuthController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    [HttpPost("register-student")]
    public async Task<IActionResult> RegisterStudent([FromBody] RegisterDto model)
    {
        return await RegisterUser(model, "Student");
    }

    [HttpPost("register-instructor")]
    public async Task<IActionResult> RegisterInstructor([FromBody] RegisterDto model)
    {
        return await RegisterUser(model, "Instructor");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto model)
    {
        if (string.IsNullOrWhiteSpace(model.Email) || string.IsNullOrWhiteSpace(model.Password))
            return BadRequest(new { message = "Email and password are required." });

        var user = await _userManager.FindByEmailAsync(model.Email);

        if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
        {
            var roles = await _userManager.GetRolesAsync(user);

            return Ok(new
            {
                message = "Login successful!",
                userId = user.Id,
                userName = user.FullName,
                role = roles.FirstOrDefault()
            });
        }

        return Unauthorized(new { message = "Invalid email or password." });
    }

    private async Task<IActionResult> RegisterUser(RegisterDto model, string role)
    {
        if (string.IsNullOrWhiteSpace(model.Email) || string.IsNullOrWhiteSpace(model.Password) || string.IsNullOrWhiteSpace(model.FullName))
            return BadRequest(new { message = "Email, password, and full name are required." });

        var existingUser = await _userManager.FindByEmailAsync(model.Email);
        if (existingUser != null)
            return Conflict(new { message = "A user with this email already exists." });

        if (!await _roleManager.RoleExistsAsync(role))
            await _roleManager.CreateAsync(new IdentityRole(role));

        var user = new ApplicationUser
        {
            UserName = model.Email,
            Email = model.Email,
            FullName = model.FullName
        };

        var result = await _userManager.CreateAsync(user, model.Password);

        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, role);
            return Ok(new { message = $"{role} registered successfully!" });
        }

        return BadRequest(result.Errors);
    }
}

