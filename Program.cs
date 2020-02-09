using NBALeague.Controller;
using NBALeague.UI;

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
