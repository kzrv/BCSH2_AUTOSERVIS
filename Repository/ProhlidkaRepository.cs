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
    public class ProhlidkaRepository : IProhlidkaRepository
    {
        private readonly string connection;

        public ProhlidkaRepository(string connection)
        {
            this.connection = connection;
        }

        public List<Prohlidka> GetAllProhlidky()
        {
            using (var db = new OracleConnection(this.connection))
            {
                return db.Query<Prohlidka>("SELECT id_prohlidka AS IdProhlidka, datum_zacatek AS DatumZacatek, datum_konec AS DatumKonec, cena_prohlidky AS CenaProhlidky, id_objednavky AS IdObjednavky, id_zakaznik AS IdZakaznik, id_vozidlo AS IdVozidlo, id_zamestnanec AS IdZamestnanec FROM prohlidky").ToList();
            }
        }
    }
}
