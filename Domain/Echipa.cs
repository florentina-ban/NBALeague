using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBALeague.Domain
{
    class Echipa:BaseClass<int>
    {
        public string Nume { get; set; }

        public Echipa(int id, string nume):base(id)
        {
            Nume = nume;
        }

        public override string ToString()
        {
            return "Echipa: { ID: "+base.Id+" Nume: "+Nume+" }";

        }
    }
}
