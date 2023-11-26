using Dapper;
using Kozyrev_Hriha_SP.Models;
using Kozyrev_Hriha_SP.Models.Enum;
using Kozyrev_Hriha_SP.Utils.Exceptions;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
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
                var p = new DynamicParameters();
                p.Add("p_email", cred.UserName, DbType.String);
                p.Add("p_password", cred.Password, DbType.String);
                p.Add("p_success", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                p.Add("p_id", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.Add("p_binary", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.Add("p_role", dbType: DbType.Int32, direction: ParameterDirection.Output);

                await db.ExecuteAsync("check_username_password", p, commandType: CommandType.StoredProcedure);
                UserData user = new UserData();
                if (p.Get<bool>("p_success"))
                {
                    user.Email = cred.UserName;
                    user.UserId = p.Get<int>("p_id");
                    user.IdContent = p.Get<int>("p_binary");
                    user.RoleUser = RoleService.GetRoleById(p.Get<int>("p_role"));
                    return user;
                }

                return null;
            }
        }

        public int RegisterNewUserData(NetworkCredential cred)
        {
            using (var db = new OracleConnection(this.connection))
            {
                var p = new DynamicParameters();
                p.Add("p_email", cred.UserName, DbType.String);
                p.Add("p_password", cred.Password, DbType.String);
                p.Add("p_success", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                p.Add("p_id", dbType: DbType.Int32, direction: ParameterDirection.Output);

                db.Execute("register_new_user", p, commandType: CommandType.StoredProcedure);
                UserData user = new UserData();
                if (p.Get<bool>("p_success"))
                {
                    return p.Get<int>("p_id");
                }

                throw new UserIsAlreadyExistsException($"User with email: {cred.UserName} is already exists");
            }
        }
    }
}
