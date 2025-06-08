public class InMemoryEquipamentoTIRepository : IEquipamentoTIRepository
{
    private readonly List<EquipamentoTI> _dados = new();

    public void Adicionar(EquipamentoTI entidade)
    {
        entidade.Id = Guid.NewGuid();
        _dados.Add(entidade);
    }

    public EquipamentoTI? ObterPorId(Guid id)
    {
        return _dados.FirstOrDefault(e => e.Id == id);
    }

    public List<EquipamentoTI> ObterTodos()
    {
        return _dados;
    }

    public void Atualizar(EquipamentoTI entidade)
    {
        var index = _dados.FindIndex(e => e.Id == entidade.Id);
        if (index != -1)
        {
            _dados[index] = entidade;
        }
    }

    public bool Remover(Guid id)
    {
        var item = ObterPorId(id);
        if (item != null)
        {
            _dados.Remove(item);
            return true;
        }
        return false;
    }
}
