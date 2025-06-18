using Microsoft.EntityFrameworkCore;
using WebApplication5.Models;

namespace WebApplication5.Data;

public class AppDbContext : DbContext
{
    public DbSet<Uczestnik> Uczestnicy { get; set; } = null!;
    public DbSet<Wydarzenie> Wydarzenia { get; set; } = null!;
    public DbSet<Prelegent> Prelegenci { get; set; } = null!;
    public DbSet<UczestnikWydarzenie> UczestnikWydarzenie { get; set; } = null!;
    public DbSet<WydarzeniePrelegent> WydarzeniePrelegent { get; set; } = null!;
    
    public AppDbContext(DbContextOptions options) : base(options){}
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    // Uczestnicy
    var uczestnik1 = new Uczestnik
    {
        IdUczestnik = 1,
        Imie = "Jan",
        Nazwisko = "Kowalski",
        Email = "jan.kowalski@gmail.com"
    };
    var uczestnik2 = new Uczestnik
    {
        IdUczestnik = 2,
        Imie = "Anna",
        Nazwisko = "Nowak",
        Email = "anna.nowak@gmail.com"
    };
    var uczestnik3 = new Uczestnik
    {
        IdUczestnik = 3,
        Imie = "Coco",
        Nazwisko = "Loco",
        Email = "coco.loco@gmail.com"
    };
    var uczestnik4 = new Uczestnik
    {
        IdUczestnik = 4,
        Imie = "Zygzak",
        Nazwisko = "McQueen",
        Email = "zygzak@gmail.com"
    };
    var uczestnik5 = new Uczestnik
    {
        IdUczestnik = 5,
        Imie = "Tomasz",
        Nazwisko = "Hajto",
        Email = "tomasz@gmail.com"
    };
    var uczestnik6 = new Uczestnik
    {
        IdUczestnik = 6,
        Imie = "Zbigniew",
        Nazwisko = "Golonka",
        Email = "zbigniew@gmail.com"
    };
    var uczestnik7 = new Uczestnik
    {
        IdUczestnik = 7,
        Imie = "Max",
        Nazwisko = "Kolanko",
        Email = "kolanko@gmail.com"
    };

    // Prelegenci
    var prelegent1 = new Prelegent
    {
        IdPrelegent = 1,
        Imie = "Tomasz",
        Nazwisko = "Zieliński",
        Email = "tomasz.zielinski@example.com"
    };
    var prelegent2 = new Prelegent
    {
        IdPrelegent = 2,
        Imie = "Katarzyna",
        Nazwisko = "Wiśniewska",
        Email = "k.wisniewska@example.com"
    };

    // Wydarzenia
    var wydarzenie1 = new Wydarzenie
    {
        IdWydarzenie = 1,
        Tytul = "Konferencja IT",
        Opis = "Wydarzenie poświęcone nowym technologiom.",
        Data = new DateTime(2025, 10, 15),
        MaxUczestnik = 20
    };
    var wydarzenie2 = new Wydarzenie
    {
        IdWydarzenie = 2,
        Tytul = "Warsztaty AI",
        Opis = "Praktyczne warsztaty z uczenia maszynowego.",
        Data = new DateTime(2025, 11, 20),
        MaxUczestnik = 5
    };

    // Uczestnik-wydarzenie
    var uczestnikWydarzenie1 = new UczestnikWydarzenie { UczestnikId = 1, WydarzenieId = 1 };
    var uczestnikWydarzenie2 = new UczestnikWydarzenie{ UczestnikId = 1, WydarzenieId = 2 };
    var uczestnikWydarzenie3 = new UczestnikWydarzenie { UczestnikId = 2, WydarzenieId = 1 };
    var uczestnikWydarzenie4 = new UczestnikWydarzenie { UczestnikId = 3, WydarzenieId = 2 };
    var uczestnikWydarzenie5 = new UczestnikWydarzenie { UczestnikId = 4, WydarzenieId = 2 };
    var uczestnikWydarzenie6 = new UczestnikWydarzenie { UczestnikId = 5, WydarzenieId = 2 };
    var uczestnikWydarzenie7 = new UczestnikWydarzenie { UczestnikId = 6, WydarzenieId = 2 };
    var uczestnikWydarzenie8 = new UczestnikWydarzenie { UczestnikId = 7, WydarzenieId = 1 };
    
    // Prelegent-wydarzenie
    var wydarzeniePrelegent1 = new WydarzeniePrelegent { PrelegentId = 1, WydarzenieId = 1 };
    var wydarzeniePrelegent2 = new WydarzeniePrelegent { PrelegentId = 2, WydarzenieId = 2 };

    
    modelBuilder.Entity<Uczestnik>().HasData(uczestnik1, uczestnik2,uczestnik3,uczestnik4,uczestnik5,uczestnik6,uczestnik7);
    modelBuilder.Entity<Prelegent>().HasData(prelegent1, prelegent2);
    modelBuilder.Entity<Wydarzenie>().HasData(wydarzenie1, wydarzenie2);
    modelBuilder.Entity<UczestnikWydarzenie>().HasData(uczestnikWydarzenie1, uczestnikWydarzenie2, uczestnikWydarzenie3,uczestnikWydarzenie4,uczestnikWydarzenie5,uczestnikWydarzenie6,uczestnikWydarzenie7);
    modelBuilder.Entity<WydarzeniePrelegent>().HasData(wydarzeniePrelegent1, wydarzeniePrelegent2);
}

    
}