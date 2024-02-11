using Loja.Application.Contracts; 
using Loja.Application.Dto.Abstractions;
using Loja.Application.Dto.Loja;
using Loja.Domain.Contracts;
using Loja.Domain.Entities;

namespace Loja.Application.Services;

public class LojaService: ILojaService
{
    private readonly ILojaRepository _repository;

    public LojaService(ILojaRepository repository)
    {
        _repository = repository;
    }
 


    public async Task<bool> Create(CreateLojaDto dto)
    {
        var response = await _repository.Create(new Domain.Entities.Loja
        {
            Endereco = dto.Endereco,
            Nome = dto.Nome,
            Estoques = new List<Estoque>()
        });
        // Console.WriteLine(response);
        return response;
    }

    public async Task<List<Domain.Entities.Loja>> Get(IDto<Domain.Entities.Loja> dto)
    {
        var response = await _repository.Get(dto.Filtro());
        return response;
    } 

    public async Task<Domain.Entities.Loja?> Get(int id)
    {
        var response = await _repository.Get(id);
        return response;
    }

    public async Task<bool> Update(UpdateLojaDto dto)
    {
        
        var response = await _repository.Get(dto.Id);
        if (response is null)
        {
            return false;
        }
        
        response.Nome = dto.Nome;
        response.Endereco = dto.Endereco;
        
        return await _repository.Update(response);
    }
    
    public async Task<bool> Delete(int id)
    {
        var response = await _repository.Delete(id);
        return response;
    }
}

