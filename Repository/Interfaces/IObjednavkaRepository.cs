using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kozyrev_Hriha_SP.Repository.Interfaces
{
    public interface IObjednavkaRepository
    {
        Task<List<Objednavka>> GetAllObjednavky();
        Task<List<Objednavka>> GetAllObjednavkyByIdZakaznik(int id);
        Task AddNewObjednavka(Objednavka objednavka);
        Task DeleteObjednavka(int id);
    }
}
