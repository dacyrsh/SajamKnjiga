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
            throw new NotImplementedException();
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
