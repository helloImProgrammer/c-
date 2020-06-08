using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace EntityFramework
{
    class profile_std
    {
        [Key]
        public int std_id { get; set; }
        public string std_name { get; set; }
        public string std_surname { get; set; }
        public string std_squad_name { get; set; }
    }
}
