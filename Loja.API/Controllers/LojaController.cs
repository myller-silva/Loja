using Loja.Application.Contracts;
using Loja.Application.Dto.Loja;
using Microsoft.AspNetCore.Mvc;

namespace Loja.API.Controllers;

[ApiController]
[Route("[controller]")]
public class LojaController: ControllerBase
{
    private readonly ILojaService _service;

    public LojaController(ILojaService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] LojasDto lojasDto)
    {
        var lojas = await _service.Get(lojasDto); 
        return Ok(lojas);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var lojas = await _service.Get(id);
        if (lojas is not null)
        {
            return Ok(lojas);
        }
        return BadRequest();
    }
     

    [HttpPost]
    public async Task<IActionResult> Post(CreateLojaDto loja )
    {
        var response = await _service.Create(loja);
        if (response)
        {
            return Ok(loja);
        }
        return BadRequest();
    }
    
    
    [HttpPut]
    public async Task<IActionResult> Update(UpdateLojaDto loja)
    {
        var response = await _service.Update(loja);
        if (response)
        {
            return Ok(response);
        }
        return BadRequest();
    }
    
    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var removido = await _service.Delete(id);
        if (removido)
        {
            return Ok();
        }
        return BadRequest();
    }
}