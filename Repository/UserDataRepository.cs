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
using Kozyrev_Hriha_SP.Repository.Interfaces;

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

        public async Task<int> RegisterNewUserData(NetworkCredential cred)
        {
            using (var db = new OracleConnection(this.connection))
            {
                var p = new DynamicParameters();
                p.Add("p_email", cred.UserName, DbType.String);
                p.Add("p_password", cred.Password, DbType.String);
                p.Add("p_success", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                p.Add("p_id", dbType: DbType.Int32, direction: ParameterDirection.Output);

                await db.ExecuteAsync("register_new_user", p, commandType: CommandType.StoredProcedure);
                UserData user = new UserData();
                if (p.Get<bool>("p_success"))
                {
                    return p.Get<int>("p_id");
                }
                throw new UserIsAlreadyExistsException($"User with email: {cred.UserName} is already exists");
            }
        }
        public void UpdateUserEmail(UserData user)
        {
            using (var db = new OracleConnection(this.connection))
            {
                try
                {
                    var p = new DynamicParameters();
                    p.Add("p_id_user", user.UserId, DbType.Int32);
                    p.Add("p_email", user.Email, DbType.String);
                    db.Execute("UPDATE_USER_DATA", p, commandType: CommandType.StoredProcedure);
                }
                catch (Exception e)
                {
                    throw new UserIsAlreadyExistsException("USER WITH THIS EMAIL IS ALREADY EXISTS");
                }
                
            }
        }
        public void UpdateUserPassword(UserData user,NetworkCredential pass)
        {
            using (var db = new OracleConnection(this.connection))
            {
                var p = new DynamicParameters();
                p.Add("p_id", user.UserId, DbType.Int32);
                p.Add("p_password", pass.Password, DbType.String);
                db.Execute("UPDATE_USER_PASS", p, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<UserData> GetZakaznikEmailByUserId(int id)
        {
            using (var db = new OracleConnection(this.connection))
            {
                return await db.QueryFirstOrDefaultAsync<UserData>("SELECT ID_USER as UserId, Email from USER_DATA where ID_USER = :id1",new{id1 = id});
            }
        }

        
    }
}
