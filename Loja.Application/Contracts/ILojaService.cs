using Loja.Application.Dto.Loja;

namespace Loja.Application.Contracts;

public interface ILojaService: IBaseService<Domain.Entities.Loja>
{
    
    Task<bool> Create(CreateLojaDto dto);
    Task<bool> Update(UpdateLojaDto dto);
}