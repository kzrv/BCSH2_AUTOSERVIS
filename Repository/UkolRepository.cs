using Dapper;
using Kozyrev_Hriha_SP.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kozyrev_Hriha_SP.Repository.Interfaces
{
    public class UkolRepository : IUkolRepository
    {
        private readonly string connection;

        public UkolRepository(string connection)
        {
            this.connection = connection;
        }

        public async Task AddNewUkol(Ukol ukol, int IdSluzba)
        {
            using (var db = new OracleConnection(this.connection))
            {
                var sqlQuery = @"INSERT INTO UKOLY (nazev, popis, cena, id_sluzba) 
                         VALUES (:Nazev, :Popis, :Cena, :IdSluzba)";

                var parameters = new DynamicParameters();

                parameters.Add("Nazev", ukol.Nazev, DbType.String, ParameterDirection.Input);
                parameters.Add("Popis", ukol.Popis, DbType.String, ParameterDirection.Input);
                parameters.Add("Cena", ukol.Cena, DbType.Double, ParameterDirection.Input);
                parameters.Add("IdSluzba", IdSluzba, DbType.Int32, ParameterDirection.Input);

                await db.ExecuteAsync(sqlQuery, parameters);
            }
        }

        public void DeleteUkol(Ukol ukol)
        {
            using (var db = new OracleConnection(this.connection))
            {
                db.Execute("DELETE FROM UKOLY WHERE ID_UKOL = :Id", new { Id = ukol.IdUkol });
            }
        }

        public async Task<List<Ukol>> GetUkolyBySluzbaID(int sluzbaId)
        {
            using (var db = new OracleConnection(this.connection))
            {
                var res = await db.QueryAsync<Ukol>("SELECT id_ukol AS IdUkol, nazev, popis, cena, id_sluzba AS IdSluzba FROM ukoly WHERE id_sluzba = :Id", new { Id = sluzbaId });
                return res.ToList();
            }
        }

        public void UpdateUkol(Ukol ukol)
        {
            using (var db = new OracleConnection(this.connection))
            {
                var p = new DynamicParameters();

                p.Add("p_id_ukol", ukol.IdUkol, DbType.String);
                p.Add("p_nazev", ukol.Nazev, DbType.String);
                p.Add("p_popis", ukol.Popis, DbType.String);
                p.Add("p_cena", ukol.Cena, DbType.Double);

                db.Execute("UPDATE_UKOL", p, commandType: CommandType.StoredProcedure);
            }
        }


    }
}
