namespace Loja.Domain.Entities;

public class Estoque : Entity
{
    public int LojaId { get; set; }
    public int ProdutoId { get; set; }
    public int Quantidade { get; set; }

    public virtual Loja Loja { get; set; } = null!;
    public virtual Produto Produto { get; set; } = null!;
}