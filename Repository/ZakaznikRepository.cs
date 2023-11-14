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
                return db.Query<Zakaznik>("SELECT * FROM ZAKAZNICI").ToList();
            }
        }
    }
}
