using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;

namespace EntityFramework
{
    class points
    {
        [Key]
        public int points_id { get; set; }
        public int std_vize_point { get; set; }
        public int std_final_point { get; set; }
        public int std_id { get; set; }
        public int cls_id { get; set; }
    }
}
