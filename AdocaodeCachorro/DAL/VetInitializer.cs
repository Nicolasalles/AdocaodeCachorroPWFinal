using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using AdocaodeCachorro.Models;

namespace AdocaodeCachorro.DAL
{
    public class VetInitializer: System.Data.Entity. DropCreateDatabaseIfModelChanges<VetContext>
    {
        protected override void Seed(VetContext context)
        {
            var donos = new List<Dono>
            {
                new Dono{DonoID=1, NomeDono="Carson", VarRG = "00000000-0" , VarIdade=12, Cachorro = "Rex"}

            };

            donos.ForEach(s => context.Donos.Add(s));
            context.SaveChanges();
            var cachorros = new List<Cachorro>
            {
                new Cachorro{CachorroNome = "Rex", CachorroID = 1, Idade = 2, Raca = "Vira-Lata", DonoID = 1},
            };
            cachorros.ForEach(s => context.Cachorros.Add(s));
            context.SaveChanges();
        }
    }
}