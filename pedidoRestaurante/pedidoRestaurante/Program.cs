class Program
{
    static void Main()
    {
        var repo = new GenericJsonRepository<ItemCardapio>("cardapio.json");

        Console.Write("Cadastrar (1) Prato ou (2) Bebida? ");
        string opcao = Console.ReadLine();

        if (opcao == "1")
        {
            var prato = new Prato();
            Console.Write("Nome do prato: ");
            prato.NomeItem = Console.ReadLine();

            Console.Write("Preço: ");
            prato.Preco = decimal.Parse(Console.ReadLine());

            Console.Write("Descrição detalhada: ");
            prato.DescricaoDetalhada = Console.ReadLine();

            Console.Write("É vegetariano? (s/n): ");
            prato.Vegetariano = Console.ReadLine().ToLower() == "s";

            repo.Adicionar(prato);
        }
        else if (opcao == "2")
        {
            var bebida = new Bebida();
            Console.Write("Nome da bebida: ");
            bebida.NomeItem = Console.ReadLine();

            Console.Write("Preço: ");
            bebida.Preco = decimal.Parse(Console.ReadLine());

            Console.Write("Volume em ml: ");
            bebida.VolumeMl = int.Parse(Console.ReadLine());

            Console.Write("É alcoólica? (s/n): ");
            bebida.Alcoolica = Console.ReadLine().ToLower() == "s";

            repo.Adicionar(bebida);
        }

        Console.WriteLine("\nItens no cardápio:");
        foreach (var item in repo.ObterTodos())
        {
            Console.WriteLine($"- {item.NomeItem} (R$ {item.Preco})");
        }
    }
}
