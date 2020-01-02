using NBALeague.Domain;
using NBALeague.Repository;
using NBALeague.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBALeague.Controller
{
    class MainController
    {
        public Service<int, Elev, EleviDBRepo> EleviService;
        public Service<int, Echipa, EchipaDBRepo> EchipeService;
        public Service<int, Jucator, JucatoriDBRepo> JucatoriService;
        public Service<string, JucatorActiv, JucatoriActDBRepo> JucatoriActiviService;
        public Service<int, Meci, MeciDBRepo> MeciService;

        public MainController()
        {
            EleviDBRepo eleviRepo = new EleviDBRepo();
            EchipaDBRepo echipeRepo = new EchipaDBRepo();
            JucatoriDBRepo jucatoriRepo = new JucatoriDBRepo(echipeRepo);
            JucatoriActDBRepo jucatoriActRepo = new JucatoriActDBRepo();
            MeciDBRepo meciRepo = new MeciDBRepo(echipeRepo, jucatoriActRepo, jucatoriRepo);

            EleviService = new Service<int, Elev, EleviDBRepo>(eleviRepo);
            EchipeService = new Service<int, Echipa, EchipaDBRepo>(echipeRepo);
            JucatoriService = new Service<int, Jucator, JucatoriDBRepo>(jucatoriRepo);
            JucatoriActiviService = new Service<string, JucatorActiv, JucatoriActDBRepo>(jucatoriActRepo);
            MeciService = new Service<int, Meci, MeciDBRepo>(meciRepo);
        }
        public List<Elev> TotiElevii()
        {
            return EleviService.getToti();
        }

        public List<Jucator> TotiJucatorii()
        {
            return JucatoriService.getToti();
        }
        public List<Meci> ToateMeciurile()
        {
            return MeciService.getToti();
        }
        public List<JucatorActiv> TotiJucatoriiActivi()
        {
            return JucatoriActiviService.getToti();
        }
        public List<Echipa> ToateEchipele()
        {
            return EchipeService.getToti();
        }
        public List<Jucator> GetJucatoriEchipa(int echipa)
        {
            return JucatoriService.getToti().Where(x => x.EchipaMea.Id == echipa).ToList();
        }
        public List<JucatorActiv> GetJucatorActivMeciEchipa(int echipa, int meci)
        {
            return
                JucatoriActiviService.getToti()
                    .Where(x => x.IdMeci == meci && x.Tip==TipJucator.PARTICIPANT && JucatoriService.GetOne(x.IdJucator).EchipaMea.Id == echipa )
                    .ToList();
        }
        public Scor GetScor(int meci)
        {
            return MeciService.myRepo.getScor(meci);
        }

        public List<Meci> GetMeciuriData(DateTime startDate, DateTime endDate)
        {
            return MeciService.getToti().Where(x => x.date.CompareTo(startDate) >= 0 && x.date.CompareTo(endDate) <= 0).ToList();
        }
    }
}
