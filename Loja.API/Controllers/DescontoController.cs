using Loja.Application.Contracts;
using Loja.Application.Dto.Desconto;
using Loja.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;


namespace Loja.API.Controllers;

[ApiController]
[Route("desconto")]
public class DescontoController : ControllerBase
{
    private readonly IDescontoService _service;

    public DescontoController(IDescontoService service)
    {
        _service = service;
    }

    [HttpGet("{lojaId}/{usuarioId}")]
    [SwaggerOperation(Summary = "Obtém os descontos disponíveis para um usuário em uma loja específica.")]
    [ProducesResponseType(typeof(List<Desconto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(int lojaId, int usuarioId)
    {
        var descontos = await _service.ObterDescontosCliente(lojaId, usuarioId);
        return Ok(descontos);
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Obtém uma lista de descontos com base nos parâmetros fornecidos.",
        Tags = new[] { "Desconto" })]
    [ProducesResponseType(typeof(List<Desconto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get([FromQuery] DescontosDto descontosDto)
    {
        var estoque = await _service.Get(descontosDto);
        return Ok(estoque);
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Obtém um desconto com base no identificador.", Tags = new[] { "Desconto" })]
    [ProducesResponseType(typeof(Desconto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Desconto), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(int id)
    {
        var response = await _service.Get(id);
        if (response is not null)
        {
            return Ok(response);
        }

        return NotFound();
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Cria um novo desconto.", Tags = new[] { "Desconto" })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post(CreateDescontoDto descontoDto)
    {
        var response = await _service.Create(descontoDto);
        if (response)
        {
            return NoContent();
        }

        return BadRequest();
    }

    [HttpPut]
    [SwaggerOperation(Summary = "Atualiza um desconto existente.", Tags = new[] { "Desconto" })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update(UpdateDescontoDto desconto)
    {
        var response = await _service.Update(desconto);
        if (response)
        {
            return NoContent();
        }

        return BadRequest();
    }

    [HttpDelete]
    [SwaggerOperation(Summary = "Exclui um desconto com base no identificador.", Tags = new[] { "Desconto" })]
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