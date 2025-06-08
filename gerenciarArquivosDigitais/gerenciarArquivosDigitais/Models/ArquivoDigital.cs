namespace gerenciarArquivosDigitais.Models;

public class ArquivoDigital
{
    public Guid Id { get; set; }
    public string NomeArquivo { get; set; }
    public string TipoArquivo { get; set; }
    public long TamanhoBytes { get; set; }
    public DateTime DataUpload { get; set; }
}