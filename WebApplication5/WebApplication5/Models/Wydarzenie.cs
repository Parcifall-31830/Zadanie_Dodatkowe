using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models;

public class Wydarzenie
{
    [Key] public int IdWydarzenie { get; set; }
    [MaxLength(50)] public string Tytul { get; set; } = null!;
    [MaxLength(50)] public string Opis { get; set; } = null!;
    public DateTime Data { get; set; } 
    public int MaxUczestnik { get; set; }
    
    public virtual ICollection<UczestnikWydarzenie> UczestnikWydarzenie{ get; set; } = null!;
    public virtual ICollection<WydarzeniePrelegent> WydarzeniePrelegent{ get; set; } = null!;
}