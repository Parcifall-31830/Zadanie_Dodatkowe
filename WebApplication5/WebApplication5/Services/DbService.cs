using Microsoft.EntityFrameworkCore;
using WebApplication5.Data;
using WebApplication5.DTOs;
using WebApplication5.Exceptions;
using WebApplication5.Models;

namespace WebApplication5.Services;
public interface IDbService{
    public Task<WydarzenieGetDto> GetWydarzenie(int id);
    public Task<WydarzenieGetDto> CreateWydarzenie(WydarzenieDto wydarzenie);
    public Task<ICollection<WydarzenieGetAllDto>> GetAllWydarzenia();
    public Task<ICollection<UczestnikGetAllDto>> GetAllUczestnik();
    public Task PrzypiszPreleganta(PrelegentPutDto prelegent);
    public Task RejestrujUczestnika(UczestnikWydarzeniePutDto dto);
    public Task AnulujRejestracje(UczestnikWydarzeniePutDto dto);
}
public class DbService(AppDbContext data ):IDbService
{

    public async Task<ICollection<UczestnikGetAllDto>> GetAllUczestnik()
    {
        return await data.Uczestnicy.Select(u=>new UczestnikGetAllDto
        {
            IdUczestnika = u.IdUczestnik,
            Imie = u.Imie,
            Wydarzenia = u.Wydarzenia.Select(uw=> new WydarzenieDetailsDto
            {
                IdWydarzenia = uw.Wydarzenie.IdWydarzenie,
                Tytul = uw.Wydarzenie.Tytul,
                Data = uw.Wydarzenie.Data,
                Prelegenci = uw.Wydarzenie.WydarzeniePrelegent.Select(p=>new PrelegentDetailsDto
                {
                    Imie = p.Prelegent.Imie,
                    Nazwisko = p.Prelegent.Nazwisko
                }).ToList()
            }).ToList()
        }).ToListAsync();
    }
    
    
    public async Task<ICollection<WydarzenieGetAllDto>> GetAllWydarzenia()
    {

        return await data.Wydarzenia
            .Select(w => new WydarzenieGetAllDto
            {
                IdWydarzenie = w.IdWydarzenie,
                Tytul = w.Tytul,
                Opis = w.Opis,
                Data = w.Data,
                MaxUczestnik = w.MaxUczestnik,
                Prelegent = w.WydarzeniePrelegent.Select(wp => new PrelegentDto
                {
                    Imie = wp.Prelegent.Imie,
                    Nazwisko = wp.Prelegent.Nazwisko
                }).ToList(),
                LiczbaUczestnikow = w.UczestnikWydarzenie.Count(),
                WolneMiejsca = w.MaxUczestnik-w.UczestnikWydarzenie.Count()
            }).ToListAsync();

        
    }
    
    public async Task AnulujRejestracje(UczestnikWydarzeniePutDto dto)
    {
        var checkReg = await data.UczestnikWydarzenie.FirstOrDefaultAsync(rg=>rg.WydarzenieId==dto.IdWydarzenia && rg.UczestnikId==dto.IdUczestnika);
        if (checkReg == null)
        {
            throw new AlreadyExistException($"Uczestnik o id {dto.IdUczestnika} nie jest zajerestrowany na wydarzenie o id {dto.IdWydarzenia}");
        }
        var wydarzenie = await data.Wydarzenia.FirstOrDefaultAsync(w => w.IdWydarzenie == dto.IdWydarzenia);
        if (wydarzenie == null)
        {
            throw new NotFoundException($"Wydarzenie o id {dto.IdWydarzenia} nie istnieje");
        }

        var uczestnik = await data.Uczestnicy.FirstOrDefaultAsync(u => u.IdUczestnik == dto.IdUczestnika);
        if (uczestnik == null)
        {
            throw new NotFoundException($"Uczestnik o id {dto.IdUczestnika} nie istnieje");
        }
        DateTime dzisiaj = DateTime.Today;
        if ((wydarzenie.Data - dzisiaj).TotalHours < 24)
        {
            throw new TooLateException("Nie można anulować rezerwacji od 24h przed wydarzeniem");
        }
        
        await data.UczestnikWydarzenie.Where(uw=>uw.UczestnikId==dto.IdUczestnika && uw.WydarzenieId==dto.IdWydarzenia).ExecuteDeleteAsync();
    }
    
