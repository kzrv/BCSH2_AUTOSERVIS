using System.Net;
using System.Threading.Tasks;
using Kozyrev_Hriha_SP.Models;
using Kozyrev_Hriha_SP.Repository;

namespace Kozyrev_Hriha_SP.Service.Interfaces
{
    public interface IUpdateUserProfileService
    {
        void UpdateZakaznikProfile(UserData userData, Zakaznik zakaznik, BinaryContent binary,Adresa adresa);
        void UpdateUserPassword(UserData userData,NetworkCredential cred);
        Zakaznik GetZakaznikById(int id);
        Task<Adresa> GetUserAdresa(int adresaId);
    }
}