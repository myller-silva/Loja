using Loja.Application.Contracts;
using Loja.Application.Dto.Usuario;
using Loja.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Loja.API.Controllers;

[ApiController]
[Route("usuario")]
public class UsuarioController: ControllerBase
{
    private readonly IUsuarioService _service;
    public UsuarioController(IUsuarioService service)
    {
        _service = service;
    }
    [HttpGet]
    [SwaggerOperation(Summary = "Obtém uma lista de usuários com base nos parâmetros fornecidos.", Tags = new[] { "Usuário" })]
    [ProducesResponseType(typeof(List<Usuario>), StatusCodes.Status200OK)]

    public async Task<IActionResult> Get([FromQuery]UsuarioDto usuariosDto)
    {
        var usuarios = await _service.Get(usuariosDto); 
        return Ok(usuarios); 
    }
    
    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Obtém um usuário com base no identificador.", Tags = new[] { "Usuário" })]
    [ProducesResponseType(typeof(Usuario), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(int id)
    {
        var usuarios = await _service.Get(id);
        if (usuarios is not null)
        {
            return Ok(usuarios);
        }
        return NotFound();
    }
    
    [HttpPost]
    [SwaggerOperation(Summary = "Cria um novo usuário.", Tags = new[] { "Usuário" })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(CreateUsuarioDto usuarioDto)
    {
        var response = await _service.Create(usuarioDto);
        if (response)
        {
            return NoContent();
        }
        return BadRequest();
    }
    
    [HttpPut]
    [SwaggerOperation(Summary = "Atualiza um usuário existente.", Tags = new[] { "Usuário" })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update(UpdateUsuarioDto usuarioDto)
    {
        var usuario = await _service.Update(usuarioDto);
        if (usuario)
        {
            return NoContent();
        }
        return BadRequest();
    }
    
    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Exclui um usuário com base no identificador.", Tags = new[] { "Usuário" })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(int id)
    {
        var removido = await _service.Delete(id);
        if (removido)
        {
            return NoContent();
        }
        return BadRequest();
    }
    
}