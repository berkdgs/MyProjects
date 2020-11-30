using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YemekListExcel.Entities.Contexts
{
    class ModelContext : DbContext
    {
        public  ModelContext() : base("name=con") { }

        public DbSet<Yemekler> YemeklerList  { get; set; }
    }
}