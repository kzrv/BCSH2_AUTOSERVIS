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

        public ZakaznikRepository(string connection,IUserDataRepository userDataRepository,IAdresaRepository adresaRepository)
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
        public void DeleteZakaznik(int id)
        {
            using (var db = new OracleConnection(this.connection))
            {
                db.Execute("DELETE FROM ZAKAZNIK WHERE ID_ZAKAZNIK = :Id", new { Id = id });
            }
        }

        public async Task AddNewZakaznik(Zakaznik zakaznik, Adresa adresa, NetworkCredential cred)
        {
            using (var db = new OracleConnection(this.connection))
            {
                int idAdresa = adresaRepository.AddNewAdresa(adresa);
                int idData = userData.RegisterNewUserData(cred);

                var sqlQuery = @"INSERT INTO ZAKAZNICI (JMENO, PRIJMENI, TEL_CISLO, POZNAMKY, ID_ADRESA, ID_USER) 
                         VALUES (:Jmeno, :Prijmeni, :TelCislo, :Poznamky, :IdAdresa, :IdUser) 
                         RETURNING ID_ZAKAZNIK INTO :IdZakaznik";

                var parameters = new DynamicParameters(zakaznik);
                parameters.Add("IdAdresa", idAdresa, DbType.Int32);
                parameters.Add("IdUser", idData, DbType.Int32);
                parameters.Add("IdZakaznik", dbType: DbType.Int32, direction: ParameterDirection.Output);

                await db.ExecuteAsync(sqlQuery, parameters);
            }
        }
    }
}
