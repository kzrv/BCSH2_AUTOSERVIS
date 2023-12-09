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
    public class ProhlidkaRepository : IProhlidkaRepository
    {
        private readonly string connection;

        public ProhlidkaRepository(string connection)
        {
            this.connection = connection;
        }

        public async Task AddNewProhlidka(Prohlidka prohlidka, Objednavka objednavka, Zamestnanec zamestnanec, Vozidlo vozidlo)
        {
            using (var db = new OracleConnection(this.connection))
            {
                var parameters = new DynamicParameters();
                parameters.Add("p_DatumZacatek", prohlidka.DatumZacatek, DbType.Date, ParameterDirection.Input);
                parameters.Add("p_DatumKonec", prohlidka.DatumKonec, DbType.Date, ParameterDirection.Input);
                parameters.Add("p_CenaProhlidky", prohlidka.CenaProhlidky, DbType.Decimal, ParameterDirection.Input);
                parameters.Add("p_IdObjednavky", objednavka.IdObjednavky, DbType.Decimal, ParameterDirection.Input);
                parameters.Add("p_IdZakaznik", objednavka.IdZakaznik, DbType.Decimal, ParameterDirection.Input);
                parameters.Add("p_IdVozidlo", vozidlo.IdVozidlo, DbType.Decimal, ParameterDirection.Input);
                parameters.Add("p_IdZamestnanec", zamestnanec.IdZamestnanec, DbType.Decimal, ParameterDirection.Input);

                await db.ExecuteAsync("ADD_PROHLIDKA", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task DeleteProhlidka(Prohlidka prohlidka)
        {
            using (var db = new OracleConnection(this.connection))
            {
                await db.ExecuteAsync("DELETE FROM PROHLIDKY WHERE ID_PROHLIDKA = :Id", new { Id = prohlidka.IdProhlidka });
            }
        }

        public async Task<List<Prohlidka>> GetAllProhlidky()
        {
            using (var db = new OracleConnection(this.connection))
            {
                var res = await db.QueryAsync<Prohlidka>("SELECT id_prohlidka AS IdProhlidka, datum_zacatek AS DatumZacatek, datum_konec AS DatumKonec, cena_prohlidky AS CenaProhlidky, id_objednavky AS IdObjednavky, id_zakaznik AS IdZakaznik, id_vozidlo AS IdVozidlo, id_zamestnanec AS IdZamestnanec FROM prohlidky");
                return res.ToList();
            }
        }

        public async Task UpdateProhlidka(Prohlidka prohlidka)
        {
            using (var db = new OracleConnection(this.connection))
            {
                var parameters = new DynamicParameters();
                parameters.Add("p_IdProhlidka", prohlidka.IdProhlidka, DbType.Decimal, ParameterDirection.Input);
                parameters.Add("p_DatumZacatek", prohlidka.DatumZacatek, DbType.Date, ParameterDirection.Input);
                parameters.Add("p_DatumKonec", prohlidka.DatumKonec, DbType.Date, ParameterDirection.Input);
                parameters.Add("p_CenaProhlidky", prohlidka.CenaProhlidky, DbType.Decimal, ParameterDirection.Input);
                parameters.Add("p_IdObjednavky", prohlidka.IdObjednavky, DbType.Decimal, ParameterDirection.Input);
                parameters.Add("p_IdZakaznik", prohlidka.IdZakaznik, DbType.Decimal, ParameterDirection.Input);
                parameters.Add("p_IdVozidlo", prohlidka.IdVozidlo, DbType.Decimal, ParameterDirection.Input);
                parameters.Add("p_IdZamestnanec", prohlidka.IdZamestnanec, DbType.Decimal, ParameterDirection.Input);

                await db.ExecuteAsync("UPDATE_PROHLIDKA", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
