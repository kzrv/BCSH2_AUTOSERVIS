using Dapper;
using Kozyrev_Hriha_SP.Models;
using Oracle.ManagedDataAccess.Client;
using System.Linq;
using System.Net;

namespace Kozyrev_Hriha_SP.Repository
{
    public class UserDataRepository : IUserDataRepository
    {
        private readonly string connection;

        public UserDataRepository(string connection)
        {
            this.connection = connection;
        }

        public UserData CheckCredentials(NetworkCredential cred)
        {
            using (var db = new OracleConnection(this.connection))
            {
                return db.Query<UserData>("SELECT * FROM USER_DATA d WHERE d.Email = :email", new { email = cred.UserName }).FirstOrDefault();
            }
        }
    }
}
