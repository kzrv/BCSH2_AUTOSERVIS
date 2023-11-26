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
    public class UserSettingsRepository : IUserSettingsRepository
    {
        private readonly string connection;

        public UserSettingsRepository(string connection)
        {
            this.connection = connection;
        }

        public List<Zakaznik> GetZakaznikByUserId(int userId)
        {
            using (var db = new OracleConnection(this.connection))
            {
                return db.Query<Zakaznik>("SELECT jmeno, prijmeni, tel_cislo, poznamky FROM zakaznici where id_user = :Id", new { Id = userId }).ToList();
            }
        }
    }
}
