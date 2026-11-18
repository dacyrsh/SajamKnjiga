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
            throw new NotImplementedException();
        }

        protected override void PrintObj(Izdavac izdavac)
        {
            throw new NotImplementedException();
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
