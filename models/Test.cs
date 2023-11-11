using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kozyrev_Hriha_SP.Models
{
    public class Test
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }


    }
}
