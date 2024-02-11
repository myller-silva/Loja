using Loja.Application.Contracts;
using Loja.Application.Dto.Loja;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Loja.API.Controllers;

[ApiController]
[Route("loja")]
public class LojaController : ControllerBase
{
    private readonly ILojaService _service;

    public LojaController(ILojaService service)
    {
        _service = service;
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Obtém uma lista de lojas com base nos parâmetros fornecidos.",
        Tags = new[] { "Loja" })]
    [ProducesResponseType(typeof(List<LojasDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get([FromQuery] LojasDto lojasDto)
    {
        var response = await _service.Get(lojasDto);
        return Ok(response);
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Obtém uma loja com base no identificador.", Tags = new[] { "Loja" })]
    [ProducesResponseType(typeof(Domain.Entities.Loja), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(int id)
    {
        var response = await _service.Get(id);
        if (response != null)
        {
            return Ok(response);
        }

        return NotFound();
    }


    [HttpGet("{lojaId}/produtos/{produtoId}/desconto/{usuarioId}")]
    [SwaggerOperation(Summary = "Consultar desconto aplicado a um produto para um usuário específico.",
        Tags = new[] { "Loja" })]
    [ProducesResponseType(typeof(Domain.Entities.Loja), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(int lojaId, int produtoId, int usuarioId)
    {
        var response = await _service.DescontoEmProdutoParaUsuario(lojaId, produtoId, usuarioId);
        if (response != null)
        {
            return Ok(response);
        }

        return NotFound();
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Cria uma nova loja.", Tags = new[] { "Loja" })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post(CreateLojaDto loja)
    {
        var response = await _service.Create(loja);
        if (response)
        {
            return NoContent();
        }

        return BadRequest();
    }

    [HttpPut]
    [SwaggerOperation(Summary = "Atualiza uma loja existente.", Tags = new[] { "Loja" })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update(UpdateLojaDto loja)
    {
        var response = await _service.Update(loja);
        if (response)
        {
            return NoContent();
        }

        return BadRequest();
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Exclui uma loja com base no identificador.", Tags = new[] { "Loja" })]
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