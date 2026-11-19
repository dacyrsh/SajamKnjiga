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
        private readonly IzdavacDAO _izdavaciDAO = new();

        public AutorView(AutorDAO autoriDAO, KnjigaDAO knjigeDAO, AdresaDAO adreseDAO, IzdavacDAO izdavaciDAO) : base(autoriDAO, "Autori")
        {
            _autoriDAO = autoriDAO;
            _knjigeDAO = knjigeDAO;
            _adreseDAO = adreseDAO;
            _izdavaciDAO = izdavaciDAO;
        }

        // Unos novog
        protected override Autor InputObj()
        {
            return new Autor
            {
                Ime = ConsoleViewUtils.SafeInputStr("Ime: "),
                Prezime = ConsoleViewUtils.SafeInputStr("Prezime: "),
                Datum = ConsoleViewUtils.SafeInputDateOnly("Datum (format [yyyy-MM-dd]): "),
                Telefon = ConsoleViewUtils.SafeInputStr("Telefon: "),
                Email = ConsoleViewUtils.SafeInputStr("Email: "),
                Licna_karta = ConsoleViewUtils.SafeInputStr("Licna karta: "),
                Godine_iskustva = ConsoleViewUtils.SafeInputInt("Godine iskustva: ")
            };
        }

        //Brisanje
        protected override void ObjRemoved(Autor autor)
        {
            foreach(Knjiga knjiga in _knjigeDAO.GetAll().Where(knjiga => knjiga.IDAutora.Contains(autor.Id)))
            {
                knjiga.IDAutora.Remove(autor.Id);
                _knjigeDAO.Update(knjiga);
            }
            
            foreach(Izdavac izdavac in _izdavaciDAO.GetAll().Where(izdavac => izdavac.Autori.Contains(autor.Id)))
            {
                izdavac.Autori.Remove(autor.Id);
                _izdavaciDAO.Update(izdavac);
            }
            

        }

        //Ispis
        protected override void PrintObj(Autor autor)
        {
            string adresa = autor.IDAdrese == -1 ? "Nije dodeljena" : _adreseDAO.GetById(autor.IDAdrese)?.ToString() ?? "Nije pronađena";

            System.Console.WriteLine($"[{autor.Id}] {autor.Ime} {autor.Prezime} ({autor.Licna_karta})");
            System.Console.WriteLine($"---> Datum rođenja: {autor.Datum}");
            System.Console.WriteLine($"---> Godine iskustva: {autor.Godine_iskustva}");
            System.Console.WriteLine($"---> Telefon: {autor.Telefon}");
            System.Console.WriteLine($"---> E-mail: {autor.Email}");
            System.Console.WriteLine($"---> Adresa: {adresa}");
            

        }

        //Izmeni
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
                System.Console.WriteLine("0 - Završi izmenu");
                System.Console.WriteLine(">-------------------------------------------------<");
                System.Console.WriteLine("Unesite broj vašeg izbora: ");
                choice = ConsoleViewUtils.SafeInputInt();
                System.Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        System.Console.Write($"Novo ime (Staro ime - [{autor.Ime}]): ");
                        autor.Ime = ConsoleViewUtils.SafeInputStr();
                        System.Console.WriteLine();
                        break;

                    case 2:
                        System.Console.Write($"Novo prezime (Staro prezime - [{autor.Prezime}]): ");
                        autor.Prezime = ConsoleViewUtils.SafeInputStr();
                        System.Console.WriteLine();
                        break;

                    case 3:
                        System.Console.Write($"Novi datum (Stari datum - [{autor.Datum.ToString("yyyy-MM-dd")}]): ");
                        autor.Datum = ConsoleViewUtils.SafeInputDateOnly();
                        System.Console.WriteLine();
                        break;

                    case 4:
                        EditAddress(autor);
                        break;


                    case 5:
                        System.Console.Write($"Novi telefon (Stari telefon - [{autor.Telefon}]): ");
                        autor.Telefon = ConsoleViewUtils.SafeInputStr();
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
                        System.Console.WriteLine("Greška!!! Unešeni broj nije u opsegu.\n");
                        break;
                }
            } while (choice != 0);
        }

        private void EditAddress(Autor autor)
        {
            List<Adresa> adrese = _adreseDAO.GetAll();

            if (adrese.Count == 0)
            {
                System.Console.WriteLine("Nema dostupnih adresa. Dodajte adresu kroz glavni meni!\n");
                return;
            }

            System.Console.WriteLine("Dostupne adrese:");
            foreach (Adresa adresa in adrese)
                System.Console.WriteLine($"[{adresa.Id}] - {adresa.ToString()}");

            int novaAdresa = ConsoleViewUtils.SafeInputInt("ID Adrese [-1 - ukloni adresu]: ");

            if (novaAdresa == -1)
            {
                autor.IDAdrese = -1;
                return;
            }

            if (_adreseDAO.GetById(novaAdresa) == null)
            {
                System.Console.WriteLine("Izabrali ste nepostojeću adresu...");
                return;
            }

            autor.IDAdrese = novaAdresa;
        }

        private void EditBooks(Autor autor)
        {
            int choice;
            do
            {
                System.Console.WriteLine($">---- Izmena knjiga autora {autor.Ime} {autor.Prezime} ----<");
                System.Console.WriteLine("1 - Dodaj knjigu");
                System.Console.WriteLine("2 - Obriši knjigu");
                System.Console.WriteLine("3 - Ispiši autorove knjige");
                System.Console.WriteLine("0 - Nazad");
                System.Console.WriteLine(">---------------------------------------<");

                System.Console.Write("Unesite broj vašeg izbora: ");
                choice = ConsoleViewUtils.SafeInputInt();
                System.Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        AddBook(autor);
                        break;
                    case 2:
                        RemoveBook(autor);
                        break;
                    case 3:
                        System.Console.WriteLine($"Knjige autora {autor.Ime} {autor.Prezime}");
                        PrintBooks(autor.IDNapisanih_knjiga);
                        break;
                    case 0:
                        break;
                    default:
                        System.Console.WriteLine("Greška!!! Unešeni broj nije u opsegu.\n");
                        break;
                }

            } while (choice != 0);

        }

        private void AddBook(Autor autor)
        {
            List<Knjiga> slobodneKnjige = _knjigeDAO.GetAll().Where(knjiga => !knjiga.IDAutora.Contains(autor.Id) && !autor.IDNapisanih_knjiga.Contains(knjiga.Id)).ToList();

            if(slobodneKnjige.Count == 0)
            {
                System.Console.WriteLine("Nema dostupnih knjiga za dodavanje! :c\n");
                return;
            }

            foreach(Knjiga knjiga in slobodneKnjige)
                System.Console.WriteLine($"[{knjiga.Id}] {knjiga.Naziv} ({knjiga.ISBN1})");

            int IDknjige = ConsoleViewUtils.SafeInputInt("Unesite ID knjige koju zelite dodati autoru: ");
            Knjiga izabranaKnjiga = slobodneKnjige.Find(knjiga => knjiga.Id == IDknjige);
            if(izabranaKnjiga == null)
            {
                System.Console.WriteLine("Knjiga sa unešenim ID-jem ne postoji!\n");
                return;
            }

            List<Knjiga> napisaneKnjige = autor.IDNapisanih_knjiga.Select(id => _knjigeDAO.GetById(id)).Where(knjiga => knjiga is not null).Cast<Knjiga>().ToList();
           
            if(napisaneKnjige.Contains(_knjigeDAO.GetById(IDknjige)))
            {
                System.Console.WriteLine("Knjiga sa unešenim ID-jem je već upisana kod autora!\n");
            }

            autor.IDNapisanih_knjiga.Add(izabranaKnjiga.Id);
            _autoriDAO.Update(autor);
            izabranaKnjiga.IDAutora.Add(autor.Id);
            _knjigeDAO.Update(izabranaKnjiga);
        }

        private void RemoveBook(Autor autor)
        {
            if(autor.IDNapisanih_knjiga.Count == 0)
            {
                System.Console.WriteLine("Autor nije napisao ni jednu knjigu! :c\n");
                return;
            }

            System.Console.WriteLine("Knjige koje mozete obrisati: ");
            PrintBooks(autor.IDNapisanih_knjiga);
            int IDknjige = ConsoleViewUtils.SafeInputInt("ID knjige za brisanje: ");
            
            if(!autor.IDNapisanih_knjiga.Contains(IDknjige))
            {
                System.Console.WriteLine("Autor nije napisao tu knjigu!\n");
                return;
            }

            autor.IDNapisanih_knjiga.Remove(IDknjige);
            _autoriDAO.Update(autor);
            Knjiga knjiga = _knjigeDAO.GetById(IDknjige);
            knjiga.IDAutora.Remove(autor.Id);
            _knjigeDAO.Update(knjiga);
        }

        private void PrintBooks(IEnumerable<int> IDNapisanih_knjiga)
        {
            List<Knjiga> knjige = IDNapisanih_knjiga.Select(id => _knjigeDAO.GetById(id)).Where(knjiga => knjiga is not null).Cast<Knjiga>().ToList();
            if(knjige.Count == 0)
            {
                System.Console.WriteLine("Autor nije napisao ni jednu knjigu :c\n");
                return;
            }

            foreach(Knjiga knjiga in knjige)
                System.Console.WriteLine($"[{knjiga.Id}] {knjiga.Naziv} ({knjiga.ISBN1})");

            System.Console.WriteLine();
        }

        //Extra Menu
        protected override string ExtraMenu =>  "Prikaži knjige autora";

        protected override void ShowExtraMenu()
        {
            System.Console.Write("ID autora čije knjige želite videti: ");
            int IDautora = ConsoleViewUtils.SafeInputInt();
            System.Console.WriteLine();
            Autor autor = _autoriDAO.GetById(IDautora);
            if(autor == null)
            {
                System.Console.WriteLine("Autor sa unešenim ID-jem ne postoji!\n");
                return;
            }

            System.Console.WriteLine($"Knjige autora {autor.Ime} {autor.Prezime}: ");
            PrintBooks(autor.IDNapisanih_knjiga);
        }
    }
}
