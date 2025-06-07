using catalagoProduto.Models;
using catalagoProduto.Interfaces;
using System.Text.Json;

namespace catalagoProduto.Implementacoes;

public class ProdutoJsonCatalogoProduto : IProdutoCatalogoProduto
{
    private readonly string _filePath = "produtos.json";
    private List<Produto> _produtos = new();

    public ProdutoJsonCatalogoProduto()
    {
        if (File.Exists(_filePath))
        {
            var json = File.ReadAllText(_filePath);
            if (!string.IsNullOrWhiteSpace(json))
                _produtos = JsonSerializer.Deserialize<List<Produto>>(json) ?? new List<Produto>();
        }
    }

    public void Adicionar(Produto produto)
    {
        _produtos.Add(produto);
        Salvar();
    }

    public Produto? ObterPorId(Guid id)
    {
        return _produtos.FirstOrDefault(p => p.Id == id);
    }

    public IEnumerable<Produto> ObterTodos()
    {
        return _produtos;
    }

    public void Atualizar(Produto produto)
    {
        var idx = _produtos.FindIndex(p => p.Id == produto.Id);
        if (idx >= 0)
        {
            _produtos[idx] = produto;
            Salvar();
        }
    }

    public bool Remover(Guid id)
    {
        var produto = _produtos.FirstOrDefault(p => p.Id == id);
        if (produto != null)
        {
            _produtos.Remove(produto);
            Salvar();
            return true;
        }
        return false;
    }

    private void Salvar()
    {
        var json = JsonSerializer.Serialize(_produtos, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_filePath, json);
    }
}