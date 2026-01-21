using DemoWebAPI.Data;
using DemoWebAPI.Data.Entities;
using DemoWebAPI.DTO.Requests;
using DemoWebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoWebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController (IUserService _service) : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        return Ok();
    }

    [HttpPost] 
    public async Task<IActionResult> CreateUser(UserAddRequestDTO dto)
    {
        var emailExists = await _service.EmailExists(dto.Email);

        if (emailExists)
            return BadRequest(new { message = "L'email est déjà prise." });

        var user = await _service.AddUserAsync(dto);

        return Ok(user);
    }

}