    public async Task RejestrujUczestnika(UczestnikWydarzeniePutDto dto)
    {
        var checkUczestnik = await data.Uczestnicy.FirstOrDefaultAsync(u=>u.IdUczestnik == dto.IdUczestnika);
        if (checkUczestnik == null)
        {
            throw new NotFoundException($"Uczestnik id {dto.IdUczestnika} nie istnieje");
        }

        var checkWydarzenie = await data.Wydarzenia.FirstOrDefaultAsync(u=>u.IdWydarzenie == dto.IdWydarzenia);
        if (checkWydarzenie == null)
        {
            throw new NotFoundException($"Wydarzenie o id {dto.IdWydarzenia} nie istnieje");
        }

        var checkReg = await data.UczestnikWydarzenie.FirstOrDefaultAsync(rg=>rg.WydarzenieId==dto.IdWydarzenia && rg.UczestnikId==dto.IdUczestnika);
        if (checkReg != null)
        {
            throw new AlreadyExistException("Uczestnik jest już zajerestrowany na wydarzenie");
        }
        
        var count = await data.UczestnikWydarzenie.CountAsync(uw=> uw.WydarzenieId==dto.IdWydarzenia);
        if (checkWydarzenie.MaxUczestnik == count)
        {
            throw new NoSpaceException("Nie wystarczająca ilość miejsc na wydarzenie");
        }

        var newUczWyd = new UczestnikWydarzenie
        {
            UczestnikId = dto.IdUczestnika,
            WydarzenieId = dto.IdWydarzenia
        };
        await data.UczestnikWydarzenie.AddAsync(newUczWyd);
        await data.SaveChangesAsync();
    }
    
    
    
    public async Task PrzypiszPreleganta(PrelegentPutDto prelegent)
    {
        List<int> lista = new List<int>();
        var wydarzenie = await data.Wydarzenia.FirstOrDefaultAsync(w=>w.IdWydarzenie==prelegent.WydarzenieId);
        if (wydarzenie == null)
        {
            throw new NotFoundException("Wydarzenie nie istnieje");
        }
        
        
        foreach (var prelegentId in prelegent.PrelegenciId)
        {
            var pr = await data.Prelegenci.FirstOrDefaultAsync(g=> g.IdPrelegent == prelegentId);
            if (pr is not null)
            {
                lista.Add(prelegentId);
            }
        }

        foreach (var id in lista)
        {
            var przypis = new WydarzeniePrelegent
            {
                WydarzenieId = prelegent.WydarzenieId,
                PrelegentId = id
            };
            await data.WydarzeniePrelegent.AddAsync(przypis);
        }
        await data.SaveChangesAsync();
    }
    
    
    public async Task<WydarzenieGetDto> GetWydarzenie(int id)
    {
        var res = await data.Wydarzenia.Select(st=>new WydarzenieGetDto
        {
            IdWydarzenie = st.IdWydarzenie,
            Tytul = st.Tytul,
            Opis = st.Opis,
            Data = st.Data,
            MaxUczestnik = st.MaxUczestnik
        }).FirstOrDefaultAsync(st => st.IdWydarzenie == id);
        
        return res ?? throw new NotFoundException($"Wydarzenie o id {id} nie istnieje");
    }

    public async Task<WydarzenieGetDto> CreateWydarzenie(WydarzenieDto wydarzenie)
    {
        if (wydarzenie.Data < DateTime.Today)
        {
            throw new WrongDateException("Nie możne stworzyć wydarzenia w przeszłości.");
        }

        var newWydarzenie = new Wydarzenie
        {
            Tytul = wydarzenie.Tytul,
            Opis = wydarzenie.Opis,
            Data = wydarzenie.Data,
            MaxUczestnik = wydarzenie.MaxUczestnik
        };
        
        await data.Wydarzenia.AddAsync(newWydarzenie);
        await data.SaveChangesAsync();
        
        return new WydarzenieGetDto
        {
            IdWydarzenie = newWydarzenie.IdWydarzenie,
            Tytul = newWydarzenie.Tytul,
            Opis = newWydarzenie.Opis,
            Data = newWydarzenie.Data,
            MaxUczestnik = newWydarzenie.MaxUczestnik
        };
    }

    
}