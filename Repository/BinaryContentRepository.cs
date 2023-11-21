using Dapper;
using Kozyrev_Hriha_SP.Models;
using Kozyrev_Hriha_SP.Repository.Interfaces;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
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
                data = db.Query<byte[]>("SELECT BINARNI_OBSAH FROM BINARY_CONTENT WHERE ID_CONTENT = :Id", new { Id = id }).FirstOrDefault();
            }
            return data;
        }
    }
}
