using reservaHotel.Models;
using reservaHotel.Implementacoes;

class Program
{
    static void Main()
    {
        var repo = new ReservaHotelJsonRepository();

        while (true)
        {
            Console.WriteLine("\n1 - Adicionar reserva");
            Console.WriteLine("2 - Listar reservas");
            Console.WriteLine("3 - Remover reserva");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha: ");
            var op = Console.ReadLine();

            if (op == "0") break;

            switch (op)
            {
                case "1":
                    Console.Write("Nome do hóspede: ");
                    var nome = Console.ReadLine() ?? "";
                    Console.Write("Data de entrada (yyyy-MM-dd): ");
                    DateTime.TryParse(Console.ReadLine(), out var entrada);
                    Console.Write("Data de saída (yyyy-MM-dd): ");
                    DateTime.TryParse(Console.ReadLine(), out var saida);
                    Console.Write("Número do quarto: ");
                    int.TryParse(Console.ReadLine(), out var quarto);
                    Console.Write("Status (0-Pendente, 1-Confirmada, 2-Cancelada, 3-Finalizada): ");
                    Enum.TryParse<StatusReserva>(Console.ReadLine(), out var status);

                    repo.Adicionar(new ReservaHotel
                    {
                        Id = Guid.NewGuid(),
                        NomeHospede = nome,
                        DataEntrada = entrada,
                        DataSaida = saida,
                        NumeroQuarto = quarto,
                        Status = status
                    });
                    Console.WriteLine("Reserva adicionada!");
                    break;

                case "2":
                    Console.WriteLine("\nReservas cadastradas:");
                    foreach (var r in repo.ObterTodos())
                        Console.WriteLine($"{r.Id} | {r.NomeHospede} | Quarto {r.NumeroQuarto} | {r.Status}");
                    break;

                case "3":
                    Console.Write("ID da reserva para remover: ");
                    if (Guid.TryParse(Console.ReadLine(), out var idRemover))
                    {
                        if (repo.Remover(idRemover))
                            Console.WriteLine("Reserva removida!");
                        else
                            Console.WriteLine("Reserva não encontrada.");
                    }
                    else
                    {
                        Console.WriteLine("ID inválido.");
                    }
                    break;

                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }
}