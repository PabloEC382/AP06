using Entidades;
using System;

namespace Interfaces
{
    public interface ICursoOnlineRepository : IRepository<CursoOnline>
    {
        CursoOnline? ObterPorTitulo(string titulo);
    }
}
