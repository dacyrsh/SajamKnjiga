using Core.DAO;
using Core.Models;
using Core.Utils;
using System.Net;

namespace ConsoleClient.Views
{
    internal class KnjigaView : GenericView<Knjiga>
    {
        private readonly AutorDAO _autoriDAO= new();
        private readonly KnjigaDAO _knjigeDAO = new();

        //private readonly IzdavacDAO _izdavaciDAO = new();

        public KnjigaView(KnjigaDAO knjigeDAO, AutorDAO autoriDAO) : base(knjigeDAO, "Knjige")
        {
            _knjigeDAO = knjigeDAO;
            _autoriDAO = autoriDAO;
        }


        protected override Knjiga InputObj()
        {
            return new Knjiga
            {
                ISBN1 = ConsoleViewUtils.SafeInputStr("ISBN: "),
                Naziv = ConsoleViewUtils.SafeInputStr("Naziv: "),
                Zanr = ConsoleViewUtils.SafeInputStr("Žanr: "),
                Godina_izdanja = ConsoleViewUtils.SafeInputInt("Godina izdanja: "),
                Cena = ConsoleViewUtils.SafeInputDouble("Cena: "),
                Br_strana = ConsoleViewUtils.SafeInputInt("Broj strana: ")
            };
        }

        protected override void ObjRemoved(Knjiga knjiga)
        {

        }

        protected override void PrintObj(Knjiga knjiga)
        {
            List<string> autori = knjiga.IDAutora.Select(id => _autoriDAO.GetById(id)).Where(autor => autor is not null).Select(autor => $"{autor.Ime} {autor.Prezime}").ToList();
            string autori_str = autori.Count == 0 ? "Nisu dodeljeni" : string.Join(", ", autori);

            System.Console.WriteLine($"[{knjiga.Id}] {knjiga.Naziv} ({knjiga.ISBN1})");
            System.Console.WriteLine($"--->Žanr: {knjiga.Zanr}");
            System.Console.WriteLine($"--->Godina izdanja: {knjiga.Godina_izdanja}");
            System.Console.WriteLine($"--->Broj strana: {knjiga.Br_strana}");
            System.Console.WriteLine($"--->Cena: {Math.Round(knjiga.Cena,2)}");
            System.Console.WriteLine($"--->Autor/i: {autori_str}");
        }

        protected override void ReadUpdatedObj(Knjiga knjiga)
        {
            int choice;
            do
            {
                System.Console.WriteLine($">---- Izmena Knjige: {knjiga.Naziv} [{knjiga.ISBN1}] ----<");
                System.Console.WriteLine("1 - ISBN");
                System.Console.WriteLine("2 - Naziv");
                System.Console.WriteLine("3 - Žanr");
                System.Console.WriteLine("4 - Godina izdanja");
                System.Console.WriteLine("5 - Cena");
                System.Console.WriteLine("6 - Broj strana");
                System.Console.WriteLine("7 - Autori");
                System.Console.WriteLine("8 - Izdavač");
                System.Console.WriteLine("0 - Završi izmenu");
                System.Console.WriteLine(">-------------------------------------------------<");
                System.Console.WriteLine("Unesite broj vašeg izbora: ");
                choice = ConsoleViewUtils.SafeInputInt();
                System.Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        System.Console.Write($"Novi ISBN (Stari ISBN - [{knjiga.ISBN1}]): ");
                        knjiga.ISBN1 = ConsoleViewUtils.SafeInputStr();
                        System.Console.WriteLine();
                        break;

                    case 2:
                        System.Console.Write($"Novi naziv (Stari naziv - [{knjiga.Naziv}]): ");
                        knjiga.Naziv = ConsoleViewUtils.SafeInputStr();
                        System.Console.WriteLine();
                        break;

                    case 3:
                        System.Console.Write($"Novi žanr (Stari žanr - [{knjiga.Zanr}]): ");
                        knjiga.Zanr = ConsoleViewUtils.SafeInputStr();
                        System.Console.WriteLine();
                        break;

                    case 4:
                        System.Console.Write($"Nova godina izdanja (Stara godina izdanja - [{knjiga.Godina_izdanja}]): ");
                        knjiga.Godina_izdanja = ConsoleViewUtils.SafeInputInt();
                        System.Console.WriteLine();
                        break;


                    case 5:
                        System.Console.Write($"Nova cena (Stara cena - [{knjiga.Cena}]): ");
                        knjiga.Cena = ConsoleViewUtils.SafeInputDouble();
                        System.Console.WriteLine();
                        break;
                    case 6:
                        System.Console.Write($"Novi broj strana (Stari broj strana - [{knjiga.Br_strana}]): ");
                        knjiga.Br_strana = ConsoleViewUtils.SafeInputInt();
                        System.Console.WriteLine();
                        break;

                    case 7:
                        EditAuthors(knjiga);
                        break;

                    case 8:
                        break;

                    case 0:
                        break;

                    default:
                        System.Console.WriteLine("Greška!!! Unešeni broj nije u opsegu.");
                        break;
                }
            } while (choice != 0);
        }

        private void EditAuthors(Knjiga knjiga)
        {
            int choice;
            do
            {
                System.Console.WriteLine($">---- Izmena autora knjige {knjiga.Naziv} ({knjiga.ISBN1}) ----<");
                System.Console.WriteLine("1 - Dodaj autora");
                System.Console.WriteLine("2 - Obriši autora");
                System.Console.WriteLine("3 - Ispiši autore");
                System.Console.WriteLine("0 - Nazad");
                System.Console.WriteLine(">---------------------------------------<");

                System.Console.Write("Unesite broj vašeg izbora: ");
                choice = ConsoleViewUtils.SafeInputInt();
                System.Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        AddAuthor(knjiga);
                        break;
                    case 2:
                        RemoveAuthor(knjiga);
                        break;
                    case 3:
                        System.Console.WriteLine($"Autori knjige {knjiga.Naziv} ({knjiga.ISBN1})");
                        PrintAuthors(knjiga.IDAutora);
                        break;
                    case 0:
                        break;
                    default:
                        System.Console.WriteLine("Greška!!! Unešeni broj nije u opsegu.\n");
                        break;
                }

            } while (choice != 0);
        }

        private void AddAuthor(Knjiga knjiga)
        {
            
        }

        private void RemoveAuthor(Knjiga knjiga)
        {

        }

        private void PrintAuthors(IEnumerable<int> IDAutora)
        {
            List<Autor> autori = IDAutora.Select(id => _autoriDAO.GetById(id)).Where(autor => autor is not null).Cast<Autor>().ToList();
            if (autori.Count == 0)
            {
                System.Console.WriteLine("Knjiga nema ni jednog autora trenutno! :c\n");
                return;
            }

            foreach (Autor autor in autori)
                System.Console.WriteLine($"[{autor.Id}] {autor.Ime} {autor.Prezime}");

            System.Console.WriteLine();
        }

        
    }
}
