using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication5.Models;

[Table("WydarzeniePrelegent")]
[PrimaryKey("PrelegentId","WydarzenieId")]
public class WydarzeniePrelegent
{
    public int PrelegentId { get; set; }
    public int WydarzenieId { get; set; }
    
    [ForeignKey("PrelegentId")]
    public virtual Prelegent Prelegent { get; set; } = null!;
    [ForeignKey("WydarzenieId")]
    public virtual Wydarzenie Wydarzenie { get; set; } = null!;
    
    
}