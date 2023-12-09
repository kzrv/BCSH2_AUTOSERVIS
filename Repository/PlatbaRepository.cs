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
    public class PlatbaRepository : IPlatbaRepository
    {
        private readonly string connection;

        public PlatbaRepository(string connection)
        {
            this.connection = connection;
        }

        public async Task DeletePlatba(Platba platba)
        {
            using (var db = new OracleConnection(this.connection))
            {
                await db.ExecuteAsync("DELETE FROM PLATBY WHERE ID_PLATBA = :Id", new { Id = platba.IdPlatba });
            }
        }

        public async Task<List<Platba>> GetAllPlatby()
        {
            using (var db = new OracleConnection(this.connection))
            {
                var res = await db.QueryAsync<Platba>("SELECT * FROM PLATBY_VIEW");
                return res.ToList();
            }
        }

        public string GetIdentByPlatba(Platba platba)
        {
            string res = "";
            string sql = "BEGIN :result := Get_Ident_By_Platba(:Id, :TypPlatby); END;";

            using (var db = new OracleConnection(this.connection))
            {
                var parameters = new DynamicParameters();
                parameters.Add("Id", platba.IdPlatba);
                parameters.Add("TypPlatby", platba.TypPlatby);
                parameters.Add("result", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);

                db.Execute(sql, parameters, commandType: CommandType.Text);

                res = parameters.Get<string>("result");
            }

            return res;
        }
    }
}
