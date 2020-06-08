using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace EntityFramework
{
    class profile_TS
    {
        [Key]
        public int teacher_id { get; set; }
        public string teacher_name { get; set; }
        public string teacher_surname { get; set; }
        public string std_squad_name { get; set; }
    }
}
