using Microsoft.AspNetCore.Mvc;
using WebApplication5.DTOs;
using WebApplication5.Exceptions;
using WebApplication5.Services;

namespace WebApplication5.Controllers;
[ApiController]
[Route("[controller]")]
public class UczestnikWydarzenieController(IDbService service):ControllerBase
{
    [HttpPut]
    public async Task<IActionResult> RejestrujUczestnika([FromBody] UczestnikWydarzeniePutDto dto)
    {
        try
        {
            await service.RejestrujUczestnika(dto);
            return NoContent();
        }
        catch (NoSpaceException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete]
    public async Task<IActionResult> AnulujRejestracje([FromBody] UczestnikWydarzeniePutDto dto)
    {
        try
        {
            await service.AnulujRejestracje(dto);
            return NoContent();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
    
}