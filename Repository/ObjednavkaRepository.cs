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
    internal class ObjednavkaRepository : IObjednavkaRepository
    {
        private readonly string connection;

        public ObjednavkaRepository(string connection)
        {
            this.connection = connection;
        }

        public List<Objednavka> GetAllObjednavky()
        {
            using (var db = new OracleConnection(this.connection))
            {
                return db.Query<Objednavka>("SELECT id_objednavky AS IdObjednavky, popis_objednavky AS PopisObjednavky, id_zakaznik AS IdZakaznik, id_sluzba AS IdSluzba, cas_objednani AS CasObjednani FROM objednavky").ToList();
            }
        }
    }
}
