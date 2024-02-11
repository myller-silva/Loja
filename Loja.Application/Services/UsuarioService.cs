using Loja.Application.Contracts;
using Loja.Application.Dto.Abstractions;
using Loja.Application.Dto.Usuario;
using Loja.Domain.Contracts;
using Loja.Domain.Entities;

namespace Loja.Application.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _repository;

    public UsuarioService(IUsuarioRepository repository)
    {
        _repository = repository;
    }


    public async Task<bool> Create(CreateUsuarioDto dto)
    {
        return await _repository.Create(new Usuario
        {
            Cpf = dto.Cpf,
            Email = dto.Email,
            Nome = dto.Nome,
            Senha = dto.Senha
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

    public async Task<bool> Update(UpdateUsuarioDto dto)
    {
        var response = await _repository.Get(dto.Id);
        if (response is null)
        {
            return false;
        }

        if (!string.IsNullOrEmpty(dto.Nome))
        {
            response.Nome = dto.Nome;
        }

        if (!string.IsNullOrEmpty(dto.Senha))
        {
            response.Senha = dto.Senha;
        }

        if (!string.IsNullOrEmpty(dto.Email))
        {
            response.Email = dto.Email;
        }

        if (!string.IsNullOrEmpty(dto.Cpf))
        {
            response.Cpf = dto.Cpf;
        }

        return await _repository.Update(response);
    }

    public async Task<bool> Delete(int id)
    {
        var response = await _repository.Delete(id);
        return response;
    }
}