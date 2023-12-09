using Kozyrev_Hriha_SP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kozyrev_Hriha_SP.Repository.Interfaces
{
    public interface IProhlidkaRepository
    {
        Task<List<Prohlidka>> GetAllProhlidky();
        Task AddNewProhlidka(Prohlidka prohlidka, Objednavka objednavka, Zamestnanec zamestnanec, Vozidlo vozidlo);
        Task UpdateProhlidka(Prohlidka prohlidka);
        Task DeleteProhlidka(Prohlidka prohlidka);
    }
}
