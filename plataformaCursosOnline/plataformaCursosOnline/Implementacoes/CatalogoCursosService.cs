using Entidades;
using Interfaces;
using System.Collections.Generic;

namespace Implementacoes
{
    public class CatalogoCursosService
    {
        private readonly ICursoOnlineRepository _repositorio;

        public CatalogoCursosService(ICursoOnlineRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public bool RegistrarCurso(CursoOnline curso)
        {
            if (_repositorio.ObterPorTitulo(curso.Titulo) != null)
                return false;

            _repositorio.Adicionar(curso);
            return true;
        }

        public List<CursoOnline> ListarCursos()
        {
            return _repositorio.ObterTodos();
        }
    }
}
