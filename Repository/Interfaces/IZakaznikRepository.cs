using Kozyrev_Hriha_SP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Kozyrev_Hriha_SP.Repository.Interfaces
{
    public interface IZakaznikRepository
    {
        Task<List<Zakaznik>> GetAllZakaznici();
        Task DeleteZakaznik(Zakaznik zakaznik);
        Task UpdateZakaznik(Zakaznik zakaznik, Adresa adresa,UserData userData);
        Zakaznik GetZakaznikByUserId(int userId);
        Task AddNewZakaznik(Zakaznik zakaznik, Adresa adresa, NetworkCredential cred);
       

    }
}
