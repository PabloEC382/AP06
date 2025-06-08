using System;
using Entidades;
using Implementacoes;

class Program
{
    static void Main()
    {
        var repositorio = new CursoOnlineJsonRepository();
        var servico = new CatalogoCursosService(repositorio);

        var curso = new CursoOnline
        {
            Titulo = "C# com Repository Pattern",
            Instrutor = "João Silva",
            Descricao = "Curso prático sobre o padrão Repository com persistência em JSON.",
            CargaHorariaHoras = 12
        };

        if (servico.RegistrarCurso(curso))
            Console.WriteLine("Curso registrado com sucesso!");
        else
            Console.WriteLine("Curso já existe!");

        Console.WriteLine("\nCursos disponíveis:");
        foreach (var c in servico.ListarCursos())
        {
            Console.WriteLine($"- {c.Titulo} ({c.CargaHorariaHoras}h)");
        }
    }
}
