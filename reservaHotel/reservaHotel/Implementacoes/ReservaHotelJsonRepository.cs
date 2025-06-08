using reservaHotel.Models;
using reservaHotel.Interfaces;

namespace reservaHotel.Implementacoes;

public class ReservaHotelJsonRepository : RepositorioJson<ReservaHotel>, IReservaHotelRepository
{
    public IEnumerable<ReservaHotel> ObterPorStatus(StatusReserva status)
    {
        return ObterTodos().Where(r => r.Status == status);
    }
}