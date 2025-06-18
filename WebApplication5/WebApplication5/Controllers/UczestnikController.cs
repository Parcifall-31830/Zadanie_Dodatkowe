using Microsoft.AspNetCore.Mvc;
using WebApplication5.DTOs;
using WebApplication5.Exceptions;
using WebApplication5.Services;

namespace WebApplication5.Controllers;
[ApiController]
[Route("[controller]")]
public class UczestnikController(IDbService service):ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllUczestnicy()
    {
        return Ok(await service.GetAllUczestnik());
    }
    
    
}