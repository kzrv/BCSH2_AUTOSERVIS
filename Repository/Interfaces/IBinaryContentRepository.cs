using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kozyrev_Hriha_SP.Models;

namespace Kozyrev_Hriha_SP.Repository.Interfaces
{
    public interface IBinaryContentRepository
    {
        byte[] GetBlobById(int id);
        void UpdateBinaryContent(BinaryContent binaryContent);
    }
}
