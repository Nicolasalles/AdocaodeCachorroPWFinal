using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdocaodeCachorro.Models
{
    public class Dono
    {

        public int DonoID { get; set; }
        public string NomeDono { get; set; }
        public string VarRG { get; set; }
        public int VarIdade  { get; set; }

        public string Cachorro { get; set;}

        public virtual ICollection<Cachorro> Cachorros { get; set; }    
    }
}