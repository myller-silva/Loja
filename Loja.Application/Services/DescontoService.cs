using Loja.Application.Contracts;
using Loja.Application.Dto.Abstractions;
using Loja.Domain.Entities;


namespace Loja.Application.Services;

public class DescontoService: IDescontoService
{
    public async Task<bool> Create(ICreateDto<Desconto> obj)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Desconto>> Get(IDto<Desconto> dto)
    {
        throw new NotImplementedException();
    }

    public async Task<Desconto?> Get(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Update(IUpdateDto<Desconto> obj)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Delete(int id)
    {
        throw new NotImplementedException();
    }
}