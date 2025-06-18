using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models;

[Table("Uczestnik")]
public class Uczestnik
{
    [Key] public int IdUczestnik { get; set; }
    [MaxLength(50)] public string Imie { get; set; } = null!;
    [MaxLength(50)] public string Nazwisko { get; set; } = null!;
    [MaxLength(50)] public string Email { get; set; } = null!;
    
    public virtual ICollection<UczestnikWydarzenie> Wydarzenia { get; set; } = null!;
    
}