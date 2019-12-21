using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBALeague.Domain
{
    class Elev:BaseClass<int>
    {
        private string nume;
        public string Nume
        {
            get { return nume; }
            set { nume = value; }
        }
        private string scoala;
        public string Scoala
        {
            get { return scoala; }
            set { scoala = value; }
        }

        public Elev(int id, string nume, string scoala):base(id)
        {
            Nume = nume;
            Scoala = scoala;
        }

        public override string ToString()
        {
            return "Elev{ Id: "+base.Id +"  nume: "+Nume+"  scoala: "+Scoala +" }";
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}
