using NBALeague.Controller;
using NBALeague.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBALeague.UI
{
    class Consola
    {
        public MainController controller;

        public Consola(MainController controller)
        {
            this.controller = controller;
        }
        public void Show()
        {
            Console.WriteLine("1. Toti Elevii");
            Console.WriteLine("2. Toti Jucatorii");
            Console.WriteLine("3. Toate Echipele");
            Console.WriteLine("4. Toate Meciurile" );
            Console.WriteLine("5. Toti Jucatorii unei Echipe" );
            Console.WriteLine("6. Toti Jucatorii Activi ai unei Echipe de la un anumit Meci");
            Console.WriteLine("7. Toate Meciurile dintr-o perioada");
            Console.WriteLine("8. Scorul de la un Meci");
            Console.WriteLine("X. Iesire ");
        }

    public void Execute()
        {
            string cmd="";
            while (cmd.ToUpper().CompareTo("X") != 0)
            {
                Show();
                Console.WriteLine("dati comanda dvs: ");
                cmd = Console.ReadLine();
                switch (cmd)
                {
                    case "1":
                        List<Elev> e= controller.TotiElevii();
                        if (e == null)
                            Console.WriteLine("nu exista elevi");
                        else
                            e.ForEach(Console.WriteLine);
                        break;
                    case "2":
                        List<Jucator> j = controller.TotiJucatorii();
                        if (j==null)
                            Console.WriteLine("nu exista jucatori");
                        else
                            j.ForEach(Console.WriteLine);
                        break;
                    case "3":
                        List<Echipa> ec = controller.ToateEchipele();
                        if (ec==null)
                            Console.WriteLine("nu exista echipe");
                        else
                            ec.ForEach(Console.WriteLine);
                        break;
                    case "4":
                        List<Meci> m = controller.ToateMeciurile();
                        if (m==null)
                            Console.WriteLine("nu exista meciuri");
                        else
                            m.ForEach(Console.WriteLine);
                        break;
                    case "5":
                        Console.WriteLine("dati id-ul echipei: ");
                        int echipa;
                        Int32.TryParse(Console.ReadLine(),out echipa);
                        controller.GetJucatoriEchipa(echipa).ForEach(Console.WriteLine);
                        break;
                    case "6":
                        Console.WriteLine("dati id-ul meciului: ");
                        int meci;
                        Int32.TryParse(Console.ReadLine(), out meci);
                        Console.WriteLine("dati id-ul echipei: ");
                        int echipa1;
                        Int32.TryParse(Console.ReadLine(), out echipa1);
                        Console.WriteLine(controller.EchipeService.GetOne(echipa1));
                        Console.WriteLine(controller.MeciService.GetOne(meci));
                        controller.GetJucatorActivMeciEchipa(echipa1, meci).ForEach(Console.WriteLine);
                        break;
                    case "7":
                        Console.WriteLine("Data de start: ZZ-LL-AAAA");
                        DateTime startDate, endDate;
                        DateTime.TryParse(Console.ReadLine(),out startDate);
                        Console.WriteLine("Data de sfarsit:  ZZ-LL-AAAA");
                        DateTime.TryParse(Console.ReadLine(), out endDate);
                        controller.GetMeciuriData(startDate, endDate).ForEach(Console.WriteLine);
                        break;
                    case "8":
                        Console.WriteLine("dati id-ul meciului: ");
                        int meci1;
                        Int32.TryParse(Console.ReadLine(), out meci1);
                        Console.WriteLine(controller.GetScor(meci1));
                        break;
                    case "X":
                        break;
                    case "x":
                        break;
                    default:
                        Console.WriteLine("comanda invalida");
                        break;
                   

                }
            }
        }
    }
}
