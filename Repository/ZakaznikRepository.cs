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

        public List<Adresa> GetZakaznikAddress(int id)
        {
            using (var db = new OracleConnection(this.connection))
            {
                return db.Query<Adresa>("SELECT id_adresa as IdAdresa, ulice, psc, mesto, cislo_popisne as CisloPopisne, cislo_bytu as CisloBytu FROM adresy where id_adresa = :Id", new { Id = id }).ToList();
            }
        }
        public List<Zakaznik> GetZakaznikByUserId(int userId)
        {
            using (var db = new OracleConnection(this.connection))
            {
                return db.Query<Zakaznik>("SELECT id_zakaznik as Id, jmeno, prijmeni, tel_cislo as TelCislo, poznamky, id_adresa as IdAdresa, id_user as IdUser FROM zakaznici where id_user = :Id", new { Id = userId }).ToList();
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

        public void UpdateUserData(Zakaznik zakaznik, Adresa adresa, UserData user, BinaryContent binaryContent, string newPass)
        {
            using (var db = new OracleConnection(this.connection))
            {
                UpdateZakaznik(zakaznik, adresa);
                UpdateBinaryContent(binaryContent);

                string salt = DateTime.Now.ToString("yyyyMMddHHmmssff"); // Create a new salt
                string hashedPassword = GetHashedPassword(newPass, salt); // Get hashed password

                var p = new DynamicParameters();
                p.Add("p_id_user", user.UserId, DbType.Int32);
                p.Add("p_email", user.Email, DbType.String);
                p.Add("p_password", hashedPassword, DbType.String);
                p.Add("p_salt", salt, DbType.String);
                // Call the stored procedure using Dapper
                db.Execute("UPDATE_USER_DATA", p, commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdateBinaryContent(BinaryContent binaryContent)
        {
            using (var db = new OracleConnection(this.connection))
            {
                var p = new DynamicParameters();
                p.Add("p_id_content", binaryContent.IdContent, DbType.Int32);
                p.Add("p_binarni_obsah", binaryContent.BinarniObsah, DbType.Binary);
                p.Add("p_nazev_souboru", binaryContent.NazevSouboru, DbType.String);
                p.Add("p_typ_souboru", binaryContent.TypSouboru, DbType.String);
                p.Add("p_pripona_souboru", binaryContent.Pripona, DbType.String);
                p.Add("p_datum_nahrani", binaryContent.DatumNahrani, DbType.Date);
                p.Add("p_datum_zmeny", binaryContent.DatumZmeny, DbType.Date);
                p.Add("p_zmenil", binaryContent.Zmenil, DbType.String);
                p.Add("p_operace", binaryContent.Operace, DbType.String);

                db.Execute("UPDATE_BINARY_CONTENT", p, commandType: CommandType.StoredProcedure);
            }
        }

        private string GetHashedPassword(string password, string salt)
        {
            using (var db = new OracleConnection(this.connection))
            {
                db.Open();

                // Call the hash_password function using Dapper
                string hashedPassword = db.QueryFirstOrDefault<string>("SELECT hash_password(:Password, :Salt) FROM dual",
                    new { Password = password, Salt = salt });

                return hashedPassword;
            }
        }
    }
}
