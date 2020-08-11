using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbAppTask2.Models;
using System.Data.Entity;

namespace DbAppTask2.Models
{
    public class RegContext : DbContext
    {
        public RegContext() : base("DefaultConnection")
        {

        }
        public DbSet<Registration> dbprojects { get; set; }
    }
}