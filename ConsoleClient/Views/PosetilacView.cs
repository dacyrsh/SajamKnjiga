using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Core.DAO;
using Core.Models;
using Core.Utils;

namespace ConsoleClient.Views
{
    internal class PosetilacView : GenericView<Posetilac>
    {
        private readonly PosetilacDAO _posetiociDAO = new();
        private readonly AdresaDAO _adreseDAO = new();

        private readonly KupovinaDAO _kupovineDAO = new();
        private readonly KnjigaDAO _knjigeDAO = new();


        public PosetilacView(PosetilacDAO posetiociDAO, AdresaDAO adreseDAO, KupovinaDAO kupovineDAO, KnjigaDAO knjigeDAO) : base(posetiociDAO, "Posetioci")
        {
            _posetiociDAO = posetiociDAO;
            _adreseDAO = adreseDAO;
            _kupovineDAO = kupovineDAO;
            _knjigeDAO = knjigeDAO;
        }
        // unos
        protected override Posetilac InputObj()
        {
            return new Posetilac
            {
                Ime = ConsoleViewUtils.SafeInputStr("Ime: "),
                Prezime = ConsoleViewUtils.SafeInputStr("Prezime: "),
                DatumRodjenja = ConsoleViewUtils.SafeInputDateOnly("Datum rodjenja [yyyy-MM-dd]: "),
                Telefon = ConsoleViewUtils.SafeInputStr("Telefon: "),
                Email = ConsoleViewUtils.SafeInputStr("E-mail: "),
                Clanska_karta = ConsoleViewUtils.SafeInputStr("Broj clanske karte: "),
                Godina_clanstva = ConsoleViewUtils.SafeInputInt("Godina clanstva: "),
                Status = TipStatusa.Regular,
                Ocena_recenzija = 0
            };
        }
        // prikaz posetioca
        protected override void PrintObj(Posetilac posetilac)
        {
            string adresa =
                posetilac.IDAdrese == -1
                ? "Nije dodeljena"
                : _adreseDAO.GetById(posetilac.IDAdrese)?.ToString()
                    ?? "Nije pronadjena";

            System.Console.WriteLine(
                $"[{posetilac.Id}] {posetilac.Ime} {posetilac.Prezime} ({posetilac.Clanska_karta})");

            System.Console.WriteLine($"--> Datum rodjenja: {CsvConversion.FromDate(posetilac.DatumRodjenja)}");
            System.Console.WriteLine($"--> Telefon: {posetilac.Telefon}");
            System.Console.WriteLine($"--> E-mail: {posetilac.Email}");
            System.Console.WriteLine($"--> Status: {posetilac.Status}");
            System.Console.WriteLine($"--> Godina clanstva: {posetilac.Godina_clanstva}");
            System.Console.WriteLine($"--> Prosecna ocena: {posetilac.Ocena_recenzija}");
            System.Console.WriteLine($"--> Adresa: {adresa}");
            System.Console.WriteLine();
        }
        // izmena posetilaca
        protected override void ReadUpdatedObj(Posetilac posetilac)
        {
            int choice;

            do
            {
                System.Console.WriteLine($">---- Izmena posetioca: {posetilac.Ime} {posetilac.Prezime} ----<");
                System.Console.WriteLine("1 - Ime");
                System.Console.WriteLine("2 - Prezime");
                System.Console.WriteLine("3 - Datum rodjenja");
                System.Console.WriteLine("4 - Telefon");
                System.Console.WriteLine("5 - E-mail");
                System.Console.WriteLine("6 - Broj clanske karte");
                System.Console.WriteLine("7 - Godina clanstva");
                System.Console.WriteLine("8 - Status");
                System.Console.WriteLine("0 - Zavrsi izmenu");
                System.Console.WriteLine(">---------------------------------------------<");
                System.Console.Write("Unesite broj vaseg izbora: ");
                choice = ConsoleViewUtils.SafeInputInt();
                System.Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        System.Console.Write($"Novo ime (Staro ime - [{posetilac.Ime}]): ");
                        posetilac.Ime = ConsoleViewUtils.SafeInputStr();
                        System.Console.WriteLine();
                        break;

                    case 2:
                        System.Console.Write($"Novo prezime (Staro prezime - [{posetilac.Prezime}]): ");
                        posetilac.Prezime = ConsoleViewUtils.SafeInputStr();
                        System.Console.WriteLine();
                        break;

                    case 3:
                        System.Console.Write($"Novi datum (Stari datum - [{CsvConversion.FromDate(posetilac.DatumRodjenja)}]): ");
                        posetilac.DatumRodjenja = ConsoleViewUtils.SafeInputDateOnly();
                        System.Console.WriteLine();
                        break;

                    case 4:
                        System.Console.Write($"Novi telefon (Stari telefon - [{posetilac.Telefon}]): ");
                        posetilac.Telefon = ConsoleViewUtils.SafeInputStr();
                        System.Console.WriteLine();
                        break;

                    case 5:
                        System.Console.Write($"Novi e-mail (Stari e-mail - [{posetilac.Email}]): ");
                        posetilac.Email = ConsoleViewUtils.SafeInputStr();
                        System.Console.WriteLine();
                        break;

                    case 6:
                        System.Console.Write($"Nova clanska karta (Stara clanska karta - [{posetilac.Clanska_karta}]): ");
                        posetilac.Clanska_karta = ConsoleViewUtils.SafeInputStr();
                        System.Console.WriteLine();
                        break;

                    case 7:
                        System.Console.Write($"Nova godina clanstva (Stara godina clanstva - [{posetilac.Godina_clanstva}]): ");
                        posetilac.Godina_clanstva = ConsoleViewUtils.SafeInputInt();
                        System.Console.WriteLine();
                        break;

                    case 8:
                        System.Console.WriteLine($"Trenutni status: {posetilac.Status}");
                        System.Console.WriteLine("1 - Regular");
                        System.Console.WriteLine("2 - VIP");
                        int status = ConsoleViewUtils.SafeInputInt("Izaberite novi status: ");
                        if (status == 1)
                            posetilac.Status = TipStatusa.Regular;
                        else if (status == 2)
                            posetilac.Status = TipStatusa.Vip;
                        System.Console.WriteLine();
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
        // brisanje posetilaca
        protected override void ObjRemoved(Posetilac posetilac)
        {
            foreach (Knjiga knjiga in _knjigeDAO.GetAll()
        .Where(knjiga => knjiga.IDKupaca.Contains(posetilac.Id)))
            {
                knjiga.IDKupaca.Remove(posetilac.Id);
                _knjigeDAO.Update(knjiga);
            }

            foreach (Knjiga knjiga in _knjigeDAO.GetAll()
                .Where(knjiga => knjiga.IDZelja.Contains(posetilac.Id)))
            {
                knjiga.IDZelja.Remove(posetilac.Id);
                _knjigeDAO.Update(knjiga);
            }

            foreach (Kupovina kupovina in _kupovineDAO.GetAll()
                .Where(kupovina => kupovina.IDposetioca == posetilac.Id))
            {
                _kupovineDAO.Remove(kupovina.Id);
            }
        }
        // Extra menu
        protected override string ExtraMenu => "Upravljanje listom zelja";
        protected override void ShowExtraMenu()
        {
            int IDposetioca = ConsoleViewUtils.SafeInputInt("ID posetioca: ");

            Posetilac posetilac = _posetiociDAO.GetById(IDposetioca);

            if (posetilac == null)
            {
                System.Console.WriteLine("Posetilac ne postoji!\n");
                return;
            }

            EditWishList(posetilac);
        }
        private void EditWishList(Posetilac posetilac)
        {
            int choice;
            do
            {
                System.Console.WriteLine($">---- Lista zelja: {posetilac.Ime} {posetilac.Prezime} ----<");
                System.Console.WriteLine("1 - Dodaj knjigu");
                System.Console.WriteLine("2 - Ukloni knjigu");
                System.Console.WriteLine("3 - Prikazi listu zelja");
                System.Console.WriteLine("0 - Nazad");
                choice = ConsoleViewUtils.SafeInputInt();

                switch (choice)
                {
                    case 1:
                        AddBookToWishList(posetilac);
                        break;

                    case 2:
                        RemoveBookFromWishList(posetilac);
                        break;

                    case 3:
                        PrintWishList(posetilac);
                        break;

                    case 0:
                        break;
                }
            } while (choice != 0);
        }
        private void AddBookToWishList(Posetilac posetilac)
        {

        }
        private void RemoveBookFromWishList(Posetilac posetilac)
        { 

        }
        private void PrintWishList(Posetilac posetilac)
        {

        }

    }
}
