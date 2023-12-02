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
    public class SluzbaRepository : ISluzbaRepository
    {
        private readonly string connection;

        public SluzbaRepository(string connection)
        {
            this.connection = connection;
        }

        public List<Sluzba> GetAllSluzby()
        {
            using (var db = new OracleConnection(this.connection))
            {
                return db.Query<Sluzba>("SELECT id_sluzba AS IdSluzba, nazev_sluzby AS NazevSluzby, popis FROM sluzby").ToList();
            }
        }
    }
}
