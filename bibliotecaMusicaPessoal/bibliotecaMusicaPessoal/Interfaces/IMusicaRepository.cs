using bibliotecaMusicaPessoal.Models;

namespace bibliotecaMusicaPessoal.Interfaces;

public interface IMusicaRepository : IRepositorio<Musica>
{
    IEnumerable<Musica> BuscarPorArtista(string artista);
}