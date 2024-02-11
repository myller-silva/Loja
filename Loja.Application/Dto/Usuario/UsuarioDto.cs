using System.Linq.Expressions;
using Loja.Application.Dto.Abstractions;
using Loja.Core.Extensions;

namespace Loja.Application.Dto.Usuario
{
    public class UsuarioDto: IDto<Domain.Entities.Usuario>
    {
        public string? Cpf { get; set; }
        public string? Email { get; set; }
        public string? Nome { get; set; }
        public string? Senha { get; set; }

        public Expression<Func<Domain.Entities.Usuario, bool>> Filtro()
        {
            Expression<Func<Domain.Entities.Usuario, bool>> expression = x => true;

            if (!string.IsNullOrEmpty(Cpf))
            {
                expression = expression.And(x => x.Cpf == Cpf);
            }

            if (!string.IsNullOrEmpty(Email))
            {
                expression = expression.And(x => x.Email == Email);
            }

            if (!string.IsNullOrEmpty(Nome))
            {
                expression = expression.And(x => x.Nome == Nome);
            }

            if (!string.IsNullOrEmpty(Senha))
            {
                expression = expression.And(x => x.Senha == Senha);
            }

            return expression;
        }
    }

    
}