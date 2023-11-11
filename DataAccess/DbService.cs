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
        public AppDBContext AppDBContext;

        public DbService(AppDBContext appDBContext)
        {
            AppDBContext = appDBContext;
        }

        public bool CheckCredentials(NetworkCredential cred)
        {
            var userList = AppDBContext.UserData.ToList();
            UserData userFirst = userList.Where(u => u.Email == cred.UserName).First();
            if (userFirst != null && cred.Password == userFirst.Password)
            {
                return true;
            }
            return false;
        }
    }

}
