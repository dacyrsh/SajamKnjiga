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
            throw new NotImplementedException();
        }

        protected override void ObjRemoved(Izdavac izdavac)
        {
            throw new NotImplementedException();
        }
    }
}
