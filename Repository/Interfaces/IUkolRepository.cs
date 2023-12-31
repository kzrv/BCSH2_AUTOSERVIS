﻿using Kozyrev_Hriha_SP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kozyrev_Hriha_SP.Repository.Interfaces
{
    public interface IUkolRepository
    {
        Task<List<Ukol>> GetUkolyBySluzbaID(int id);
        Task DeleteUkol(Ukol ukol);
        Task UpdateUkol(Ukol ukol);

        Task AddNewUkol(Ukol ukol, int IdSluzba);
    }
}
