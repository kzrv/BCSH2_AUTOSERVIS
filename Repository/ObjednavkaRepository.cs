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
                var res = await db.QueryAsync<Objednavka>("SELECT id_objednavky AS IdObjednavky, popis_objednavky AS PopisObjednavky, id_zakaznik AS IdZakaznik, id_sluzba AS IdSluzba, cas_objednani AS CasObjednani FROM objednavky where id_zakaznik = :Id", new { Id = id });
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

        public async Task AddNewObjednavka(Objednavka objednavka, Zakaznik zakaznik, Sluzba sluzba)
        {
            using (var db = new OracleConnection(this.connection))
            {
                var sqlQuery = @"INSERT INTO OBJEDNAVKY (popis_objednavky, id_zakaznik, id_sluzba, cas_objednani) 
                     VALUES (:Popis, :IdZakaz, :IdSluz, :CasObj)";

                var parameters = new DynamicParameters();

                parameters.Add("Popis", objednavka.PopisObjednavky, DbType.String, ParameterDirection.Input);
                parameters.Add("IdZakaz", zakaznik.Id, DbType.Int32, ParameterDirection.Input);
                parameters.Add("IdSluz", sluzba.IdSluzba, DbType.Int32, ParameterDirection.Input);
                parameters.Add("CasObj", objednavka.CasObjednani, DbType.DateTime, ParameterDirection.Input);

                await db.ExecuteAsync(sqlQuery, parameters);
            }
        }

        public async Task DeleteObjednavka(int id)
        {
            using (var db = new OracleConnection(this.connection))
            {
                await db.ExecuteAsync("DELETE FROM OBJEDNAVKY WHERE ID_OBJEDNAVKY = :Id", new { Id = id });
            }
        }

        public async Task UpdateObjednavka(Objednavka objednavka)
        {
            using (var db = new OracleConnection(this.connection))
            {
                var p = new DynamicParameters();

                p.Add("p_id_objednavky", objednavka.IdObjednavky, DbType.Int32);
                p.Add("p_popis_objednavky", objednavka.PopisObjednavky, DbType.String);
                p.Add("p_cas_objednani", objednavka.CasObjednani, DbType.DateTime);

                await db.ExecuteAsync("UPDATE_OBJEDNAVKA", p, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
