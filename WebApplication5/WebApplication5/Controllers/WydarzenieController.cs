using Microsoft.AspNetCore.Mvc;
using WebApplication5.DTOs;
using WebApplication5.Exceptions;
using WebApplication5.Models;
using WebApplication5.Services;

namespace WebApplication5.Controllers;

[ApiController]
[Route("[controller]")]
public class WydarzenieController(IDbService service):ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetWydarzenie([FromRoute] int id)
    {
        try
        {
            return Ok(await service.GetWydarzenie(id));
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllWydarzenie()
    {
        return Ok(await service.GetAllWydarzenia());
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateWydarzenie([FromBody] WydarzenieDto wydarzenie)
    {
        try
        {
            var newWydarzenie = await service.CreateWydarzenie(wydarzenie);
            return CreatedAtAction(nameof(GetWydarzenie),new {id = newWydarzenie.IdWydarzenie}, newWydarzenie);
        }
        catch (WrongDateException ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
}