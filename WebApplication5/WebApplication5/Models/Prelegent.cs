using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models;
[Table("Prelegent")]
public class Prelegent
{
    [Key] public int IdPrelegent { get; set; }
    [MaxLength(50)] public string Imie { get; set; } = null!;
    [MaxLength(50)] public string Nazwisko { get; set; } = null!;
    [MaxLength(50)] public string Email { get; set; } = null!;
    
    public virtual ICollection<WydarzeniePrelegent> Wydarzenia { get; set; } = null!;
    
}