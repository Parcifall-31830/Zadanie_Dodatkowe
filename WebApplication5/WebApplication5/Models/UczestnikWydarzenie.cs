using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication5.Models;

[Table("UczestnikWydarzenie")]
[PrimaryKey("UczestnikId","WydarzenieId")]
public class UczestnikWydarzenie
{
    public int UczestnikId { get; set; }
    public int WydarzenieId { get; set; }
    
    [ForeignKey("UczestnikId")]
    public virtual Uczestnik Uczestnik { get; set; } = null!;
    [ForeignKey("WydarzenieId")]
    public virtual Wydarzenie Wydarzenie { get; set; } = null!;
}