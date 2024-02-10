using Loja.Application.Contracts; 
using Loja.Application.Dto.Abstractions;
using Loja.Domain.Contracts;
using Loja.Domain.Entities;

namespace Loja.Application.Services;

public class ProdutoService: IProdutoService
{
    private readonly IProdutoRepository _repository;

    public ProdutoService(IProdutoRepository repository)
    {
        _repository = repository;
    }
    

    public async Task<bool> Create(ICreateDto<Produto> obj)
    {
        return await _repository.Create(new Produto
        {
            Descricao = obj.Value.Descricao,
            Preco = obj.Value.Preco,
            Nome = obj.Value.Nome
            
        });
    }

    public async Task<List<Produto>> Get(IDto<Produto> dto)
    {
        var response = await _repository.Get(dto.Filtro());
        return response;
    } 
    
    public async Task<Produto?> Get(int id)
    {
        var response = await _repository.Get(id);
        return response;
    }

    public async Task<bool> Update(IUpdateDto<Produto> obj)
    {
        
        var response = await _repository.Update(obj.Value);
        return response;
    }
 
    public async Task<bool> Delete(int id)
    {
        var response = await _repository.Delete(id);
        return response;
    }
    
    
}