using Entidades;
using Interfaces;
using System;
using System.Linq;

namespace Implementacoes
{
    public class CursoOnlineJsonRepository : GenericJsonRepository<CursoOnline>, ICursoOnlineRepository
    {
        public CursoOnlineJsonRepository() : base("cursos.json") { }

        public CursoOnline? ObterPorTitulo(string titulo)
            => _dados.FirstOrDefault(c => c.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));
    }
}
