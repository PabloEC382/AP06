public class PacienteJsonRepository : GenericJsonRepository<Paciente>, IPacienteRepository
{
    public PacienteJsonRepository() : base("pacientes.json") { }

    public IEnumerable<Paciente> ObterPorFaixaEtaria(int idadeMinima, int idadeMaxima)
    {
        DateTime hoje = DateTime.Today;
        return _dados.Where(p =>
        {
            int idade = hoje.Year - p.DataNascimento.Year;
            if (p.DataNascimento.Date > hoje.AddYears(-idade)) idade--;
            return idade >= idadeMinima && idade <= idadeMaxima;
        });
    }
}
