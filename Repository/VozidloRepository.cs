using Dapper;
using Kozyrev_Hriha_SP.Models;
using Kozyrev_Hriha_SP.Repository.Interfaces;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kozyrev_Hriha_SP.Repository
{
    public class VozidloRepository : IVozidloRepository
    {
        private readonly string connection;

        public VozidloRepository(string connection)
        {
            this.connection = connection;
        }

        public List<Vozidlo> GetAllVozidla()
        {
            using (var db = new OracleConnection(this.connection))
            {
                return db.Query<Vozidlo>("SELECT id_vozidlo AS IdVozidlo, vin, spz, rok_vyroby AS RokVyroby, poznamky, id_model AS IdModel FROM vozidla").ToList();
            }
        }
    }
}
