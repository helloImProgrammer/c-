using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    class odev_sql_OKULContext:DbContext
    {
        public DbSet<student> students { get; set; }
        public DbSet<teacher> teachers { get; set; }
        public DbSet<squad> squads { get; set; }
        public DbSet<points> points { get; set; }
        public DbSet<ders_ver> ders_ver { get; set; }
        public DbSet<ders_al> ders_al { get; set; }
        public DbSet<@class> @class { get; set; }
        public DbSet<admin1> admin1 { get; set; }
        public DbSet<profile_std> profile_std { get; set; }   //view tablo
        public DbSet<profile_TS>profile_TS { get; set; }
        public DbSet<period>period { get; set; }
        public DbSet<selected_period> selected_period { get; set; }

    }
}
