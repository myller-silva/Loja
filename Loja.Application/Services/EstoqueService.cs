using Loja.Application.Contracts;
using Loja.Application.Dto.Abstractions;
using Loja.Application.Dto.Estoque;
using Loja.Domain.Contracts;
using Loja.Domain.Entities;

namespace Loja.Application.Services;

public class EstoqueService: IEstoqueService
{
    private readonly IEstoqueRepository _repository;

    public EstoqueService(IEstoqueRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Create(CreateEstoqueDto dto)
    {
        return await _repository.Create(new Estoque
        {
            LojaId = dto.LojaId,
            ProdutoId = dto.ProdutoId,
            Quantidade = dto.Quantidade,
        });
    }

    public async Task<List<Estoque>> Get(IDto<Estoque> dto)
    {
        var response = await _repository.Get(dto.Filtro());
        return response;
    } 

    public async Task<Estoque?> Get(int id)
    {
        var response = await _repository.Get(id);
        return response;
    }

    public async Task<bool> Update(UpdateEstoqueDto dto)
    {
        
        var response = await _repository.Get(dto.Id);
        if (response is null)
        {
            return false;
        }
        
        response.Quantidade = dto.Quantidade;
        return await _repository.Update(response);
    }

    public async Task<bool> Delete(int id)
    {
        var response = await _repository.Delete(id);
        return response;
    }
}