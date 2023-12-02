using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kozyrev_Hriha_SP.Repository.Interfaces
{
    public class UkolRepository : IUkolRepository
    {
        private readonly string connection;

        public UkolRepository(string connection)
        {
            this.connection = connection;
        }
    }
}
