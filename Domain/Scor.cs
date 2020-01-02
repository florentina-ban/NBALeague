using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBALeague.Domain
{
    class Scor
    {
        private int scor1 { get; set; }
        private int scor2 { get; set; }
        private Echipa echipa1 { get; set; }
        private Echipa echipa2 { get; set; }

        public Scor(int scor1, int scor2, Echipa echipa1, Echipa echipa2)
        {
            this.scor1 = scor1;
            this.scor2 = scor2;
            this.echipa1 = echipa1;
            this.echipa2 = echipa2;
        }

        public Scor(Echipa echipa1, Echipa echipa2)
        {
            this.echipa1 = echipa1;
            this.echipa2 = echipa2;
            this.scor1 = 0;
            this.scor2 = 0;
        }
        public override string ToString()
        {
            return echipa1.Nume + " - " +
                   echipa2.Nume + "        " +
                   this.scor1.ToString() + " : " +
                   this.scor2.ToString();
        }
    }
}
