using Core.DAO;
using Core.Models;
using Core.Utils;
using System.Net;

namespace ConsoleClient.Views
{
    internal class AutorView : GenericView<Autor>
    {
        private readonly AutorDAO _autoriDAO = new();
        private readonly KnjigaDAO _knjigeDAO = new();

        private readonly AdresaDAO _adreseDAO = new();
        //private readonly IzdavacDAO _izdavaciDAO = new();

        public AutorView(AutorDAO autoriDAO, KnjigaDAO knjigeDAO) : base(autoriDAO, "autori.txt")
        {
            _knjigeDAO = knjigeDAO;
        }

        protected override Autor InputObj()
        {
            return new Autor
            {
                Ime = ConsoleViewUtils.SafeInputStr("Ime: "),
                Prezime = ConsoleViewUtils.SafeInputStr("Prezime: "),
                Datum = ConsoleViewUtils.SafeInputDateOnly("Datum: "),
                Telefon = ConsoleViewUtils.SafeInputStr("Telefon: "),
                Email = ConsoleViewUtils.SafeInputStr("Email :"),
                Licna_karta = ConsoleViewUtils.SafeInputStr("Licna karta: "),
                Godine_iskustva = ConsoleViewUtils.SafeInputInt("Godine iskustva: ")
            }; 
        }

        protected override void ObjRemoved(Autor autor)
        {
            
        }

        protected override void PrintObj(Autor autor)
        {
        }

        protected override void ReadUpdatedObj(Autor autor)
        {
            int choice;
            do
            {
                System.Console.WriteLine($">---- Izmena autora: {autor.Ime} {autor.Prezime} ----<");
                System.Console.WriteLine("1 - Ime");
                System.Console.WriteLine("2 - Prezime");
                System.Console.WriteLine("3 - Datum rođenja");
                System.Console.WriteLine("4 - Adresa");
                System.Console.WriteLine("5 - Telefon");
                System.Console.WriteLine("6 - E-mail");
                System.Console.WriteLine("7 - Broj lične karte");
                System.Console.WriteLine("8 - Godine iskustva");
                System.Console.WriteLine("9 - Napisane knjige");
                System.Console.WriteLine(">-------------------------------------------------<");
                System.Console.WriteLine("Unesite broj vašeg izbora: ");
                choice = ConsoleViewUtils.SafeInputInt();
                System.Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        System.Console.Write($"Novo ime (Staro ime - [{autor.Ime}]): ");
                        autor.Ime= ConsoleViewUtils.SafeInputStr();
                        System.Console.WriteLine();
                        break;

                    case 2:
                        System.Console.Write($"Novo prezime (Stari prezime - [{autor.Prezime}]): ");
                        autor.Prezime = ConsoleViewUtils.SafeInputStr();
                        System.Console.WriteLine();
                        break;

                    case 3:
                        System.Console.Write($"Novi datum (Stari datum - [{autor.Datum}]): ");
                        autor.Datum = ConsoleViewUtils.SafeInputDateOnly();
                        System.Console.WriteLine();
                        break;

                    case 4:
                        EditAddress(autor);
                        break;


                    case 5:
                        System.Console.Write($"Novi telefon (Stari telefon - [{autor.Telefon}]): ");
                        autor.Telefon= ConsoleViewUtils.SafeInputStr();
                        System.Console.WriteLine();
                        break;
                    case 6:
                        System.Console.Write($"Novi e-mail (Stari e-mail - [{autor.Email}]): ");
                        autor.Email = ConsoleViewUtils.SafeInputStr();
                        System.Console.WriteLine();
                        break;

                    case 7:
                        System.Console.Write($"Novi br. lične karte (Stari br. lične karte  - [{autor.Licna_karta}]): ");
                        autor.Licna_karta = ConsoleViewUtils.SafeInputStr();
                        System.Console.WriteLine();
                        break;

                    case 8:
                        System.Console.Write($"Nove godine iskustva  (Stare godine iskustva - [{autor.Godine_iskustva}]): ");
                        autor.Godine_iskustva = ConsoleViewUtils.SafeInputInt();
                        System.Console.WriteLine();
                        break;

                    case 9:
                        EditBooks(autor);
                        break;

                    case 0:
                        break;

                    default:
                        System.Console.WriteLine("Greška!!! Unešeni broj nije u opsegu.");
                        break;
                }
            } while (choice != 0);
        }

        private void EditAddress(Autor autor)
        {
            List<Adresa> adrese = _adreseDAO.GetAll();

            if(adrese.Count == 0)
            {
                System.Console.WriteLine("Nema dostupnih adresa. Dodajte adresu kroz glavni meni!");
                return;
            }

            System.Console.WriteLine("Dostupne adrese:");
            foreach (Adresa adresa in adrese)
                System.Console.WriteLine($"[{adresa.Id}] - {adresa.ToString()}");

            int novaAdresa = ConsoleViewUtils.SafeInputInt("ID Adrese [-1 za odustajanje!]: ");

            if (novaAdresa == -1) return;

            if(_adreseDAO.GetById(novaAdresa) == null)
            {
                System.Console.WriteLine("Izabrali ste nepostojeću adresu...");
                return;
            }

            autor.IDAdrese = novaAdresa;
        }

    }
}
