using catalagoFilmes.Models;

namespace catalagoFilmes.Interfaces;

public interface IFilmeRepository : IRepository<Filme>
{
    IEnumerable<Filme> ObterPorGenero(string genero);
}