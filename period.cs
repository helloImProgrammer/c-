using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    class period
    {
        [Key]
        public int period_id { get; set; }
        public string period_name { get; set; }
        public int period_value { get; set; }
    }
}
