using reservaHotel.Models;

namespace reservaHotel.Interfaces;

public interface IReservaHotelRepository : IRepositorio<ReservaHotel>
{
    IEnumerable<ReservaHotel> ObterPorStatus(StatusReserva status);
}