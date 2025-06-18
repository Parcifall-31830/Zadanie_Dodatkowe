namespace WebApplication5.DTOs;

public class WydarzenieGetDto
{
    public int IdWydarzenie { get; set; }
    public string Tytul { get; set; } = null!;
    public string Opis { get; set; } = null!;
    public DateTime Data { get; set; }
    public int MaxUczestnik { get; set; }
}