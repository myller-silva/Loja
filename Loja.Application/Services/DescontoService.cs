using Loja.Application.Contracts;
using Loja.Application.Dto.Abstractions;
using Loja.Application.Dto.Desconto;
using Loja.Domain.Contracts;
using Loja.Domain.Entities;


namespace Loja.Application.Services;

public class DescontoService : IDescontoService
{
    private readonly IDescontoRepository _repository;

    public DescontoService(IDescontoRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Create(CreateDescontoDto dto)
    {
        var response = await _repository.Create(new Desconto()
        {
            ValorDesconto = dto.ValorDesconto,
            ProdutoId = dto.ProdutoId,
            UsuarioId = dto.UsuarioId
        });
        return response;
    }

    public async Task<List<Desconto>> Get(IDto<Desconto> dto)
    {
        var response = await _repository.Get(dto.Filtro());
        return response;
    }

    public async Task<Desconto?> Get(int id)
    {
        var response = await _repository.Get(id);
        return response;
    }

    public async Task<bool> Update(UpdateDescontoDto dto)
    {
        var response = await _repository.Get(dto.Id);
        if (response is null)
        {
            return false;
        }

        response.ValorDesconto = dto.ValorDesconto;
        return await _repository.Update(response);
    }
    //
    // public async Task<List<Desconto>> ObterDescontosCliente(int lojaId, int usuarioId)
    // {
    //     var response = await _repository
    //         .Get(x =>
    //             x.UsuarioId == usuarioId
    //             &&
    //             x.Produto!.Estoques.Any(e => e.Loja.Id == lojaId)
    //         );
    //     return response;
    // }


    public async Task<List<Desconto>> ObterDescontosCliente(int lojaId, int usuarioId)
    {
        var response = await _repository.ObterDescontosCliente(lojaId, usuarioId);
        return response;
    }

    public async Task<bool> Delete(int id)
    {
        var response = await _repository.Delete(id);
        return response;
    }
}