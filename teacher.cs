using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace EntityFramework
{
    class teacher
    {
        [Key]
        public int teacher_id { get; set; }
        public string teacher_password { get; set; }
        public string teacher_name { get; set; }
        public string teacher_surname { get; set; }
        public int std_squad_id { get; set; }
        public string tc_no { get; set; }
        public string teacher_security_the_word { get; set; }
    }
}
