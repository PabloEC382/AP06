using catalagoFilmes.Models;
using catalagoFilmes.Interfaces;

namespace catalagoFilmes.Implementacoes;

public class FilmeJsonRepository : GenericJsonRepository<Filme>, IFilmeRepository
{
    public IEnumerable<Filme> ObterPorGenero(string genero)
    {
        return ObterTodos().Where(f => f.Genero.Equals(genero, StringComparison.OrdinalIgnoreCase));
    }
}