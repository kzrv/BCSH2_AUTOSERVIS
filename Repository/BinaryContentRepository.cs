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

        public byte[] GetBlobById(int id)
        {
            byte[] data = null;
            using (var db = new OracleConnection(this.connection))
            {
                data = db.Query<byte[]>("SELECT binarni_obsah As BinarniObsah FROM binary_content WHERE ID_CONTENT = :Id", new { Id = id }).FirstOrDefault();
            }
            return data;
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
    }
}
