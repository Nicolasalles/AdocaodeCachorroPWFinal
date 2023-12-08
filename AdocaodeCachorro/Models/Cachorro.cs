using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdocaodeCachorro.Models
{
    public class Cachorro
    {
        public int CachorroID { get; set; }
        public string CachorroNome { get; set; }
        public int DonoID { get; set; }
        public string Raca  { get; set; }
        public int Idade { get; set; }

        public virtual Dono Dono { get; set; }
    }
}