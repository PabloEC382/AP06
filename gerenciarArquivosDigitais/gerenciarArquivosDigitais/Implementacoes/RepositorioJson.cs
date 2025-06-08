using System.Text.Json;
using gerenciarArquivosDigitais.Interfaces;

namespace gerenciarArquivosDigitais.Implementacoes;

public class RepositorioJson<T> : IRepositorio<T> where T : class
{
    private readonly string _arquivo = $"{typeof(T).Name}.json";
    private List<T> _dados = new();

    public RepositorioJson()
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
        return _dados.FirstOrDefault(e => (Guid)e.GetType().GetProperty("Id")!.GetValue(e)! == id);
    }

    public IEnumerable<T> ObterTodos() => _dados;

    public void Atualizar(T entidade)
    {
        var id = (Guid)entidade.GetType().GetProperty("Id")!.GetValue(entidade)!;
        var idx = _dados.FindIndex(e => (Guid)e.GetType().GetProperty("Id")!.GetValue(e)! == id);
        if (idx >= 0)
        {
            _dados[idx] = entidade;
            Salvar();
        }
    }

    public bool Remover(Guid id)
    {
        var entidade = _dados.FirstOrDefault(e => (Guid)e.GetType().GetProperty("Id")!.GetValue(e)! == id);
        if (entidade != null)
        {
            _dados.Remove(entidade);
            Salvar();
            return true;
        }
        return false;
    }

    private void Salvar()
    {
        var json = JsonSerializer.Serialize(_dados, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_arquivo, json);
    }
}