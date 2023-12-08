using System.Net;
using System.Threading.Tasks;
using Kozyrev_Hriha_SP.Models;
using Kozyrev_Hriha_SP.Repository;
using Kozyrev_Hriha_SP.Repository.Interfaces;
using Kozyrev_Hriha_SP.Service.Interfaces;

namespace Kozyrev_Hriha_SP.Service
{
    public class UpdateUserProfileService : IUpdateUserProfileService
    {
        private readonly IUserDataRepository _userDataRepository;
        private readonly IZakaznikRepository _zakaznikRepository;
        private readonly IZamestnanecRepository _zamestnanecRepository;
        private readonly IBinaryContentRepository _binaryContentRepository;
        private readonly IAdresaRepository _adresaRepository;


        public UpdateUserProfileService(IUserDataRepository userDataRepository, IZakaznikRepository zakaznikRepository, IZamestnanecRepository zamestnanecRepository, IBinaryContentRepository binaryContentRepository, IAdresaRepository adresaRepository)
        {
            _userDataRepository = userDataRepository;
            _zakaznikRepository = zakaznikRepository;
            _zamestnanecRepository = zamestnanecRepository;
            _binaryContentRepository = binaryContentRepository;
            _adresaRepository = adresaRepository;
        }

        public void UpdateZakaznikProfile(UserData userData, Zakaznik zakaznik, BinaryContent binary,Adresa adresa)
        {
            //_userDataRepository.UpdateUserEmail(userData);
            _zakaznikRepository.UpdateZakaznik(zakaznik,adresa,userData);
            if(binary!=null) _binaryContentRepository.UpdateBinaryContent(binary);
        }

        public void UpdateUserPassword(UserData userData,NetworkCredential cred)
        {
            _userDataRepository.UpdateUserPassword(userData,cred);
        }

        public Zakaznik GetZakaznikById(int id)
        {
            return _zakaznikRepository.GetZakaznikByUserId(id);
        }

        public Task<Adresa> GetUserAdresa(int adresaId)
        {
            return _adresaRepository.GetAdresaById(adresaId);
        }

        public Task<Zamestnanec> GetZamestnanecByUserId(int id)
        {
            return _zamestnanecRepository.GetZamestnanecByUserId(id);
        }

        public Task UpdateZamestnanec(Zamestnanec zamestnanec, Adresa adresa, UserData user,BinaryContent binary)
        {
            if(binary!=null) _binaryContentRepository.UpdateBinaryContent(binary);
            return _zamestnanecRepository.UpdateZamestnanec(zamestnanec, adresa, user);
            
        }

        public Task<string> GetManager()
        {
            return _zamestnanecRepository.GetManager();
        }
    }
}