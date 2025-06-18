using WebApplication5.Models;

namespace WebApplication5.DTOs;

public class WydarzenieGetAllDto
{
    public int IdWydarzenie { get; set; }
    public string Tytul { get; set; } = null!;
    public string Opis { get; set; } = null!;
    public DateTime Data { get; set; }
    public int MaxUczestnik { get; set; }
    public ICollection<PrelegentDto> Prelegent { get; set; } = null!;
    
    public int LiczbaUczestnikow { get; set; }
    public int WolneMiejsca { get; set; }
}

public class PrelegentDto
{
    public string Imie { get; set; } = null!;
    public string Nazwisko { get; set; } = null!;
}