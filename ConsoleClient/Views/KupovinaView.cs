using System;
using System.Collections.Generic;
using System.Text;
using ConsoleClient.Views;
using Core.DAO;
using Core.Models;
using Core.Utils;

namespace ConsoleClient.Views
{
    internal class KupovinaView : GenericView<Kupovina>
    {
        private readonly KupovinaDAO _kupovineDAO = new();
        private readonly PosetilacDAO _posetiociDAO = new();
        private readonly KnjigaDAO _knjigeDAO = new();

        public KupovinaView(KupovinaDAO kupovineDAO, PosetilacDAO posetiociDAO, KnjigaDAO knjigeDAO) : base(kupovineDAO, "Kupovine")
        {
            _kupovineDAO = kupovineDAO;
            _posetiociDAO = posetiociDAO;
            _knjigeDAO = knjigeDAO;
        }
        // unos kupovine
        protected override Kupovina InputObj()
        {
            return new Kupovina
            {
                IDposetioca = ConsoleViewUtils.SafeInputInt("ID posetioca: "),
                IDknjige = ConsoleViewUtils.SafeInputInt("ID knjige: "),
                Datum_kupovine =
            ConsoleViewUtils.SafeInputDateOnly("Datum kupovine [yyyy-MM-dd]: "),
                Ocena = ConsoleViewUtils.SafeInputInt("Ocena [1-5]: "),
                Komentar = ConsoleViewUtils.SafeInputStr("Komentar: ")
            };
        }
        // ispis kupovine
        protected override void PrintObj(Kupovina kupovina)
        {
            System.Console.WriteLine($"[{kupovina.Id}] Posetilac ID: {kupovina.IDposetioca} | Knjiga ID: {kupovina.IDknjige}");
            System.Console.WriteLine($"--> Datum kupovine: {CsvConversion.FromDate(kupovina.Datum_kupovine)}");
            System.Console.WriteLine($"--> Ocena: {kupovina.Ocena}");
            System.Console.WriteLine($"--> Komentar: {kupovina.Komentar}");
            System.Console.WriteLine();
        }
        // izmena kupovine
        protected override void ReadUpdatedObj(Kupovina kupovina)
        {
            int choice;

            do
            {
                System.Console.WriteLine(
                    $">---- Izmena kupovine ID {kupovina.Id} ----<");

                System.Console.WriteLine("1 - ID posetioca");
                System.Console.WriteLine("2 - ID knjige");
                System.Console.WriteLine("3 - Datum kupovine");
                System.Console.WriteLine("4 - Ocena");
                System.Console.WriteLine("5 - Komentar");
                System.Console.WriteLine("0 - Zavrsi izmenu");
                System.Console.WriteLine(">-------------------------------------------------<");
                System.Console.WriteLine("Unesite broj vaseg izbora: ");
                choice = ConsoleViewUtils.SafeInputInt();

                switch (choice)
                {
                    case 1:
                        System.Console.Write($"Novi ID posetioca (Stari - [{kupovina.IDposetioca}]): ");
                        kupovina.IDposetioca = ConsoleViewUtils.SafeInputInt();
                        break;

                    case 2:
                        System.Console.Write($"Novi ID knjige (Stari - [{kupovina.IDknjige}]): ");
                        kupovina.IDknjige = ConsoleViewUtils.SafeInputInt();
                        break;

                    case 3:
                        System.Console.Write($"Novi datum (Stari - [{CsvConversion.FromDate(kupovina.Datum_kupovine)}]): ");
                        kupovina.Datum_kupovine = ConsoleViewUtils.SafeInputDateOnly();
                        break;

                    case 4:
                        System.Console.Write($"Nova ocena (Stara - [{kupovina.Ocena}]): ");
                        kupovina.Ocena = ConsoleViewUtils.SafeInputInt();
                        break;

                    case 5:
                        System.Console.Write($"Novi komentar (Stari - [{kupovina.Komentar}]): ");
                        kupovina.Komentar = ConsoleViewUtils.SafeInputStr();
                        break;

                    case 0:
                        break;

                    default:
                        System.Console.WriteLine("Greska!!! Uneseni broj nije u opsegu.");
                        System.Console.WriteLine();
                        break;
                }
            } while (choice != 0);
        }

        protected override void ObjRemoved(Kupovina kupovina)
        {
            
        }
    }
}
