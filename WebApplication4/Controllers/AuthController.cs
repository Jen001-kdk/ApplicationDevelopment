using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication4.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;

    public AuthController(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
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
       
        var user = await _userManager.FindByEmailAsync(model.Email);

     
        if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
        {
           
            var roles = await _userManager.GetRolesAsync(user);

           
            return Ok(new
            {
                message = "Login successful!",
                userName = user.FullName,
                role = roles.FirstOrDefault()
            });
        }

       
        return Unauthorized(new { message = "Invalid email or password." });
    }

    private async Task<IActionResult> RegisterUser(RegisterDto model, string role)
    {
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