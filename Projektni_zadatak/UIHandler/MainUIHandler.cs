using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektni_zadatak.UIHandler
{
    public class MainUIHandler
    {
       private readonly ComplexQueryUIHandler complexQueryUIHandler = new ComplexQueryUIHandler();
        private readonly SkakacUIHandler skakacUIHandler = new SkakacUIHandler();

        public void HandleMainMenu()
        {
            string answer;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Odaberite opciju:");
                Console.WriteLine("1 - Rukovanje objektima");
                Console.WriteLine("2 - Kompleksni upiti");
                Console.WriteLine("X - Izlazak iz programa");

                answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        skakacUIHandler.HandleMenu();
                        break;
                    case "2":
                        complexQueryUIHandler.HandleMenu();
                        break;
                }

            } while (!answer.ToUpper().Equals("X"));
        }
    }
}

