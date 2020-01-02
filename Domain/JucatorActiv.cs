using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBALeague.Domain
{
    public enum TipJucator { REZERVA, PARTICIPANT }

    class JucatorActiv:BaseClass<string>
    {
        public int IdJucator { get; set; }
        public int IdMeci { get; set; }
        public int NrPuncteInscrise { get; set; }
        public TipJucator Tip { get; set; }

        public JucatorActiv(int idJuc, int idMeci, int nrPuncteInscrise, TipJucator tip):base(idJuc.ToString()+"_"+idMeci.ToString())
        {
            IdJucator = idJuc;
            IdMeci = idMeci;
            NrPuncteInscrise = nrPuncteInscrise;
            Tip = tip;
        }

        public override string ToString()
        {
            return "Jucator activ : Id: " +
                    base.Id.Split('_')[0] + "   id meci: " +
                    IdMeci.ToString() + "   nr puncte: " +
                    NrPuncteInscrise.ToString() + "      " +
                    Tip;
        }
    }
}
