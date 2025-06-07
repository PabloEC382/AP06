using catalagoProduto.Models;
using catalagoProduto.Implementacoes;
using catalagoProduto.Interfaces;

internal class Program
{
    static void Main()
    {
        IProdutoCatalogoProduto catalogoProduto = new ProdutoJsonCatalogoProduto();
        bool aux = true;

        while (aux)
        {
            Console.WriteLine("-----------------CRUD Produto-----------------");
            Console.WriteLine("1 - Criar produto");
            Console.WriteLine("2 - Buscar produto por ID");
            Console.WriteLine("4 - Buscar catalogo");
            Console.WriteLine("5 - Atualizar produto por ID");
            Console.WriteLine("6 - Remover produto por ID");
            Console.WriteLine("0 - Encerrar");
            var opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    CriarProduto(catalogoProduto);
                    break;
                case "2":
                    BuscarProduto(catalogoProduto);
                    break;
                case "4":
                    BuscarCatalago(catalogoProduto);
                    break;
                case "5":
                    AtualizarProduto(catalogoProduto);
                    break;
                case "6":
                    RemoverProduto(catalogoProduto);
                    break;
                case "0":
                    aux = false;
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }

        Console.WriteLine("Encerrando...");
    }

    static void CriarProduto(IProdutoCatalogoProduto repo)
    {
        Console.Write("Nome: ");
        string nome = Console.ReadLine() ?? "";

        Console.Write("Descrição: ");
        string descricao = Console.ReadLine() ?? "";

        Console.Write("Preço: ");
        decimal preco = decimal.TryParse(Console.ReadLine(), out var p) ? p : 0;

        Console.Write("Estoque: ");
        int estoque = int.TryParse(Console.ReadLine(), out var e) ? e : 0;

        var produto = new Produto
        {
            Id = Guid.NewGuid(),
            Nome = nome,
            Descricao = descricao,
            Preco = preco,
            Estoque = estoque
        };

        repo.Adicionar(produto);
        Console.WriteLine($"Produto criado com sucesso! ID: {produto.Id}");
    }

    static void BuscarProduto(IProdutoCatalogoProduto repo)
    {
        Console.Write("Digite o ID do produto: ");
        if (Guid.TryParse(Console.ReadLine(), out var id))
        {
            var produto = repo.ObterPorId(id);
            if (produto != null)
            {
                Console.WriteLine($"ID: {produto.Id}");
                Console.WriteLine($"Nome: {produto.Nome}");
                Console.WriteLine($"Descrição: {produto.Descricao}");
                Console.WriteLine($"Preço: {produto.Preco:C}");
                Console.WriteLine($"Estoque: {produto.Estoque}");
            }
            else
            {
                Console.WriteLine("Produto não encontrado.");
            }
        }
        else
        {
            Console.WriteLine("ID inválido.");
        }
    }

    static void BuscarCatalago(IProdutoCatalogoProduto repo)
    {
        var produtos = repo.ObterTodos().ToList();
        if (!produtos.Any())
        {
            Console.WriteLine("Nenhum produto encontrado.");
            return;
        }

        // Cabeçalho
        Console.WriteLine(
            $"{ "ID",-36} | { "Nome",-15} | { "Descrição",-20} | { "Preço",10} | { "Estoque",7}");

        Console.WriteLine(new string('-', 95));

        // Linhas dos produtos
        foreach (var produto in produtos)
        {
            Console.WriteLine(
                $"{produto.Id,-36} | {produto.Nome,-15} | {produto.Descricao,-20} | {produto.Preco,10:C} | {produto.Estoque,7}");
        }
    }

    static void AtualizarProduto(IProdutoCatalogoProduto repo)
    {
        Console.Write("Digite o ID do produto a atualizar: ");
        if (Guid.TryParse(Console.ReadLine(), out var id))
        {
            var produto = repo.ObterPorId(id);
            if (produto == null)
            {
                Console.WriteLine("Produto não encontrado.");
                return;
            }

            Console.Write($"Novo nome (atual: {produto.Nome}): ");
            string nome = Console.ReadLine() ?? "";
            if (!string.IsNullOrWhiteSpace(nome)) produto.Nome = nome;

            Console.Write($"Nova descrição (atual: {produto.Descricao}): ");
            string descricao = Console.ReadLine() ?? "";
            if (!string.IsNullOrWhiteSpace(descricao)) produto.Descricao = descricao;

            Console.Write($"Novo preço (atual: {produto.Preco}): ");
            if (decimal.TryParse(Console.ReadLine(), out var preco)) produto.Preco = preco;

            Console.Write($"Novo estoque (atual: {produto.Estoque}): ");
            if (int.TryParse(Console.ReadLine(), out var estoque)) produto.Estoque = estoque;

            repo.Atualizar(produto);
            Console.WriteLine("Produto atualizado com sucesso!");
        }
        else
        {
            Console.WriteLine("ID inválido.");
        }
    }

    static void RemoverProduto(IProdutoCatalogoProduto repo)
    {
        Console.Write("Digite o ID do produto a remover: ");
        if (Guid.TryParse(Console.ReadLine(), out var id))
        {
            bool removido = repo.Remover(id);
            Console.WriteLine(removido ? "Produto removido com sucesso!" : "Produto não encontrado.");
        }
        else
        {
            Console.WriteLine("ID inválido.");
        }
    }
}
