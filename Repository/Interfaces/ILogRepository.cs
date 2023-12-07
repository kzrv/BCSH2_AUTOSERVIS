using Kozyrev_Hriha_SP.Models;
using Kozyrev_Hriha_SP.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kozyrev_Hriha_SP.Repository.Interfaces
{
    public interface ILogRepository
    {
        Task<List<Logg>> GetAllLogy();
        void DeleteAllLogs();
    }
}
