namespace catalagoFilmes.Interfaces;

public interface IRepository<T>
{
    void Adicionar(T entidade);
    T? ObterPorId(Guid id);
    IEnumerable<T> ObterTodos();
    void Atualizar(T entidade);
    bool Remover(Guid id);
}