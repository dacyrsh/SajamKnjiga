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

        public PosetilacView(PosetilacDAO posetiociDAO, AdresaDAO adreseDAO) : base(posetiociDAO, "Posetioci")
        {
            _posetiociDAO = posetiociDAO;
            _adreseDAO = adreseDAO;
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

            System.Console.WriteLine($"--> Datum rodjenja: {posetilac.DatumRodjenja}");
            System.Console.WriteLine($"--> Telefon: {posetilac.Telefon}");
            System.Console.WriteLine($"--> E-mail: {posetilac.Email}");
            System.Console.WriteLine($"--> Status: {posetilac.Status}");
            System.Console.WriteLine($"--> Godina clanstva: {posetilac.Godina_clanstva}");
            System.Console.WriteLine($"--> Prosecna ocena: {posetilac.Ocena_recenzija}");
            System.Console.WriteLine($"--> Adresa: {adresa}");
        }
        // izmena posetilaca
        protected override void ReadUpdatedObj(Posetilac posetilac)
        {
            throw new NotImplementedException();
        }
        // brisanje posetilaca
        protected override void ObjRemoved(Posetilac posetilac)
        {
            throw new NotImplementedException();
        }
    }
}
