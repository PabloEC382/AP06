public class EquipamentoTI : IEntidade
{
    public Guid Id { get; set; }
    public string NomeEquipamento { get; set; }
    public string TipoEquipamento { get; set; }
    public string NumeroSerie { get; set; }
    public DateTime DataAquisicao { get; set; }
}
