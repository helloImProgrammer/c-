using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace EntityFramework
{
    class ders_al
    {
        [Key]
        public int ders_al_id { get; set; }
        public int std_id { get; set; }
        public int cls_id { get; set; }
        
    }
}
