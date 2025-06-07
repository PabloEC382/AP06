namespace bibliotecaMusicaPessoal.Models;

public class Musica
{
    public Guid Id { get; set; }
    public string Titulo { get; set; }
    public string Artista { get; set; }
    public string Album { get; set; }
    public int Ano { get; set; }
}