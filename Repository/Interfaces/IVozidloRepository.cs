using Kozyrev_Hriha_SP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Kozyrev_Hriha_SP.Repository.Interfaces
{
    public interface IVozidloRepository
    {
        Task<List<Vozidlo>> GetAllVozidla();
        Task<List<Model>> GetAllModely();
        Task<List<Znacka>> GetAllZnacky();

        Model GetModelById(int idModel);
        Znacka GetZnackaById(int idZnacka);
        Znacka GetZnackaIdByName(string name);

        void DeleteVozidlo(Vozidlo vozidlo);
        void UpdateVozidlo(Vozidlo vozidlo, Model model, Znacka znacka);
        Task AddNewVozidlo(Vozidlo vozidlo, Model model, Znacka znacka);
    }
}
