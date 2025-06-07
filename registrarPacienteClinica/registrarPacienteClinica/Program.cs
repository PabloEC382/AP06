class Program
{
    static void Main()
    {
        IPacienteRepository repo = new PacienteJsonRepository();

        Console.Write("Digite o nome completo do paciente: ");
        string nome = Console.ReadLine();

        Console.Write("Digite a data de nascimento (dd/mm/aaaa): ");
        DateTime dataNascimento;
        while (!DateTime.TryParse(Console.ReadLine(), out dataNascimento))
        {
            Console.Write("Data inválida. Digite novamente (dd/mm/aaaa): ");
        }

        Console.Write("Digite o contato de emergência: ");
        string contato = Console.ReadLine();

        var paciente = new Paciente
        {
            NomeCompleto = nome,
            DataNascimento = dataNascimento,
            ContatoEmergencia = contato
        };
        repo.Adicionar(paciente);

        Console.Write("\nDigite idade mínima para busca: ");
        int idadeMinima = int.Parse(Console.ReadLine());

        Console.Write("Digite idade máxima para busca: ");
        int idadeMaxima = int.Parse(Console.ReadLine());

        var pacientes = repo.ObterPorFaixaEtaria(idadeMinima, idadeMaxima);
        Console.WriteLine($"\nPacientes entre {idadeMinima} e {idadeMaxima} anos:");
        foreach (var p in pacientes)
        {
            Console.WriteLine($"{p.NomeCompleto} - Nascimento: {p.DataNascimento:dd/MM/yyyy} - Contato: {p.ContatoEmergencia}");
        }
    }
}
