using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBALeague.Domain
{
    class Jucator: Elev
    {
        public Echipa EchipaMea { get; set; }

        public Jucator(int id, string nume, string scoala, Echipa echipaMea):base(id,nume,scoala)
        {
            EchipaMea = echipaMea;
        }

        public override string ToString()
        {
            return "Jucator { Id: " + base.Id + " Nume: " + Nume + " Scoala: " + Scoala + " Echipa: " + EchipaMea.Nume;
        }
    }
}
