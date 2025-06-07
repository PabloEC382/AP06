using catalagoProduto.Entidades;

namespace catalagoProduto.Models; // <-- CORRETO!

public class Produto : IEntidades
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public decimal Preco { get; set; }
    public int Estoque { get; set; }
    public string Categoria { get; set; }

    public Produto()
    {
        Id = Guid.NewGuid();
    }

    public Produto(string nome, string descricao, decimal preco, int estoque, string categoria)
        : this()
    {
        Nome = nome;
        Descricao = descricao;
        Preco = preco;
        Estoque = estoque;
        Categoria = categoria;
    }
}