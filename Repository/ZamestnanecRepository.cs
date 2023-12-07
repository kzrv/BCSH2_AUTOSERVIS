using Dapper;
using Kozyrev_Hriha_SP.Models;
using Kozyrev_Hriha_SP.Repository.Interfaces;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Kozyrev_Hriha_SP.Repository
{
    public class ZamestnanecRepository : IZamestnanecRepository
    {
        private readonly string _connection;
        private readonly IAdresaRepository _adresaRepository;
        private readonly IUserDataRepository _userDataRepository;

        public ZamestnanecRepository(string connection, IUserDataRepository userDataRepository, IAdresaRepository adresaRepository)
        {
            _connection = connection;
            _adresaRepository = adresaRepository;
            _userDataRepository = userDataRepository;
        }

        public async Task DeleteZamestnanec(int id)
        {
            using (var db = new OracleConnection(this._connection))
            {
                await db.ExecuteAsync("DELETE FROM ZAMESTNANCI WHERE ID_ZAMESTNANEC = :Id", new { Id = id });
            }
        }

        public async Task<List<Zamestnanec>> GetAllZamestnanci()
        {
            using (var db = new OracleConnection(this._connection))
            {
                var res = await db.QueryAsync<Zamestnanec>("SELECT id_zamestnanec AS IdZamestnanec, jmeno, prijmeni, den_nastupu as DenNastupu, plat, ID_ADRESA AS IdAdresa, id_manazer as IdManazer, ID_USER AS IdUser FROM zamestnanci");
                return res.ToList();
            }
        }

        public async Task UpdateZamestnanec(Zamestnanec zamestnanec, Adresa adresa,UserData user)
        {
            using (var db = new OracleConnection(this._connection))
            {
                await _adresaRepository.UpdateAdresa(zamestnanec.IdAdresa, adresa);
                await _userDataRepository.UpdateUserEmail(user);
                var p = new DynamicParameters();
                p.Add("p_id", zamestnanec.IdZamestnanec, DbType.Int32);
                p.Add("p_jmeno", zamestnanec.Jmeno, DbType.String);
                p.Add("p_prijmeni", zamestnanec.Prijmeni, DbType.String);
                p.Add("p_den_nastupu", zamestnanec.DenNastupu, DbType.DateTime);
                p.Add("p_plat", zamestnanec.Plat, DbType.Int32);
                p.Add("p_id_manazer", zamestnanec.IdManazer, DbType.Int32);

    
                await db.ExecuteAsync("UPDATE_ZAMESTNANEC", p, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task AddNewZamestnanec(Zamestnanec zamestnanec, Adresa adresa, NetworkCredential cred)
        {
            using (var db = new OracleConnection(this._connection))
            {
                var idData = await _userDataRepository.RegisterNewUserData(cred);
                var parameters = new DynamicParameters();
                parameters.Add("p_jmeno", zamestnanec.Jmeno, DbType.String);
                parameters.Add("p_prijmeni", zamestnanec.Prijmeni, DbType.String);
                parameters.Add("p_den_nastupu", zamestnanec.DenNastupu, DbType.Date);
                parameters.Add("p_plat", zamestnanec.Plat, DbType.Decimal);
                parameters.Add("p_id_manazer", zamestnanec.IdManazer, DbType.Int32);
                parameters.Add("p_id_user", idData, DbType.Int32);
                parameters.Add("p_ulice", adresa.Ulice, DbType.String);
                parameters.Add("p_psc", adresa.Psc, DbType.String);
                parameters.Add("p_mesto", adresa.Mesto, DbType.String);
                parameters.Add("p_cislo_popisne", adresa.CisloPopisne, DbType.String);
                parameters.Add("p_cislo_bytu", adresa.CisloBytu, DbType.String);

                await db.ExecuteAsync("register_new_zamestnanec", parameters, commandType: CommandType.StoredProcedure);
            }

        }
    }
}
