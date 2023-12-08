using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AdocaodeCachorro.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AdocaodeCachorro.DAL
{
    public class VetContext: DbContext
    {
        public VetContext() : base("VetContext")
        {
        }

        public DbSet<Dono> Donos { get; set; }
        public DbSet<Cachorro> Cachorros { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}