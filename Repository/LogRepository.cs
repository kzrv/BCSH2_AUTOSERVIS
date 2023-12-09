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
    public class LogRepository : ILogRepository
    {
        private readonly string connection;

        public LogRepository(string connection)
        {
            this.connection = connection;
        }

        public async Task DeleteAllLogs()
        {
            using (var db = new OracleConnection(this.connection))
            {
                await db.ExecuteAsync("DELETE FROM logy");

            }
        }

        public async Task<List<Logg>> GetAllLogy()
        {
            using (var db = new OracleConnection(this.connection))
            {
                var res = await db.QueryAsync<Logg>("SELECT * FROM LOGY_VIEW");
                return res.ToList();
            }
        }
    }
}
