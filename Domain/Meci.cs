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
        public string getScorString()
        {
            return this.scor1.ToString() + " : " + this.scor2.ToString();
        }
    }
    class Meci:BaseClass<int>
    {
        private Echipa echipa1 { get; set; }
        private Echipa echipa2 { get; set; }
        private Scor scor { get; set; }
        private DateTime date;

        public Meci(int Id,Echipa echipa1, Echipa echipa2, DateTime date):base(Id)
        {
            this.echipa1 = echipa1;
            this.echipa2 = echipa2;
            this.date = date;
            this.scor = new Scor(echipa1,echipa2);
           
        }
        public Meci(int Id, Echipa echipa1, Echipa echipa2, int scor1, int scor2, DateTime date) : base(Id)
        {
            this.echipa1 = echipa1;
            this.echipa2 = echipa2;
            this.date = date;
            this.scor = new Scor(scor1, scor2, echipa1, echipa2);

        }
    }
}
