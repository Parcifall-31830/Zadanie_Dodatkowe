namespace WebApplication5.DTOs;

public class UczestnikGetAllDto
{
    public int IdUczestnika { get; set; }
    public string Imie { get; set; } = null!;
    public ICollection<WydarzenieDetailsDto> Wydarzenia { get; set; } = null!;

}

public class WydarzenieDetailsDto
{
    public int IdWydarzenia { get; set; }
    public string Tytul { get; set; } = null!;
    public DateTime Data { get; set; }
    public ICollection<PrelegentDetailsDto> Prelegenci { get; set; } = null!;
    
}

public class PrelegentDetailsDto
{
    public string Imie { get; set; } = null!;
    public string Nazwisko { get; set; } = null!;
}