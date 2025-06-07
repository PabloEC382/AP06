using bibliotecaMusicaPessoal.Models;
using bibliotecaMusicaPessoal.Implementacoes;
using bibliotecaMusicaPessoal.Interfaces;

class Program
{
    static void Main()
    {
        IMusicaRepository repo = new MusicaJsonRepository();
        bool rodando = true;

        while (rodando)
        {
            Console.WriteLine("\n--- Biblioteca de Músicas ---");
            Console.WriteLine("1 - Adicionar música");
            Console.WriteLine("2 - Listar músicas");
            Console.WriteLine("3 - Buscar por artista");
            Console.WriteLine("4 - Atualizar música");
            Console.WriteLine("5 - Remover música");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha: ");
            var op = Console.ReadLine();

            switch (op)
            {
                case "1":
                    Console.Write("Título: ");
                    var titulo = Console.ReadLine() ?? "";
                    Console.Write("Artista: ");
                    var artista = Console.ReadLine() ?? "";
                    Console.Write("Álbum: ");
                    var album = Console.ReadLine() ?? "";
                    Console.Write("Ano: ");
                    int.TryParse(Console.ReadLine(), out var ano);

                    var musica = new Musica
                    {
                        Id = Guid.NewGuid(),
                        Titulo = titulo,
                        Artista = artista,
                        Album = album,
                        Ano = ano
                    };
                    repo.Adicionar(musica);
                    Console.WriteLine("Música adicionada!");
                    break;

                case "2":
                    Console.WriteLine("\nID                                   | Título                    | Artista              | Álbum                | Ano");
                    foreach (var m in repo.ObterTodos())
                        Console.WriteLine($"{m.Id} | {m.Titulo,-25} | {m.Artista,-20} | {m.Album,-20} | {m.Ano}");
                    break;

                case "3":
                    Console.Write("Artista: ");
                    var buscaArtista = Console.ReadLine() ?? "";
                    var musicas = repo.BuscarPorArtista(buscaArtista);
                    foreach (var m in musicas)
                        Console.WriteLine($"{m.Id} | {m.Titulo} | {m.Artista} | {m.Album} | {m.Ano}");
                    break;

                case "4":
                    Console.Write("ID da música: ");
                    if (Guid.TryParse(Console.ReadLine(), out var idAtualiza))
                    {
                        var m = repo.ObterPorId(idAtualiza);
                        if (m == null)
                        {
                            Console.WriteLine("Não encontrada.");
                            break;
                        }
                        Console.Write($"Novo título (atual: {m.Titulo}): ");
                        var novoTitulo = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(novoTitulo)) m.Titulo = novoTitulo;

                        Console.Write($"Novo artista (atual: {m.Artista}): ");
                        var novoArtista = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(novoArtista)) m.Artista = novoArtista;

                        Console.Write($"Novo álbum (atual: {m.Album}): ");
                        var novoAlbum = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(novoAlbum)) m.Album = novoAlbum;

                        Console.Write($"Novo ano (atual: {m.Ano}): ");
                        if (int.TryParse(Console.ReadLine(), out var novoAno)) m.Ano = novoAno;

                        repo.Atualizar(m);
                        Console.WriteLine("Atualizada!");
                    }
                    else
                    {
                        Console.WriteLine("ID inválido.");
                    }
                    break;

                case "5":
                    Console.Write("ID da música: ");
                    if (Guid.TryParse(Console.ReadLine(), out var idRemove))
                    {
                        if (repo.Remover(idRemove))
                            Console.WriteLine("Removida!");
                        else
                            Console.WriteLine("Não encontrada.");
                    }
                    else
                    {
                        Console.WriteLine("ID inválido.");
                    }
                    break;

                case "0":
                    rodando = false;
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }
}