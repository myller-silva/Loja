using Loja.Application.Contracts;
using Loja.Application.Dto.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace Loja.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController: ControllerBase
{
    private readonly IUsuarioService _service;
    public UsuarioController(IUsuarioService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery]UsuarioDto usuariosDto)
    {
        var usuarios = await _service.Get(usuariosDto); 
        return Ok(usuarios); 
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var usuarios = await _service.Get(id);
        if (usuarios is not null)
        {
            return Ok(usuarios);
        }
        return BadRequest();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(CreateUsuarioDto usuarioDto)
    {
        var usuario = await _service.Create(usuarioDto);
        if (usuario)
        {
            return Ok(usuario);
        }
        return BadRequest();
    }
    [HttpPut]
    public async Task<IActionResult> Update(UpdateUsuarioDto usuarioDto)
    {
        var usuario = await _service.Update(usuarioDto);
        if (usuario)
        {
            return Ok(usuario);
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