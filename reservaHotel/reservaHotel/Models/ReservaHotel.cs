using System;
namespace reservaHotel.Models;

public class ReservaHotel
{
    public Guid Id { get; set; }
    public string NomeHospede { get; set; }
    public DateTime DataEntrada { get; set; }
    public DateTime DataSaida { get; set; }
    public int NumeroQuarto { get; set; }
    public StatusReserva Status { get; set; }
}