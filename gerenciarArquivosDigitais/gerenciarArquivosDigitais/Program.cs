using System;
using gerenciarArquivosDigitais.Models;
using gerenciarArquivosDigitais.Implementacoes;

class Program
{
    static void Main()
    {
        var repo = new RepositorioJson<ArquivoDigital>();

        while (true)
        {
            Console.WriteLine("\n--- Gerenciador de Arquivos Digitais ---");
            Console.WriteLine("1 - Adicionar arquivo");
            Console.WriteLine("2 - Listar arquivos");
            Console.WriteLine("3 - Buscar por tipo");
            Console.WriteLine("4 - Remover arquivo");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha: ");
            var op = Console.ReadLine();

            if (op == "0") break;

            switch (op)
            {
                case "1":
                    Console.Write("Nome do arquivo: ");
                    var nome = Console.ReadLine() ?? "";
                    Console.Write("Tipo do arquivo: ");
                    var tipo = Console.ReadLine() ?? "";
                    Console.Write("Tamanho em bytes: ");
                    long.TryParse(Console.ReadLine(), out var tamanho);
                    var arquivo = new ArquivoDigital
                    {
                        Id = Guid.NewGuid(),
                        NomeArquivo = nome,
                        TipoArquivo = tipo,
                        TamanhoBytes = tamanho,
                        DataUpload = DateTime.Now
                    };
                    repo.Adicionar(arquivo);
                    Console.WriteLine("Arquivo adicionado!");
                    break;

                case "2":
                    Console.WriteLine("\nID                                   | Nome                | Tipo      | Tamanho (bytes) | Data Upload");
                    foreach (var a in repo.ObterTodos())
                        Console.WriteLine($"{a.Id} | {a.NomeArquivo,-20} | {a.TipoArquivo,-10} | {a.TamanhoBytes,14} | {a.DataUpload:dd/MM/yyyy HH:mm}");
                    break;

                case "3":
                    Console.Write("Tipo: ");
                    var buscaTipo = Console.ReadLine() ?? "";
                    var arquivos = repo.ObterTodos().Where(a => a.TipoArquivo.Contains(buscaTipo, StringComparison.OrdinalIgnoreCase));
                    foreach (var a in arquivos)
                        Console.WriteLine($"{a.Id} | {a.NomeArquivo} | {a.TipoArquivo} | {a.TamanhoBytes} | {a.DataUpload:dd/MM/yyyy HH:mm}");
                    break;

                case "4":
                    Console.Write("ID do arquivo para remover: ");
                    if (Guid.TryParse(Console.ReadLine(), out var idRemover))
                    {
                        if (repo.Remover(idRemover))
                            Console.WriteLine("Arquivo removido com sucesso!");
                        else
                            Console.WriteLine("Arquivo não encontrado.");
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