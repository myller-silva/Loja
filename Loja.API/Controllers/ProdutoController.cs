using Loja.Application.Contracts;
using Loja.Application.Dto.Produto;
using Loja.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Loja.API.Controllers;

[ApiController]
[Route("produto")]
public class ProdutoController: ControllerBase
{
    private readonly IProdutoService _service;

    public ProdutoController(IProdutoService service)
    {
        _service = service;
    }
    [HttpGet]
    [SwaggerOperation(Summary = "Obtém uma lista de produtos com base nos parâmetros fornecidos.", Tags = new[] { "Produto" })]
    [ProducesResponseType(typeof(List<Produto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get([FromQuery]ProdutosDto produtosDto)
    {
        var produtos = await _service.Get(produtosDto); 
        return Ok(produtos); 
    }
    
    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Obtém um produto com base no identificador.", Tags = new[] { "Produto" })]
    [ProducesResponseType(typeof(Produto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<IActionResult> Get(int id)
    {
        var produtos = await _service.Get(id);
        if (produtos != null)
        {
            return Ok(produtos);
        }
        return NotFound();
    }
    

    [HttpPost]
    [SwaggerOperation(Summary = "Cria um novo produto.", Tags = new[] { "Produto" })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post(CreateProdutoDto produtoDto)
    {
        var produto = await _service.Create(produtoDto);
        if (produto)
        {
            return NoContent();
        }
        return BadRequest();
    }
    
    [HttpPut]
    [SwaggerOperation(Summary = "Atualiza um produto existente.", Tags = new[] { "Produto" })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update(UpdateProdutoDto produto)
    {
        var response = await _service.Update(produto);
        if (response)
        {
            return NoContent();
        }
        return BadRequest();
    }
    
    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Exclui um produto com base no identificador.", Tags = new[] { "Produto" })]
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