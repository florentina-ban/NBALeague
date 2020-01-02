using NBALeague.Controller;
using NBALeague.Domain;
using NBALeague.Repository;
using NBALeague.Services;
using NBALeague.UI;
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
            MainController mainController = new MainController();
            Consola consola = new Consola(mainController);
            consola.Execute();

/*      
            // scorul de un anumit meci - stiind id-ul meciului
            int meci2 = 4;
            Scor s = meciRepo.getScor(meci2);
            if (s==null)
                Console.WriteLine("meciul nu exista");
            else
                Console.WriteLine("scorul pt meciul "+meci2.ToString()+ " "+s.ToString());

            // scorul de un anumit meci - stiind id-ul id-ul echipelor
            int ec1 = 2;
            int ec2 = 4;
            List<Scor> scorList = meciRepo.getScor(ec1, ec2);
            if (scorList==null)
                Console.WriteLine("meciul nu exista");
            else
                meciRepo.getScor(ec1, ec2).ForEach(Console.WriteLine);
                */
        }

    }
}
