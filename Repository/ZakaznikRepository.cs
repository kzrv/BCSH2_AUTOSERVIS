using Dapper;
using Kozyrev_Hriha_SP.Models;
using Kozyrev_Hriha_SP.Repository.Interfaces;
using Oracle.ManagedDataAccess.Client;
using System;
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


        public Zakaznik GetZakaznikByUserId(int userId)
        {
            using (var db = new OracleConnection(this.connection))
            {
                return db.QueryFirstOrDefault<Zakaznik>(
                    "SELECT id_zakaznik as Id, jmeno, prijmeni, tel_cislo as TelCislo, poznamky, id_adresa as IdAdresa, id_user as IdUser FROM zakaznici where id_user = :Id",
                    new { Id = userId });
            }
        }
        public void DeleteZakaznik(int id)
        {
            using (var db = new OracleConnection(this.connection))
            {
                db.Execute("DELETE FROM ZAKAZNICI WHERE ID_ZAKAZNIK = :Id", new { Id = id });
            }
        }


        public void UpdateZakaznik(Zakaznik zakaznik, Adresa adresa)
        {
            using (var db = new OracleConnection(this.connection))
            {
                adresaRepository.UpdateAdresa(zakaznik.IdAdresa, adresa);
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
