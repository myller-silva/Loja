using Loja.Application.Contracts; 
using Loja.Application.Dto.Abstractions;
using Loja.Application.Dto.Loja;
using Loja.Domain.Contracts; 

namespace Loja.Application.Services;

public class LojaService: ILojaService
{
    private readonly ILojaRepository _repository;

    public LojaService(ILojaRepository repository)
    {
        _repository = repository;
    }
 


    public async Task<bool> Create(ICreateDto<Domain.Entities.Loja> obj)
    {
        return await _repository.Create(new Domain.Entities.Loja
        {
            Endereco = obj.Value.Endereco,
            Nome = obj.Value.Nome
            
        });
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

    public async Task<bool> Update(IUpdateDto<Domain.Entities.Loja> obj)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Update(Domain.Entities.Loja loja)
    {
        var response = await _repository.Update(loja);
        return response;
    }

    public async Task<bool> Delete(int id)
    {
        var response = await _repository.Delete(id);
        return response;
    }
}

