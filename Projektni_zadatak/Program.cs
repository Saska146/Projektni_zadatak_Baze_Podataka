using Projektni_zadatak.UIHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektni_zadatak
{
    class Program
    {
        static void Main(string[] args)
        {
            MainUIHandler mainUIHandler = new MainUIHandler();
            mainUIHandler.HandleMainMenu();
            Console.WriteLine("Kraj programa");
            Console.ReadKey();
        }
    }
}
