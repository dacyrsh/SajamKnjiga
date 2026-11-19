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
        protected override Kupovina InputObj()
        {
            throw new NotImplementedException();
        }

        protected override void PrintObj(Kupovina kupovina)
        {
            throw new NotImplementedException();
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
