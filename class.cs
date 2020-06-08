using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace EntityFramework
{
    class @class
    {
        [Key]
        public int cls_id { get; set; }
        public string cls_name { get; set; }
        public int std_squad_id { get; set; }
        public int credits { get; set; }
        public int period { get; set; }
    }
}
