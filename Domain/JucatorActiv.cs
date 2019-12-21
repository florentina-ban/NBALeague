using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBALeague.Domain
{
    public enum TipJucator { REZERVA, PARTICIPANT }

    class JucatorActiv
    {
        private int Id { get; set; }
        private int IdMeci { get; set; }
        private int NrPuncteInscrise { get; set; }
        private TipJucator Tip { get; set; }

    }
}
