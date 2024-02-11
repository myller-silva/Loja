using Loja.Application.Contracts;
using Loja.Application.Dto.Estoque;
using Loja.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Loja.API.Controllers;

[ApiController]
[Route("estoque")]
public class EstoqueController : ControllerBase
{
    private readonly IEstoqueService _service;

    public EstoqueController(IEstoqueService service)
    {
        _service = service;
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Obtém uma lista de estoques com base nos parâmetros fornecidos.",
        Tags = new[] { "Estoque" })]
    [ProducesResponseType(typeof(List<Estoque>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get([FromQuery] EstoquesDto estoquesDto)
    {
        var response = await _service.Get(estoquesDto);
        return Ok(response);
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Obtém um estoque com base no identificador.", Tags = new[] { "Estoque" })]
    [ProducesResponseType(typeof(Estoque), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
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
    [SwaggerOperation(Summary = "Cria um novo estoque.", Tags = new[] { "Estoque" })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post(CreateEstoqueDto estoqueDto)
    {
        var response = await _service.Create(estoqueDto);
        if (response)
        {
            return NoContent();
        }

        return BadRequest();
    }

    [HttpPut]
    [SwaggerOperation(Summary = "Atualiza um estoque existente.", Tags = new[] { "Estoque" })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update(UpdateEstoqueDto estoque)
    {
        var response = await _service.Update(estoque);
        if (response)
        {
            return NoContent();
        }

        return BadRequest();
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Exclui um estoque com base no identificador.", Tags = new[] { "Estoque" })]
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