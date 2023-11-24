using Dapper;
using Kozyrev_Hriha_SP.Models;
using Kozyrev_Hriha_SP.Models.Enum;
using Kozyrev_Hriha_SP.Repository.Interfaces;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kozyrev_Hriha_SP.Repository
{
    public class AdresaRepository : IAdresaRepository
    {
        private readonly string connection;

        public AdresaRepository(string connection)
        {
            this.connection = connection;
        }
        public int AddNewAdresa(Adresa adresa)
        {
            using (var db = new OracleConnection(this.connection))
            {
                var sqlQuery = @"INSERT INTO ADRESY (ULICE, PSC, MESTO, CISLO_POPISNE, CISLO_BYTU) 
                         VALUES (:Ulice, :Psc, :Mesto, :CisloPopisne, :CisloBytu) 
                         RETURNING ID_ADRESA INTO :IdAdresa";

                var parameters = new DynamicParameters(adresa);
                parameters.Add("IdAdresa", dbType: DbType.Int32, direction: ParameterDirection.Output);

                db.Execute(sqlQuery, parameters);

                return parameters.Get<int>("IdAdresa");
            }
        }
    }
}
