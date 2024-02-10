using Loja.Application.Contracts;
using Loja.Application.Dto.Produto;
using Microsoft.AspNetCore.Mvc;

namespace Loja.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProdutoController: ControllerBase
{
    private readonly IProdutoService _service;

    public ProdutoController(IProdutoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery]ProdutosDto produtosDto)
    {
        var produtos = await _service.Get(produtosDto); 
        return Ok(produtos); 
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var produtos = await _service.Get(id);
        if (produtos is not null)
        {
            return Ok(produtos);
        }
        return BadRequest();
    }
    

    [HttpPost]
    public async Task<IActionResult> Post(CreateProdutoDto produtoDto)
    {
        var produto = await _service.Create(produtoDto);
        if (produto)
        {
            return Ok(produto);
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