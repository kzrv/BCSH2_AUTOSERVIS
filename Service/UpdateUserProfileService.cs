using System.Net;
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
            _userDataRepository.UpdateUserEmail(userData);
            _zakaznikRepository.UpdateZakaznik(zakaznik,adresa);
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

        public Adresa GetUserAdresa(int adresaId)
        {
            return _adresaRepository.GetAdresaById(adresaId);
        }
    }
}