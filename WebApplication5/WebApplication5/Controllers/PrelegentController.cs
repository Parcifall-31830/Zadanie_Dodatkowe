
using Microsoft.AspNetCore.Mvc;
using WebApplication5.DTOs;
using WebApplication5.Exceptions;
using WebApplication5.Services;

namespace WebApplication5.Controllers;

[ApiController]
[Route("[controller]")]
public class PrelegentController(IDbService service):ControllerBase
{
    [HttpPut]
    public async Task<IActionResult> PrzypiszPrelegenta([FromBody]PrelegentPutDto prelPutDto)
    {
        try
        {
            await service.PrzypiszPreleganta(prelPutDto);
            return NoContent();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}