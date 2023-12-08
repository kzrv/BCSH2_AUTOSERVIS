using Kozyrev_Hriha_SP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Kozyrev_Hriha_SP.Repository.Interfaces
{
    public interface IZamestnanecRepository
    {
        Task<List<Zamestnanec>> GetAllZamestnanci();
        Task DeleteZamestnanec(int id);
        Task UpdateZamestnanec(Zamestnanec zamestnanec, Adresa adresa,UserData userData);
        Task AddNewZamestnanec(Zamestnanec zamestnanec, Adresa adresa, NetworkCredential cred);
        Task<Zamestnanec> GetZamestnanecByUserId(int id);
        Task<string> GetManager();
    }
}
