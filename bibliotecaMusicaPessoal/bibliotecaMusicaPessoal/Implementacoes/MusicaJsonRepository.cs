using bibliotecaMusicaPessoal.Models;
using bibliotecaMusicaPessoal.Interfaces;

namespace bibliotecaMusicaPessoal.Implementacoes;

public class MusicaJsonRepository : RepositorioJson<Musica>, IMusicaRepository
{
    public IEnumerable<Musica> BuscarPorArtista(string artista)
    {
        return ObterTodos().Where(m => m.Artista.Contains(artista, StringComparison.OrdinalIgnoreCase));
    }
}