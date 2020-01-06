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
        }

    }
}
