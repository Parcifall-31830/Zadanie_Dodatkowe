using System.ComponentModel.DataAnnotations;

namespace WebApplication5.DTOs;

public class WydarzenieDto
{
    [Required]
    [MaxLength(50)]
    public string Tytul { get; set; } = null!;
    
    [Required]
    [MaxLength(50)]
    public string Opis { get; set; } = null!;
    [Required]
    public DateTime Data { get; set; }
    [Required]
    public int MaxUczestnik { get; set; }
    
}