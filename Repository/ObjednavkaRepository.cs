using Dapper;
using Kozyrev_Hriha_SP.Models;
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
    internal class ObjednavkaRepository : IObjednavkaRepository
    {
        private readonly string connection;

        public ObjednavkaRepository(string connection)
        {
            this.connection = connection;
        }

        public async Task<List<Objednavka>> GetAllObjednavky()
        {
            using (var db = new OracleConnection(this.connection))
            {
                var res = await db.QueryAsync<Objednavka>("SELECT id_objednavky AS IdObjednavky, popis_objednavky AS PopisObjednavky, id_zakaznik AS IdZakaznik, id_sluzba AS IdSluzba, cas_objednani AS CasObjednani FROM objednavky");
                return res.ToList();
            }
        }

        public async Task<List<Objednavka>> GetAllObjednavkyByIdZakaznik(int id)
        {
            using (var db = new OracleConnection(this.connection))
            {
                var res = await db.QueryAsync<Objednavka>("SELECT id_objednavky AS IdObjednavky, popis_objednavky AS PopisObjednavky, id_zakaznik AS IdZakaznik, id_sluzba AS IdSluzba, cas_objednani AS CasObjednani FROM objednavky where id_zakaznik = :Id",new{Id = id});
                return res.ToList();
            }
        }

        public async Task AddNewObjednavka(Objednavka objednavka)
        {
            using (var db = new OracleConnection(this.connection))
            {
                var sql = @"
                INSERT INTO OBJEDNAVKY (POPIS_OBJEDNAVKY, ID_ZAKAZNIK, ID_SLUZBA, CAS_OBJEDNANI) 
                VALUES (:PopisObjednavky, :IdZakaznik, :IdSluzba, :CasObjednani)";

                var parameters = new DynamicParameters();
                parameters.Add("PopisObjednavky", objednavka.PopisObjednavky, DbType.String);
                parameters.Add("IdZakaznik", objednavka.IdZakaznik, DbType.Int32);
                parameters.Add("IdSluzba", objednavka.IdSluzba, DbType.Int32);
                parameters.Add("CasObjednani", objednavka.CasObjednani, DbType.DateTime);

                await db.ExecuteAsync(sql, parameters);
            }
        }

        public async Task DeleteObjednavka(int id)
        {
            using (var db = new OracleConnection(this.connection))
            {
                await db.ExecuteAsync("DELETE FROM OBJEDNAVKY WHERE ID_OBJEDNAVKY = :Id",new{Id = id});
            }
        }
    }
}
