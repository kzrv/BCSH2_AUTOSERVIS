using Dapper;
using Kozyrev_Hriha_SP.Models;
using Kozyrev_Hriha_SP.Repository.Interfaces;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kozyrev_Hriha_SP.Repository
{
    public class ZamestnanecRepository : IZamestnanecRepository
    {
        private readonly string connection;
        private readonly IAdresaRepository adresaRepository;
        private readonly IUserDataRepository userData;

        public ZamestnanecRepository(string connection, IUserDataRepository userDataRepository, IAdresaRepository adresaRepository)
        {
            this.connection = connection;
            this.adresaRepository = adresaRepository;
            this.userData = userDataRepository;
        }

        public void DeleteZamestnanec(int id)
        {
            using (var db = new OracleConnection(this.connection))
            {
                db.Execute("DELETE FROM ZAMESTNANCI WHERE ID_ZAMESTNANEC = :Id", new { Id = id });
            }
        }

        public List<Zamestnanec> GetAllZamestnanci()
        {
            using (var db = new OracleConnection(this.connection))
            {
                return db.Query<Zamestnanec>("SELECT id_zamestnanec AS IdZamestnanec, jmeno, prijmeni, den_nastupu as DenNastupu, plat, ID_ADRESA AS IdAdresa, id_manazer as IdManazer, ID_USER AS IdUser FROM zamestnanci").ToList();
            }
        }

        public void UpdateZamestnanec(Zamestnanec zamestnanec, Adresa adresa)
        {
            using (var db = new OracleConnection(this.connection))
            {
                adresaRepository.UpdateAdresa(zamestnanec.IdAdresa, adresa);
                var p = new DynamicParameters();
                p.Add("p_id", zamestnanec.IdZamestnanec, DbType.Int32);
                p.Add("p_jmeno", zamestnanec.Jmeno, DbType.String);
                p.Add("p_prijmeni", zamestnanec.Prijmeni, DbType.String);
                p.Add("p_den_nastupu", zamestnanec.DenNastupu, DbType.DateTime);
                p.Add("p_plat", zamestnanec.Plat, DbType.Int32);
                p.Add("p_id_manazer", zamestnanec.IdManazer, DbType.Int32);


                db.Execute("UPDATE_ZAMESTNANEC", p, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
