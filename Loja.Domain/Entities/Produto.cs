namespace Loja.Domain.Entities;

public class Produto : Entity
{
    public string Nome { get; set; } = null!;
    public double Preco { get; set; }
    public string? Descricao { get; set; }
    
    public virtual ICollection<Estoque> Estoques { get; set; } = new List<Estoque>();
    
}