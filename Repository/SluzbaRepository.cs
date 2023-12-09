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
    public class SluzbaRepository : ISluzbaRepository
    {
        private readonly string connection;

        public SluzbaRepository(string connection)
        {
            this.connection = connection;
        }

        public async Task DeleteSluzba(Sluzba sluzba)
        {
            using (var db = new OracleConnection(this.connection))
            {
                await db.ExecuteAsync("DELETE FROM SLUZBY WHERE id_sluzba = :Id", new { Id = sluzba.IdSluzba });
            }
        }

        public async Task<List<Sluzba>> GetAllSluzby()
        {
            using (var db = new OracleConnection(this.connection))
            {
                var res = await db.QueryAsync<Sluzba>("SELECT id_sluzba AS IdSluzba, nazev_sluzby AS NazevSluzby, popis FROM sluzby");
                return res.ToList();
            }
        }

        public async Task UpdateSluzba(Sluzba sluzba)
        {
            using (var db = new OracleConnection(this.connection))
            {
                var p = new DynamicParameters();
                p.Add("p_nazev", sluzba.NazevSluzby, DbType.String);
                p.Add("p_popis", sluzba.Popis, DbType.String);
                p.Add("p_id_sluzba", sluzba.IdSluzba, DbType.Int32);


                await db.ExecuteAsync("UPDATE_SLUZBA", p, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task AddNewSluzba(Sluzba sluzba)
        {
            using (var db = new OracleConnection(this.connection))
            {
                var sqlQuery = @"INSERT INTO SLUZBY (nazev_sluzby, popis) 
                         VALUES (:Nazev, :Popis);";

                var parameters = new DynamicParameters();

                parameters.Add(":Nazev", sluzba.NazevSluzby, DbType.String, ParameterDirection.Input);
                parameters.Add(":Popis", sluzba.Popis, DbType.String, ParameterDirection.Input);

                await db.ExecuteAsync(sqlQuery, parameters);

            }
        }
    }
}
