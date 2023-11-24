using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kozyrev_Hriha_SP.Utils.Exceptions
{
    public class UserIsAlreadyExistsException : Exception
    {
        public UserIsAlreadyExistsException(string message) : base(message)
        {
        }
    }
}
