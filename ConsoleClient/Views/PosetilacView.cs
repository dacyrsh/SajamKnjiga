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
        protected override void PrintObj(Posetilac posetilac)
        {
            throw new NotImplementedException();
        }

        protected override void ReadUpdatedObj(Posetilac posetilac)
        {
            throw new NotImplementedException();
        }
        protected override void ObjRemoved(Posetilac posetilac)
        {
            throw new NotImplementedException();
        }
    }
}
