using Kozyrev_Hriha_SP.CustomControls;
using Kozyrev_Hriha_SP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Kozyrev_Hriha_SP.DataAccess
{
    public class DbService
    {
        private readonly AppDBContext AppDBContext;

        public DbService(AppDBContext appDBContext)
        {
            AppDBContext = appDBContext;
        }

        public UserData CheckCredentials(NetworkCredential cred)
        {
            UserData user = AppDBContext.UserData.FirstOrDefault(u => u.Email == cred.UserName);
            if (user != null && cred.Password == user.Password)
            {
                return user;
            }
            return null;
        }
    }

}
