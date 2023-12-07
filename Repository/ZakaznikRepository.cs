using Dapper;
using Kozyrev_Hriha_SP.Models;
using Kozyrev_Hriha_SP.Repository.Interfaces;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading;
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
        public async Task<List<Zakaznik>> GetAllZakaznici()
        {
            using (var db = new OracleConnection(this.connection))
            {
                
                var res = await db.QueryAsync<Zakaznik>("SELECT ID_ZAKAZNIK AS Id, JMENO, PRIJMENI, POZNAMKY, TEL_CISLO AS TelCislo, ID_ADRESA AS IdAdresa, ID_USER AS IdUser FROM ZAKAZNICI");
                return res.ToList();
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
        public async Task DeleteZakaznik(Zakaznik zakaznik)
        {
            using (var db = new OracleConnection(this.connection))
            {
                await db.ExecuteAsync("DELETE FROM ZAKAZNICI WHERE ID_ZAKAZNIK = :Id", new { Id = zakaznik.Id });
                //db.Execute("DELETE FROM ADRESY WHERE ID_ADRESA = :Id", new { Id = zakaznik.IdAdresa });
                //userData.DeleteUserById(zakaznik.IdUser);
            }
        }


        public async Task UpdateZakaznik(Zakaznik zakaznik, Adresa adresa,UserData user)
        {
            using (var db = new OracleConnection(this.connection))
            {
                await userData.UpdateUserEmail(user);
                await adresaRepository.UpdateAdresa(zakaznik.IdAdresa, adresa);
                var p = new DynamicParameters();
                p.Add("p_jmeno", zakaznik.Jmeno, DbType.String);
                p.Add("p_prijmeni", zakaznik.Prijmeni, DbType.String);
                p.Add("p_tel_cislo", zakaznik.TelCislo, DbType.String);
                p.Add("p_poznamky", zakaznik.Poznamky, DbType.String);
                p.Add("p_id", zakaznik.Id, DbType.Int32);

                await db.ExecuteAsync("UPDATE_ZAKAZNIK", p, commandType: CommandType.StoredProcedure);
            }
        }
        
        public async Task AddNewZakaznik(Zakaznik zakaznik, Adresa adresa, NetworkCredential cred)
        {
            using (var db = new OracleConnection(this.connection))
            {
                var idData = await userData.RegisterNewUserData(cred);

                var parameters = new DynamicParameters();
                parameters.Add("p_jmeno", zakaznik.Jmeno, DbType.String, ParameterDirection.Input);
                parameters.Add("p_prijmeni", zakaznik.Prijmeni, DbType.String, ParameterDirection.Input);
                parameters.Add("p_tel_cislo", zakaznik.TelCislo, DbType.String, ParameterDirection.Input);
                parameters.Add("p_id_user", idData, DbType.Int32, ParameterDirection.Input);
                parameters.Add("p_ulice", adresa.Ulice, DbType.String, ParameterDirection.Input);
                parameters.Add("p_psc", adresa.Psc, DbType.String, ParameterDirection.Input);
                parameters.Add("p_mesto", adresa.Mesto, DbType.String, ParameterDirection.Input);
                parameters.Add("p_cislo_popisne", adresa.CisloPopisne, DbType.String, ParameterDirection.Input);
                parameters.Add("p_cislo_bytu", adresa.CisloBytu, DbType.String, ParameterDirection.Input);

                await db.ExecuteAsync("register_new_zakaznik", parameters, commandType: CommandType.StoredProcedure);


            }
        }
        
    }
}
