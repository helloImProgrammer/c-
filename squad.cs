using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace EntityFramework
{
    class squad
    {
        [Key]
        public int std_squad_id { get; set; }
        public string std_squad_name { get; set; }
    }
}
