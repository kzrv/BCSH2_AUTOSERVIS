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

        public async Task UpdateAdresa(int id, Adresa adresa)
        {
            using (var db = new OracleConnection(this.connection))
            {
                var p = new DynamicParameters();
                p.Add("p_id_adresa", id, DbType.Int32);
                p.Add("p_ulice", adresa.Ulice, DbType.String);
                p.Add("p_psc", adresa.Psc, DbType.String);
                p.Add("p_mesto", adresa.Mesto, DbType.String);
                p.Add("p_cislo_popisne", adresa.CisloPopisne, DbType.String);
                p.Add("p_cislo_bytu", adresa.CisloBytu, DbType.String);

                await db.ExecuteAsync("UPDATE_ADRESA", p, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<Adresa> GetAdresaById(int id)
        {
            using (var db = new OracleConnection(this.connection))
            {
                return await db.QueryFirstOrDefaultAsync<Adresa>(
                    "SELECT id_adresa as IdAdresa, ulice, psc, mesto, cislo_popisne as CisloPopisne, cislo_bytu as CisloBytu FROM adresy where id_adresa = :Id",
                    new { Id = id });
            }
        }

        public void DeleteAdresa(int id)
        {
            using (var db = new OracleConnection(this.connection))
            {
                db.Execute("DELETE FROM adresy where id_adresa = :Id", new { Id = id });
            }
        }
    }
}
