using Projektni_zadatak.DTO;
using Projektni_zadatak.Model;
using Projektni_zadatak.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektni_zadatak.UIHandler
{
    class ComplexQueryUIHandler
    {
        private static readonly ComplexQueryService complexQueryService = new ComplexQueryService();
        private static readonly SkakacService skakacService = new SkakacService();
        public void HandleMenu()
        {
            string answer;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Odaberite funkcionalnost:");
                Console.WriteLine("1  - Izvestaj svih skakaca jedne drzave");
                Console.WriteLine("2  - Izvestaj po tipu skakaonice");
                Console.WriteLine("X  - Izlazak");

                answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        SkakaciJedneDrzave();
                        break;
                    case "2":
                        SkokoviPoTipu();
                       break;
                    
                }

            } while (!answer.ToUpper().Equals("X"));
        }

        private void SkakaciJedneDrzave()
        {
            try
            {
                Console.WriteLine("Unesi ID drzave:");
                string idd = Console.ReadLine();
                SkakaciDrzava skakaciDrzava = complexQueryService.SkakaciJedneDrzave(idd);

                if (skakaciDrzava.skakaci.Count == 0)
                {
                    Console.WriteLine("Drzava sa ID: " + idd + " nema skakace.");
                    return;
                }

                Console.WriteLine(Skakac.GetFormattedHeader());
                foreach (var item in skakaciDrzava.skakaci)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("Ukupan broj titula: " + skakaciDrzava.UkupanBrojTitula);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void SkokoviPoTipu()
        {
            try
            {
                List<TipSkakaonice> tipSkakaonices = complexQueryService.SkokoviPoTipu();

                foreach (TipSkakaonice item in tipSkakaonices)
                {
                    List<Skok> skok = skakacService.PrikazivanjePoTipu(item.TipSk).ToList();

                    Console.WriteLine("Skokovi po tipu skakaonice: " + item.TipSk);
                    Console.WriteLine(Skok.GetFormattedHeader());
                    foreach (var s in skok)
                    {
                        Console.WriteLine(s);
                    }
                    Console.WriteLine("Ukupan broj skokova: " + skok.Count + ", Ukupan broj razlicitih skakaca: " + item.RazlicitiSkakaci);
                    Console.WriteLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
