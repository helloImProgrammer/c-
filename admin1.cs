﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace EntityFramework
{
  
    class admin1
    {
        [Key]
        public string name { get; set; }

        public string pass { get; set; }

    }
}
