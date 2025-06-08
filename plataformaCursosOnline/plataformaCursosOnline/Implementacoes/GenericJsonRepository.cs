using Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Implementacoes
{
    public class GenericJsonRepository<T> : IRepository<T> where T : IEntidade
    {
        protected readonly string _caminhoArquivo;
        protected List<T> _dados = new();

        public GenericJsonRepository(string nomeArquivo)
        {
            _caminhoArquivo = nomeArquivo;
            Carregar();
        }

        public void Adicionar(T entidade)
        {
            _dados.Add(entidade);
            Salvar();
        }

        public T? ObterPorId(Guid id) => _dados.FirstOrDefault(e => e.Id == id);

        public List<T> ObterTodos() => new List<T>(_dados);

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
            var removido = _dados.RemoveAll(e => e.Id == id) > 0;
            if (removido) Salvar();
            return removido;
        }

        protected void Carregar()
        {
            if (File.Exists(_caminhoArquivo))
            {
                var json = File.ReadAllText(_caminhoArquivo);
                var op = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                _dados = JsonSerializer.Deserialize<List<T>>(json, op) ?? new List<T>();
            }
        }

        protected void Salvar()
        {
            var json = JsonSerializer.Serialize(_dados, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_caminhoArquivo, json);
        }
    }
}
