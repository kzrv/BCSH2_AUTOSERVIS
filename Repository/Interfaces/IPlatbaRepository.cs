﻿using Kozyrev_Hriha_SP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kozyrev_Hriha_SP.Repository.Interfaces
{
    public interface IPlatbaRepository
    {
        Task<List<Platba>> GetAllPlatby();
        string GetIdentByPlatba(Platba platba);
        Task DeletePlatba(Platba platba);
    }
}
