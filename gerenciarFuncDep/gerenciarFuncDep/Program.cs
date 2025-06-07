class Program
{
    static void Main()
    {
        var repoDepartamento = new GenericJsonRepository<Departamento>("departamentos.json");
        var repoFuncionario = new GenericJsonRepository<Funcionario>("funcionarios.json");

        Console.Write("Digite o nome do departamento: ");
        string nomeDepartamento = Console.ReadLine();
        Console.Write("Digite a sigla do departamento: ");
        string sigla = Console.ReadLine();

        var departamento = new Departamento
        {
            NomeDepartamento = nomeDepartamento,
            Sigla = sigla
        };
        repoDepartamento.Adicionar(departamento);

        Console.Write("Digite o nome do funcionário: ");
        string nomeFuncionario = Console.ReadLine();
        Console.Write("Digite o cargo: ");
        string cargo = Console.ReadLine();

        var funcionario = new Funcionario
        {
            NomeCompleto = nomeFuncionario,
            Cargo = cargo,
            DepartamentoId = departamento.Id
        };
        repoFuncionario.Adicionar(funcionario);

        Console.WriteLine("
Funcionários cadastrados:");
        foreach (var f in repoFuncionario.ObterTodos())
        {
            var depto = repoDepartamento.ObterPorId(f.DepartamentoId);
            Console.WriteLine($"{f.NomeCompleto} - {f.Cargo} - Departamento: {depto?.NomeDepartamento} ({depto?.Sigla})");
        }
    }
}
