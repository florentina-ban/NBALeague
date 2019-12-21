using NBALeague.Domain;
using NBALeague.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBALeague
{
    class Program
    {
        static void Main(string[] args)
        {            
            InMemoryRepo<int,Elev> repo = new InMemoryRepo<int,Elev>();
            Elev e1 = new Elev(1, "nume1", "scoala");
            Elev e2 = new Elev(2, "nume2", "scoala");
            Elev e3 = new Elev(3, "nume3", "scoala");
            Elev e4 = new Elev(4, "nume4", "scoala");

            EleviDBRepo eleviRepo = new EleviDBRepo();
            eleviRepo.LoadData();
            //eleviRepo.getToti().ForEach(x => Console.WriteLine(x));

            EchipaDBRepo echipaRepo = new EchipaDBRepo();
            echipaRepo.LoadData();
            //echipaRepo.getToti().ForEach(Console.WriteLine);

            JucatoriDBRepo jucatoriRepo = new JucatoriDBRepo(echipaRepo);
            jucatoriRepo.LoadData();
            //jucatoriRepo.getToti().ForEach(Console.WriteLine);

            MeciDBRepo meciRepo = new MeciDBRepo(echipaRepo);
            meciRepo.LoadData();
            meciRepo.getToti().ForEach(Console.WriteLine);
        }

    }
}
