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
            System.Console.WriteLine($"--> Datum kupovine: {kupovina.Datum_kupovine}");
            System.Console.WriteLine($"--> Ocena: {kupovina.Ocena}");
            System.Console.WriteLine($"--> Komentar: {kupovina.Komentar}");
            System.Console.WriteLine();
        }

        protected override void ReadUpdatedObj(Kupovina kupovina)
        {
            throw new NotImplementedException();
        }

        protected override void ObjRemoved(Kupovina kupovina)
        {
            throw new NotImplementedException();
        }
    }
}
