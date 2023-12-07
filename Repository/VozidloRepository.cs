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
    public class VozidloRepository : IVozidloRepository
    {
        private readonly string connection;

        public VozidloRepository(string connection)
        {
            this.connection = connection;
        }

        public async Task AddNewVozidlo(Vozidlo vozidlo, Model model, Znacka znacka)
        {
            using (var db = new OracleConnection(this.connection))
            {
                var parameters = new DynamicParameters();
                parameters.Add("p_vin", vozidlo.Vin);
                parameters.Add("p_spz", vozidlo.Spz);
                parameters.Add("p_rok_vyroby", vozidlo.RokVyroby);
                parameters.Add("p_poznamky", vozidlo.Poznamky);
                parameters.Add("p_nazev_modelu", model.Nazev);
                parameters.Add("p_id_znacka", znacka.IdZnacka);

                await db.ExecuteAsync("ADD_NEW_VOZIDLO", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteVozidlo(Vozidlo vozidlo)
        {
            using (var db = new OracleConnection(this.connection))
            {
                db.Execute("DELETE FROM VOZIDLA WHERE id_vozidlo = :Id", new { Id = vozidlo.IdVozidlo });
            }
        }

        public async Task<List<Model>> GetAllModely()
        {
            using (var db = new OracleConnection(this.connection))
            {
                var res = await db.QueryAsync<Model>("SELECT id_model AS IdModel, nazev, id_znacka AS IdZnacka FROM modely");
                return res.ToList();
            }
        }

        public async Task<List<Vozidlo>> GetAllVozidla()
        {
            using (var db = new OracleConnection(this.connection))
            {
                var res = await db.QueryAsync<Vozidlo>("SELECT id_vozidlo AS IdVozidlo, vin, spz, rok_vyroby AS RokVyroby, poznamky, id_model AS IdModel FROM vozidla");
                return res.ToList();
            }
        }

        public async Task<List<Znacka>> GetAllZnacky()
        {
            using (var db = new OracleConnection(this.connection))
            {
                var res = await db.QueryAsync<Znacka>("SELECT id_znacka AS IdZnacka, nazev_znacky AS NazevZnacky FROM znacky");
                return res.ToList();
            }
        }

        public Model GetModelById(int idModel)
        {
            using (var db = new OracleConnection(this.connection))
            {
                return db.QueryFirstOrDefault<Model>(
                    "SELECT id_model AS IdModel, nazev, id_znacka AS IdZnacka FROM modely where id_model = :Id",
                    new { Id = idModel });
            }
        }

        public Znacka GetZnackaById(int idZnacka)
        {
            using (var db = new OracleConnection(this.connection))
            {
                return db.QueryFirstOrDefault<Znacka>(
                    "SELECT id_znacka AS IdZnacka, nazev_znacky AS NazevZnacky FROM znacky where id_znacka = :Id",
                    new { Id = idZnacka });
            }
        }

        public Znacka GetZnackaIdByName(string name)
        {
            using (var db = new OracleConnection(this.connection))
            {
                return db.QueryFirstOrDefault<Znacka>(
                    "SELECT id_znacka AS IdZnacka, nazev_znacky AS NazevZnacky FROM znacky where nazev_znacky = :Name",
                    new { Name = name });
            }
        }

        public void UpdateVozidlo(Vozidlo vozidlo, Model model, Znacka znacka)
        {
            using (var db = new OracleConnection(this.connection))
            {
                var parameters = new DynamicParameters();
                parameters.Add("p_id_vozidlo", vozidlo.IdVozidlo);
                parameters.Add("p_vin", vozidlo.Vin);
                parameters.Add("p_spz", vozidlo.Spz);
                parameters.Add("p_rok_vyroby", vozidlo.RokVyroby);
                parameters.Add("p_poznamky", vozidlo.Poznamky);
                parameters.Add("p_id_model", model.IdModel);
                parameters.Add("p_nazev_modelu", model.Nazev);
                parameters.Add("p_id_znacka", znacka.IdZnacka);
                parameters.Add("p_nazev_znacky", znacka.NazevZnacky);

                db.Execute("UPDATE_VOZIDLO", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
