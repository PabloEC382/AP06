class Program
{
    static void Main()
    {
        IEquipamentoTIRepository repo = new InMemoryEquipamentoTIRepository();

        Console.Write("Nome do equipamento: ");
        string nome = Console.ReadLine();

        Console.Write("Tipo do equipamento (ex: Notebook, Monitor): ");
        string tipo = Console.ReadLine();

        Console.Write("Número de série: ");
        string numeroSerie = Console.ReadLine();

        Console.Write("Data de aquisição (dd/mm/aaaa): ");
        DateTime dataAquisicao;
        while (!DateTime.TryParse(Console.ReadLine(), out dataAquisicao))
        {
            Console.Write("Data inválida. Digite novamente (dd/mm/aaaa): ");
        }

        var equipamento = new EquipamentoTI
        {
            NomeEquipamento = nome,
            TipoEquipamento = tipo,
            NumeroSerie = numeroSerie,
            DataAquisicao = dataAquisicao
        };

        repo.Adicionar(equipamento);

        Console.WriteLine("
Equipamentos cadastrados:");
        foreach (var eq in repo.ObterTodos())
        {
            Console.WriteLine($"{eq.NomeEquipamento} ({eq.TipoEquipamento}) - Nº Série: {eq.NumeroSerie} - Aquisição: {eq.DataAquisicao:dd/MM/yyyy}");
        }
    }
}
