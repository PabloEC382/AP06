using System;
using Interfaces;

namespace Entidades
{
    public class CursoOnline : IEntidade
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Titulo { get; set; } = string.Empty;
        public string Instrutor { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public int CargaHorariaHoras { get; set; }
    }
}
