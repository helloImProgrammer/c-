using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    class selected_period
    {
        [Key]
        public int selected_period_id { get; set; }
        public int selected_period_value { get; set; }

    }
}
