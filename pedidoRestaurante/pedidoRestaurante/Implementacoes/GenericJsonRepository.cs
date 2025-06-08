using System.Text.Json;

public class GenericJsonRepository<T> : IRepository<T> where T : IEntidade
{
    protected List<T> _dados;
    protected readonly string _arquivo;

    public GenericJsonRepository(string nomeArquivo)
    {
        _arquivo = nomeArquivo;
        if (File.Exists(_arquivo))
        {
            var json = File.ReadAllText(_arquivo);
            _dados = JsonSerializer.Deserialize<List<T>>(json, new JsonSerializerOptions
            {
                WriteIndented = true,
                IncludeFields = true
            }) ?? new List<T>();
        }
        else
        {
            _dados = new List<T>();
        }
    }

    public void Adicionar(T entidade)
    {
        entidade.Id = Guid.NewGuid();
        _dados.Add(entidade);
        Salvar();
    }

    public List<T> ObterTodos() => _dados;

    public T? ObterPorId(Guid id) => _dados.FirstOrDefault(e => e.Id == id);

    public void Atualizar(T entidade)
    {
        var index = _dados.FindIndex(e => e.Id == entidade.Id);
        if (index != -1)
        {
            _dados[index] = entidade;
            Salvar();
        }
    }

    public bool Remover(Guid id)
    {
        var entidade = ObterPorId(id);
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
        var json = JsonSerializer.Serialize(_dados, new JsonSerializerOptions
        {
            WriteIndented = true,
            IncludeFields = true
        });
        File.WriteAllText(_arquivo, json);
    }
}
