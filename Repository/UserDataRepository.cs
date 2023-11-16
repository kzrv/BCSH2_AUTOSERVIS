using Dapper;
using Kozyrev_Hriha_SP.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Kozyrev_Hriha_SP.Repository
{
    public class UserDataRepository : IUserDataRepository
    {
        private readonly string connection;

        public UserDataRepository(string connection)
        {
            this.connection = connection;
        }

        public async Task<UserData> CheckCredentials(NetworkCredential cred)
        {         
            using (var db = new OracleConnection(this.connection))
            {
                return await db.QueryFirstOrDefaultAsync<UserData>("SELECT * FROM USER_DATA d WHERE d.Email = :email", new { email = cred.UserName });
            }
        }
    }
}
