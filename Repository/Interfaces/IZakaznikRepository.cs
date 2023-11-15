using Kozyrev_Hriha_SP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kozyrev_Hriha_SP.Repository.Interfaces
{
    public interface IZakaznikRepository
    {
        List<Zakaznik> GetAllZakaznici();
        void DeleteZakaznik(int id);

    }
}
