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
        private readonly IzdavacDAO _izdavaciDAO = new();
        private readonly PosetilacDAO _posetociDAO = new();   
        private readonly KupovinaDAO _kupovineDAO = new();

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
            foreach(Autor autor in _autoriDAO.GetAll().Where(autor => autor.IDNapisanih_knjiga.Contains(knjiga.Id)))
            {
                autor.IDNapisanih_knjiga.Remove(knjiga.Id);
                _autoriDAO.Update(autor);
            }

            if(knjiga.IDIzdavaca > -1)
            {
                Izdavac izdavac = _izdavaciDAO.GetById(knjiga.IDIzdavaca);
                if(izdavac != null)
                {
                    izdavac.Knjige.Remove(knjiga.Id);

                    RefreshPublisherAuthors(izdavac);

                }
            }

            foreach(Posetilac posetilac in _posetociDAO.GetAll().Where(posetilac => posetilac.Lista_zelja.Contains(knjiga.Id)))
            {
                posetilac.Lista_zelja.Remove(knjiga.Id);
                _posetociDAO.Update(posetilac);
            }

            foreach(Kupovina kupovina in _kupovineDAO.GetAll().Where(kupovina => kupovina.IDknjige == knjiga.Id))
            {
                _kupovineDAO.Remove(kupovina.Id);

                // osvezi rating jer se obrisala kupovina
                Posetilac posetilac = _posetociDAO.GetById(kupovina.IDposetioca);
                if(posetilac is not null)
                {
                    posetilac.Kupljene_knjige.Remove(kupovina.Id);

                    List<int> prosecna_ocena = posetilac.Kupljene_knjige.Select(id => _kupovineDAO.GetById(id)).Where(kupovina => kupovina is not null).Select(kupovina => kupovina.Ocena).ToList();
                    posetilac.Ocena_recenzija = prosecna_ocena.Count == 0 ? 0 : prosecna_ocena.Average();
                    _posetociDAO.Update(posetilac);
                }
            }

        }

        protected override void PrintObj(Knjiga knjiga)
        {
            List<string> autori = knjiga.IDAutora.Select(id => _autoriDAO.GetById(id)).Where(autor => autor is not null).Select(autor => $"{autor.Ime} {autor.Prezime}").ToList();
            string autori_str = autori.Count == 0 ? "Nisu dodeljeni" : string.Join(", ", autori);
            Izdavac izdavac = _izdavaciDAO.GetById(knjiga.IDIzdavaca);
            string izdavac_str = izdavac == null ? "Nije dodeljen" : izdavac.Naziv;

            System.Console.WriteLine($"[{knjiga.Id}] {knjiga.Naziv} ({knjiga.ISBN1})");
            System.Console.WriteLine($"--->Žanr: {knjiga.Zanr}");
            System.Console.WriteLine($"--->Godina izdanja: {knjiga.Godina_izdanja}");
            System.Console.WriteLine($"--->Broj strana: {knjiga.Br_strana}");
            System.Console.WriteLine($"--->Cena: {Math.Round(knjiga.Cena,2)}");
            System.Console.WriteLine($"--->Autor/i: {autori_str}");
            System.Console.WriteLine($"--->Izdavac: {izdavac_str}");
            System.Console.WriteLine();
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
                        EditPublisher(knjiga);
                        break;

                    case 0:
                        break;

                    default:
                        System.Console.WriteLine("Greška!!! Unešeni broj nije u opsegu.\n");
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
            List<Autor> slobodniAutori = _autoriDAO.GetAll().Where(autor => !knjiga.IDAutora.Contains(autor.Id)).ToList();

            if (slobodniAutori.Count == 0)
            {
                System.Console.WriteLine("Nema dostupnih autora za dodavanje! :c\n");
                return;
            }

            foreach (Autor autor in slobodniAutori)
                System.Console.WriteLine($"[{autor.Id}] {autor.Ime} {autor.Prezime}");

            Console.WriteLine();
            int IDautora = ConsoleViewUtils.SafeInputInt("Unesite ID autora kojeg zelite dodati knjizi: ");
            Autor izabraniAutor = slobodniAutori.Find(autor => autor.Id == IDautora);
            if (izabraniAutor == null)
            {
                System.Console.WriteLine("Autor sa unešenim ID-jem ne postoji ili je vec povezan sa knjigom!\n");
                return;
            }

            List<Autor> zauzetiAutori = knjiga.IDAutora.Select(id => _autoriDAO.GetById(id)).Where(autor => autor is not null).Cast<Autor>().ToList();

            if (zauzetiAutori.Contains(_autoriDAO.GetById(IDautora)))
            {
                System.Console.WriteLine("Autor sa unešenim ID-jem je već upisan kod knjige!\n");
            }

            izabraniAutor.IDNapisanih_knjiga.Add(knjiga.Id);
            _autoriDAO.Update(izabraniAutor);

            knjiga.IDAutora.Add(izabraniAutor.Id);
            _knjigeDAO.Update(knjiga);
           

        }

        private void RemoveAuthor(Knjiga knjiga)
        {
            if (knjiga.IDAutora.Count == 0)
            {
                System.Console.WriteLine("Knjiga trenutno nema ni jednog autora! :c\n");
                return;
            }

            System.Console.WriteLine("Autore koje mozete obrisati: ");
            PrintAuthors(knjiga.IDAutora);
            int IDautora = ConsoleViewUtils.SafeInputInt("ID autora za brisanje: ");

            if (!knjiga.IDAutora.Contains(IDautora))
            {
                System.Console.WriteLine("Knjiga nije napisana od tog autora!\n");
                return;
            }

            Autor autor = _autoriDAO.GetById(IDautora);
            autor.IDNapisanih_knjiga.Remove(knjiga.Id);
            _autoriDAO.Update(autor);
            knjiga.IDAutora.Remove(IDautora);
            _knjigeDAO.Update(knjiga);
        }

        private void PrintAuthors(IEnumerable<int> IDAutora)
        {
            List<Autor> autori = IDAutora.Select(id => _autoriDAO.GetById(id)).Where(autor => autor is not null).Cast<Autor>().ToList();
            if (autori.Count == 0)
            {
                System.Console.WriteLine("Knjiga trenutno nema ni jednog autora! :c\n");
                return;
            }

            foreach (Autor autor in autori)
                System.Console.WriteLine($"[{autor.Id}] {autor.Ime} {autor.Prezime}");

            System.Console.WriteLine();
        }

        private void EditPublisher(Knjiga knjiga)
        {
            List<Izdavac> izdavaci = _izdavaciDAO.GetAll();

            if(izdavaci.Count == 0)
            {
                System.Console.WriteLine("Trenutno nema izdavaca u sistemu!\n");
                return;
            }

            System.Console.WriteLine("Dostupni izdavaci: ");
            foreach (Izdavac izdavac in izdavaci)
                System.Console.WriteLine($"[{izdavac.Id}] {izdavac.Naziv}");

            System.Console.WriteLine();

            int stariIzdavacID = knjiga.IDIzdavaca;
            int noviIzdavacID = ConsoleViewUtils.SafeInputInt($"ID novog izdavaca: ");

            if(_izdavaciDAO.GetById(noviIzdavacID) == null)
            {
                System.Console.WriteLine("Izdavac sa datim ID-jem ne postoji!\n");
                return;
            }

            if (stariIzdavacID == noviIzdavacID)
                return;

            if(stariIzdavacID != -1)
            {
                Izdavac stariIzdavac = _izdavaciDAO.GetById(stariIzdavacID);
                if(stariIzdavac != null)
                {
                    stariIzdavac.Knjige.Remove(knjiga.Id);
                    RefreshPublisherAuthors(stariIzdavac);
                }
            }

            knjiga.IDIzdavaca = noviIzdavacID;
            if(noviIzdavacID != -1)
            {
                Izdavac noviIzdavac = _izdavaciDAO.GetById(noviIzdavacID);
                if(!noviIzdavac.Knjige.Contains(knjiga.Id))
                    noviIzdavac.Knjige.Add(knjiga.Id);
                RefreshPublisherAuthors(noviIzdavac);
            }

        }

        private void RefreshPublisherAuthors(Izdavac izdavac)
        {
            izdavac.Autori = izdavac.Knjige.Select(id => _knjigeDAO.GetById(id)).Where(knjiga => knjiga is not null).SelectMany(knjiga => knjiga.IDAutora).Distinct().ToList();

            // moramo proveriti jel bio sef
            if (izdavac.IDsefa != -1 && !izdavac.Autori.Contains(izdavac.IDsefa))
            {
                izdavac.IDsefa = -1;
            }

            _izdavaciDAO.Update(izdavac);
        }

    }
}
