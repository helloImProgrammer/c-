using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework
{
    class ders_ver
    {
        [Key]
        public int ders_ver_id { get; set; }
        public int teacher_id { get; set; }
        public int cls_id { get; set; }
        
    }
}
