using System.Text.Json;
using catalagoFilmes.Interfaces;
using catalagoFilmes.Entidades;

namespace catalagoFilmes.Implementacoes;

public class GenericJsonRepository<T> : IRepository<T> where T : IEntidade
{
    private readonly string _arquivo = $"{typeof(T).Name.ToLower()}s.json";
    private List<T> _dados = new();

    public GenericJsonRepository()
    {
        if (File.Exists(_arquivo))
        {
            var json = File.ReadAllText(_arquivo);
            _dados = JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        }
    }

    public void Adicionar(T entidade)
    {
        _dados.Add(entidade);
        Salvar();
    }

    public T? ObterPorId(Guid id)
    {
        return _dados.FirstOrDefault(e => e.Id == id);
    }

    public IEnumerable<T> ObterTodos() => _dados;

    public void Atualizar(T entidade)
    {
        var idx = _dados.FindIndex(e => e.Id == entidade.Id);
        if (idx >= 0)
        {
            _dados[idx] = entidade;
            Salvar();
        }
    }

    public bool Remover(Guid id)
    {
        var entidade = _dados.FirstOrDefault(e => e.Id == id);
        if (entidade != null)
        {
            _dados.Remove(entidade);
            Salvar();
            return true;
        }
        return false;
    }

    protected void Salvar()
    {
        var json = JsonSerializer.Serialize(_dados, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_arquivo, json);
    }
}