using NBALeague.Controller;
using NBALeague.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

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
            Console.WriteLine("4. Toate Meciurile");
            Console.WriteLine("5. Toti Jucatorii unei Echipe");
            Console.WriteLine("6. Toti Jucatorii Activi ai unei Echipe de la un anumit Meci");
            Console.WriteLine("7. Toate Meciurile dintr-o perioada");
            Console.WriteLine("8. Scorul de la un Meci");
            Console.WriteLine("X. Iesire ");
        }

        private void Toti_elevii()
        {
            List<Elev> e = controller.TotiElevii();
            if (e == null)
                Console.WriteLine("nu exista elevi");
            else
                e.ForEach(Console.WriteLine);
        }

        private void Toti_jucatorii()
        {
            List<Jucator> j = controller.TotiJucatorii();
            if (j == null)
                Console.WriteLine("nu exista jucatori");
            else
                j.ForEach(Console.WriteLine);
        }
        private void Toate_echipele()
        {
            List<Echipa> ec = controller.ToateEchipele();
            if (ec == null)
                Console.WriteLine("nu exista echipe");
            else
                ec.ForEach(Console.WriteLine);
        }
        private void Toate_meciurile()
        {
            List<Meci> m = controller.ToateMeciurile();
            if (m == null)
                Console.WriteLine("nu exista meciuri");
            else
                m.ForEach(Console.WriteLine);
        }
        private void Jucatorii_echipei()
        {
            Console.WriteLine("dati id-ul echipei: ");
            int echipa;
            Int32.TryParse(Console.ReadLine(), out echipa);
            if (echipa == 0)
                Console.WriteLine("id-ul e un intreg");
            else
                controller.GetJucatoriEchipa(echipa).ForEach(Console.WriteLine);

        }
        private void JucatoriAct_echipa_meci()
        {
            Console.WriteLine("dati id-ul meciului: ");
            Int32.TryParse(Console.ReadLine(), out int meci);
            if (meci == 0)
            {
                Console.WriteLine("id-ul e un nr intreg");
                return;
            }
            Meci m = controller.MeciService.GetOne(meci);
            if (m == null)
            {
                Console.WriteLine("meciul nu exista");
                return;
            }
            Console.WriteLine(m);

            Console.WriteLine("dati id-ul echipei: ");
            Int32.TryParse(Console.ReadLine(), out int echipa1);
            if (echipa1 == 0)
            {
                Console.WriteLine("id-ul e un nr intreg");
                return;
            }
            Echipa e = controller.EchipeService.GetOne(echipa1);
            if (e == null)
            {
                Console.WriteLine("echipa nu exista");
                return;
            }
           
            Console.WriteLine(e);
            List<JucatorActiv> lista = controller.GetJucatorActivMeciEchipa(echipa1, meci);
            if (lista.Count() == 0)
            {
                Console.WriteLine("echipa selectata nu a participat la acest meci");
                return;
            }
            lista.ForEach(Console.WriteLine);
        }
    private void Meciuri_perioada()
        {
            Console.WriteLine("Data de start: LL-ZZ-AAAA");
            DateTime.TryParse(Console.ReadLine(), out DateTime startDate);
            if (startDate.Year == 1)
            {
                Console.WriteLine("te rog respecta formatul pentru data");
                return;
            }
            Console.WriteLine("Data de sfarsit:  LL-ZZ-AAAA");
            DateTime.TryParse(Console.ReadLine(), out DateTime endDate);
            if (endDate.Year == 1)
            {
                Console.WriteLine("te rog respecta formatul pentru data");
                return;
            }
            List<Meci> lista = controller.GetMeciuriData(startDate, endDate);
            if (lista.Count == 0)
            {
                Console.WriteLine("nu exista meciuri in aceasta perioada");
                return;
            }
            lista.ForEach(Console.WriteLine);
        }
        private void Scor_meci()
        {
            Console.WriteLine("dati id-ul meciului: ");
            Int32.TryParse(Console.ReadLine(), out int meci);
            if (meci == 0)
            {
                Console.WriteLine("id-ul trebuie sa fie numar intreg");
                return;
            }

            Scor scor = controller.GetScor(meci);
            if (scor==null)
            {
                Console.WriteLine("acest meci nu exista");
                return;
            }
            Console.WriteLine(scor);
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
                        Toti_elevii();
                        break;
                    case "2":
                        Toti_jucatorii();
                        break;
                    case "3":
                        Toate_echipele();
                        break;
                    case "4":
                        Toate_meciurile();
                        break;
                    case "5":
                        Jucatorii_echipei();
                        break;
                    case "6":
                        JucatoriAct_echipa_meci();
                        break;
                    case "7":
                        Meciuri_perioada();
                        break;
                    case "8":
                        Scor_meci();
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
