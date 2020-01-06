using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBALeague.Domain
{
    class Meci:BaseClass<int>
    {
        public Echipa echipa1 { get; set; }
        public Echipa echipa2 { get; set; }
        public DateTime date;

        public Meci(int Id,Echipa echipa1, Echipa echipa2, DateTime date):base(Id)
        {
            this.echipa1 = echipa1;
            this.echipa2 = echipa2;
            this.date = date;
           
        }

        public override string ToString()
        {
            return " Meci{ Id= " + base.Id.ToString() + "  " +
                            echipa1.Nume + "(Id: "+echipa1.Id+" ) - " +
                            echipa2.Nume + "(Id: " + echipa2.Id + " )           " +
                           date.ToString();
        }
    }
}
