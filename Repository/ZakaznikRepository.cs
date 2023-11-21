using Dapper;
using Kozyrev_Hriha_SP.Models;
using Kozyrev_Hriha_SP.Repository.Interfaces;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Linq;

namespace Kozyrev_Hriha_SP.Repository
{
    public class ZakaznikRepository : IZakaznikRepository
    {
        private readonly string connection;

        public ZakaznikRepository(string connection)
        {
            this.connection = connection;
        }
        public List<Zakaznik> GetAllZakaznici()
        {
            using (var db = new OracleConnection(this.connection))
            {
                return db.Query<Zakaznik>("SELECT ID_ZAKAZNIK AS Id, JMENO, PRIJMENI, POZNAMKY, TEL_CISLO AS TelCislo, ID_ADRESA AS IdAdresa, ID_USER AS IdUser FROM ZAKAZNICI").ToList();
            }
        }
        public void DeleteZakaznik(int id)
        {
            using (var db = new OracleConnection(this.connection))
            {
                db.Execute("DELETE FROM ZAKAZNIK WHERE ID_ZAKAZNIK = :Id", new { Id = id });
            }
        }
    }
}
