using catalagoFilmes.Models;
using catalagoFilmes.Implementacoes;

class Program
{
    static void Main()
    {
        var repo = new FilmeJsonRepository();

        while (true)
        {
            Console.WriteLine("\n1 - Adicionar filme");
            Console.WriteLine("2 - Listar todos os filmes");
            Console.WriteLine("3 - Buscar por gênero");
            Console.WriteLine("4 - Atualizar filme");
            Console.WriteLine("5 - Remover filme");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha: ");
            var op = Console.ReadLine();

            if (op == "0") break;

            switch (op)
            {
                case "1":
                    Console.Write("Título: ");
                    var titulo = Console.ReadLine() ?? "";
                    Console.Write("Diretor: ");
                    var diretor = Console.ReadLine() ?? "";
                    Console.Write("Ano de lançamento: ");
                    int.TryParse(Console.ReadLine(), out var ano);
                    Console.Write("Gênero: ");
                    var genero = Console.ReadLine() ?? "";

                    repo.Adicionar(new Filme
                    {
                        Id = Guid.NewGuid(),
                        Titulo = titulo,
                        Diretor = diretor,
                        AnoLancamento = ano,
                        Genero = genero
                    });
                    Console.WriteLine("Filme adicionado!");
                    break;

                case "2":
                    Console.WriteLine("\nFilmes cadastrados:");
                    foreach (var f in repo.ObterTodos())
                        Console.WriteLine($"{f.Id} | {f.Titulo} | {f.Diretor} | {f.AnoLancamento} | {f.Genero}");
                    break;

                case "3":
                    Console.Write("Gênero: ");
                    var buscaGenero = Console.ReadLine() ?? "";
                    var filmes = repo.ObterPorGenero(buscaGenero);
                    foreach (var f in filmes)
                        Console.WriteLine($"{f.Id} | {f.Titulo} | {f.Diretor} | {f.AnoLancamento} | {f.Genero}");
                    break;

                case "4":
                    Console.Write("ID do filme para atualizar: ");
                    if (Guid.TryParse(Console.ReadLine(), out var idAtualizar))
                    {
                        var filme = repo.ObterPorId(idAtualizar);
                        if (filme == null)
                        {
                            Console.WriteLine("Filme não encontrado.");
                            break;
                        }
                        Console.Write($"Novo título (atual: {filme.Titulo}): ");
                        var novoTitulo = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(novoTitulo)) filme.Titulo = novoTitulo;

                        Console.Write($"Novo diretor (atual: {filme.Diretor}): ");
                        var novoDiretor = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(novoDiretor)) filme.Diretor = novoDiretor;

                        Console.Write($"Novo ano de lançamento (atual: {filme.AnoLancamento}): ");
                        if (int.TryParse(Console.ReadLine(), out var novoAno)) filme.AnoLancamento = novoAno;

                        Console.Write($"Novo gênero (atual: {filme.Genero}): ");
                        var novoGenero = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(novoGenero)) filme.Genero = novoGenero;

                        repo.Atualizar(filme);
                        Console.WriteLine("Filme atualizado!");
                    }
                    else
                    {
                        Console.WriteLine("ID inválido.");
                    }
                    break;

                case "5":
                    Console.Write("ID do filme para remover: ");
                    if (Guid.TryParse(Console.ReadLine(), out var idRemover))
                    {
                        if (repo.Remover(idRemover))
                            Console.WriteLine("Filme removido!");
                        else
                            Console.WriteLine("Filme não encontrado.");
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