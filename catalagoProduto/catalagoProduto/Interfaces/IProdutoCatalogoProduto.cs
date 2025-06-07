using catalagoProduto.Models;

namespace catalagoProduto.Interfaces;

public interface IProdutoCatalogoProduto
{
    void Adicionar(Produto produto);
    Produto? ObterPorId(Guid id);
    IEnumerable<Produto> ObterTodos();
    void Atualizar(Produto produto);
    bool Remover(Guid id);
}