using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace EntityFramework
{
    class student
    {
        [Key]
        public int std_id { get; set; }
        public string std_name { get; set; }
        public string std_surname { get; set; }
        public string tc_no { get; set; }
        public int std_squad_id { get; set; }
        public string std_parola { get; set; }
        public string std_security_the_word { get; set; }
        public int period_id { get; set; }
    }
}
