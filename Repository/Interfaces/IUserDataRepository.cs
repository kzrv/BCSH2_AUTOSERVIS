using Kozyrev_Hriha_SP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Kozyrev_Hriha_SP.Repository
{
    public interface IUserDataRepository
    {
        Task<UserData> CheckCredentials(NetworkCredential cred);
        int RegisterNewUserData(NetworkCredential cred);
        void UpdateUserEmail(UserData user);
        void UpdateUserPassword(UserData user, NetworkCredential pass);
    }
}
