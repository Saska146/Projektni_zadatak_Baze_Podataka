using Projektni_zadatak.Model;
using Projektni_zadatak.Service;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektni_zadatak.UIHandler
{
    public class SkakacUIHandler
    {
        private static readonly SkakacService skakacService = new SkakacService();

        public void HandleMenu()
        {
            string answer;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Odaberite funkcionalnost:");
                Console.WriteLine("1  - Prikaz svih");
                Console.WriteLine("2  - Prikaz po identifikatoru");
                Console.WriteLine("3  - Unos jednog");
                Console.WriteLine("4  - Unos vise");
                Console.WriteLine("5  - Izmena po identifikatoru");
                Console.WriteLine("6  - Brisanje po identifikatoru");
                Console.WriteLine("X  - Izlazak");

                answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        ShowAll();
                        break;
                    case "2":
                        ShowById();
                        break;
                    case "3":
                        HandleSingleInsert();
                        break;
                    case "4":
                        HandleMultipleInserts();
                        break;
                    case "5":
                        HandleUpdate();
                        break;
                    case "6":
                        HandleDelete();
                        break;
                }

            } while (!answer.ToUpper().Equals("X"));
        }
        private void ShowAll()
        {
            try
            {
                List<Skakac> skakaci = skakacService.FindAll().ToList();
                Console.WriteLine(Skakac.GetFormattedHeader());
                foreach (var item in skakaci)
                {
                    Console.WriteLine(item);
                }
            }
            catch (DbException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void ShowById()
        {
            try
            {
                Console.WriteLine("Unesite id: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Skakac skakac = skakacService.FindById(id);
                if (skakac == null)
                {
                    Console.WriteLine("Skakac ne postoji");
                    return;
                }
                Console.WriteLine(Skakac.GetFormattedHeader());
                Console.WriteLine(skakac);

            }
            catch (DbException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private void HandleSingleInsert()
        {
            Console.WriteLine("Unesite id:");
            int id = Convert.ToInt32(Console.ReadLine());
            try
            {
                if (!skakacService.ExistsById(id))
                {
                    Console.WriteLine("Unesi ime skakaca:");
                    string imeSc = Console.ReadLine();
                    Console.WriteLine("Unesi prezime skakaca:");
                    string przSc = Console.ReadLine();
                    Console.WriteLine("Unesi ID drzave:");
                    string idD = Console.ReadLine(); 
                    Console.WriteLine("Unesi titule:");
                    int titule = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Unesi PB skakaca:");
                    double pbSc = Convert.ToDouble(Console.ReadLine());
                    Skakac s = new Skakac(id, imeSc, przSc, idD, titule, pbSc);
                    skakacService.Save(s);
                }
                else
                {
                    Console.WriteLine("Skakac sa unetim ID-om vec postoji");
                }

            }
            catch (DbException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void HandleUpdate()
        {
            Console.WriteLine("Unesite id:");
            int id = Convert.ToInt32(Console.ReadLine());
            try
            {
                if (skakacService.ExistsById(id))
                {
                    Console.WriteLine("Unesi ime skakaca:");
                    string imeSc = Console.ReadLine();
                    Console.WriteLine("Unesi prezime skakaca:");
                    string przSc = Console.ReadLine();
                    Console.WriteLine("Unesi ID drzave:");
                    string idD = Console.ReadLine();
                    Console.WriteLine("Unesi titule:");
                    int titule = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Unesi PB skakaca:");
                    double pbSc = Convert.ToDouble(Console.ReadLine());
                    Skakac s = new Skakac(id, imeSc, przSc, idD, titule, pbSc);
                    skakacService.Save(s);
                }
                else
                {
                    Console.WriteLine("Skakac sa unetim ID-om vec postoji");
                }

            }
            catch (DbException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void HandleDelete()
        {
            Console.WriteLine("Unesite id:");
            int id = Convert.ToInt32(Console.ReadLine());
            try
            {
                if (skakacService.ExistsById(id))
                {
                    skakacService.DeleteById(id);
                    Console.WriteLine("Uspesno brisanje");
                }
                else
                {
                    Console.WriteLine("Skakac sa unetim ID-om ne postoji");
                }
            }
            catch (DbException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void HandleMultipleInserts()
        {
            {
                int op;
                while (true)
                {
                    Console.WriteLine("[1] Dodaj");
                    Console.WriteLine("[0] Kraj dodavanja");
                    Console.WriteLine("Izaberi opciju");
                    op = Convert.ToInt32(Console.ReadLine());
                    if (op == 0)
                        break;
                    HandleSingleInsert();
                }
            }
        }
    }
}

