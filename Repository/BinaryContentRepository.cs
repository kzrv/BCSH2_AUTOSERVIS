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
    public class BinaryContentRepository : IBinaryContentRepository
    {
        private readonly string connection;

        public BinaryContentRepository(string connection)
        {
            this.connection = connection;
        }

        public async Task<byte[]> GetBlobById(int id)
        {
            byte[] data = null;
            using (var db = new OracleConnection(this.connection))
            {
                data = await db.QueryFirstOrDefaultAsync<byte[]>("SELECT binarni_obsah As BinarniObsah FROM binary_content WHERE ID_CONTENT = :Id", new { Id = id });
            }
            return data;
        }
        public async Task UpdateBinaryContent(BinaryContent binaryContent)
        {
            using (var db = new OracleConnection(this.connection))
            {
                string updateQuery = @"
                    UPDATE BINARY_CONTENT
                    SET
                        binarni_obsah = :binarni_obsah,
                        nazev_souboru = :nazev_souboru,
                        typ_souboru = :typ_souboru,
                        pripona_souboru = :pripona_souboru,
                        datum_nahrani = :datum_nahrani,
                        datum_zmeny = :datum_zmeny,
                        zmenil = :zmenil,
                        operace = :operace
                    WHERE id_content = :id_content";

                int rowsAffected = await db.ExecuteAsync(updateQuery, new
                {
                    binarni_obsah = binaryContent.BinarniObsah,
                    nazev_souboru = binaryContent.NazevSouboru,
                    typ_souboru = binaryContent.TypSouboru,
                    pripona_souboru = binaryContent.Pripona,
                    datum_nahrani = binaryContent.DatumNahrani,
                    datum_zmeny = binaryContent.DatumZmeny,
                    zmenil = binaryContent.Zmenil,
                    operace = binaryContent.Operace,
                    id_content = binaryContent.IdContent
                });
            }
        }
    }
}

