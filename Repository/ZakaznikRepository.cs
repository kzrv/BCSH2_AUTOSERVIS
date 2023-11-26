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
    public class ZakaznikRepository : IZakaznikRepository
    {
        private readonly string connection;
        private readonly IAdresaRepository adresaRepository;
        private readonly IUserDataRepository userData;

        public ZakaznikRepository(string connection, IUserDataRepository userDataRepository, IAdresaRepository adresaRepository)
        {
            this.connection = connection;
            this.adresaRepository = adresaRepository;
            this.userData = userDataRepository;
        }
        public List<Zakaznik> GetAllZakaznici()
        {
            using (var db = new OracleConnection(this.connection))
            {
                return db.Query<Zakaznik>("SELECT ID_ZAKAZNIK AS Id, JMENO, PRIJMENI, POZNAMKY, TEL_CISLO AS TelCislo, ID_ADRESA AS IdAdresa, ID_USER AS IdUser FROM ZAKAZNICI").ToList();
            }
        }

        public List<Adresa> GetZakaznikAddress(int id)
        {
            using (var db = new OracleConnection(this.connection))
            {
                return db.Query<Adresa>("SELECT id_adresa as IdAdresa, ulice, psc, mesto, cislo_popisne as CisloPopisne, cislo_bytu as CisloBytu FROM adresy where id_adresa = :Id", new { Id = id }).ToList();
            }
        }
        public void DeleteZakaznik(int id)
        {
            using (var db = new OracleConnection(this.connection))
            {
                db.Execute("DELETE FROM ZAKAZNICI WHERE ID_ZAKAZNIK = :Id", new { Id = id });
            }
        }
        public void UpdateAdresa(int id, Adresa adresa)
        {
            using (var db = new OracleConnection(this.connection))
            {
                var p = new DynamicParameters();
                p.Add("p_id_adresa", id, DbType.Int32);
                p.Add("p_ulice", adresa.Ulice, DbType.String);
                p.Add("p_psc", adresa.Psc, DbType.String);
                p.Add("p_mesto", adresa.Mesto, DbType.String);
                p.Add("p_cislo_popisne", adresa.CisloPopisne, DbType.String);
                p.Add("p_cislo_bytu", adresa.CisloBytu, DbType.String);

                db.Execute("UPDATE_ADRESA", p, commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdateZakaznik(Zakaznik zakaznik, Adresa adresa)
        {
            using (var db = new OracleConnection(this.connection))
            {
                UpdateAdresa(zakaznik.IdAdresa, adresa);
                var p = new DynamicParameters();
                p.Add("p_jmeno", zakaznik.Jmeno, DbType.String);
                p.Add("p_prijmeni", zakaznik.Prijmeni, DbType.String);
                p.Add("p_tel_cislo", zakaznik.TelCislo, DbType.String);
                p.Add("p_poznamky", zakaznik.Poznamky, DbType.String);
                p.Add("p_id", zakaznik.Id, DbType.Int32);

                db.Execute("UPDATE_ZAKAZNIK", p, commandType: CommandType.StoredProcedure);
            }
        }

        public void AddZakaznik(Zakaznik zakaznik, Adresa adresa)
        {
            using (var db = new OracleConnection(this.connection))
            {

            }
        }

        public async Task AddNewZakaznik(Zakaznik zakaznik, Adresa adresa, NetworkCredential cred)
        {
            using (var db = new OracleConnection(this.connection))
            {
                int idData = userData.RegisterNewUserData(cred);
                var parameters = new DynamicParameters();
                parameters.Add("p_jmeno", zakaznik.Jmeno, DbType.String);
                parameters.Add("p_prijmeni", zakaznik.Prijmeni, DbType.String);
                parameters.Add("p_tel_cislo", zakaznik.TelCislo, DbType.String);
                
                parameters.Add("p_id_user", idData, DbType.Int32);
                parameters.Add("p_ulice", adresa.Ulice, DbType.String);
                parameters.Add("p_psc", adresa.Psc, DbType.String);
                parameters.Add("p_mesto", adresa.Mesto, DbType.String);
                parameters.Add("p_cislo_popisne", adresa.CisloPopisne, DbType.String);
                parameters.Add("p_cislo_bytu", adresa.CisloBytu, DbType.String);


                await db.ExecuteAsync("register_new_zakaznik", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
