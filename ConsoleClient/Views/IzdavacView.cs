using System;
using System.Collections.Generic;
using System.Text;
using Core.DAO;
using Core.Models;
using Core.Utils;


namespace ConsoleClient.Views
{
    internal class IzdavacView : GenericView<Izdavac>
    {
        private readonly IzdavacDAO _izdavacDAO = new();
        public IzdavacView(IzdavacDAO izdavacDAO) : base(izdavacDAO, "Izdavaci")
        {
            _izdavacDAO = izdavacDAO;
        }
        protected override Izdavac InputObj()
        {
            return new Izdavac 
            { 
                Sifra = ConsoleViewUtils.SafeInputStr("Sifra: "),
                Naziv = ConsoleViewUtils.SafeInputStr("Naziv: "),
                IDsefa = ConsoleViewUtils.SafeInputInt("ID sefa: ")
            };
        }

        protected override void PrintObj(Izdavac izdavac)
        {
            System.Console.WriteLine($"[{izdavac.Id}] {izdavac.Naziv} ({izdavac.Sifra})");
            System.Console.WriteLine($"---> ID sefa: {izdavac.IDsefa}");
        }

        protected override void ReadUpdatedObj(Izdavac izdavac)
        {
            int choice;
            do
            {
                System.Console.WriteLine($">--- Izmena izdavaca: {izdavac.Naziv}---<");
                System.Console.WriteLine("1 - Sifra");
                System.Console.WriteLine("2 - Naziv");
                System.Console.WriteLine("3 - ID sefa");
                System.Console.WriteLine("0 - Zavrsi izmenu");
                System.Console.WriteLine("Unesite broj vaseg izbora: ");
                choice = ConsoleViewUtils.SafeInputInt();
                System.Console.WriteLine();

                switch(choice)
                {
                    case 1:
                        System.Console.Write($"Nova sifra (stara sifra - [{izdavac.Sifra}]): ");
                        izdavac.Sifra = ConsoleViewUtils.SafeInputStr();
                        System.Console.WriteLine();
                        break;
                    case 2:
                        System.Console.Write($"Novi naziv (stari naziv - [{izdavac.Naziv}]): ");
                        izdavac.Naziv = ConsoleViewUtils.SafeInputStr();
                        System.Console.WriteLine();
                        break;
                    case 3:
                        System.Console.Write($"Novi ID sefa (stari ID sefa - [{izdavac.IDsefa}]): ");
                        izdavac.IDsefa = ConsoleViewUtils.SafeInputInt();
                        System.Console.WriteLine();
                        break;
                    case 0:
                        break;
                    default:
                        System.Console.WriteLine("Greska!!! Uneseni broj nije u opsegu");
                        System.Console.WriteLine();
                        break;

                }
            } while (choice != 0);
        }

        protected override void ObjRemoved(Izdavac izdavac)
        {
            throw new NotImplementedException();
        }
    }
}
