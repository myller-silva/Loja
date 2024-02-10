using Loja.Application.Contracts; 
using Loja.Application.Dto.Abstractions;
using Loja.Domain.Contracts;
using Loja.Domain.Entities;

namespace Loja.Application.Services;

public class UsuarioService: IUsuarioService
{
    private readonly IUsuarioRepository _repository;

    public UsuarioService(IUsuarioRepository repository)
    {
        _repository = repository;
    }
 

    public async Task<bool> Create(ICreateDto<Usuario> obj)
    {
        return await _repository.Create(new Usuario
        {
            Cpf = obj.Value.Cpf,
            Email = obj.Value.Email,
            Nome = obj.Value.Nome,
            Senha = obj.Value.Senha
        });
    }

    public async Task<List<Usuario>> Get(IDto<Usuario> dto)
    { 
        var response = await _repository.Get(dto.Filtro());
        return response;
    }

    public async Task<Usuario?> Get(int id)
    {
        var response = await _repository.Get(id);
        return response;
    }

    public async Task<bool> Update(IUpdateDto<Usuario> obj)
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