using Core.DAO;
using Core.Models;
using Core.Utils;

namespace ConsoleClient.Views
{
    internal class AdresaView : GenericView<Adresa>
    {
        private readonly AutorDAO _autoriDAO;

        public AdresaView(AdresaDAO adreseDAO, AutorDAO autoriDAO) : base(adreseDAO, "Adrese")
        {
            _autoriDAO = autoriDAO;
        }

        protected override Adresa InputObj()
        {
            return new Adresa
            {
                Ulica = ConsoleViewUtils.SafeInputStr(),
                Broj = ConsoleViewUtils.SafeInputStr(),
                Grad = ConsoleViewUtils.SafeInputStr(),
                Drzava = ConsoleViewUtils.SafeInputStr(),
            };
        }

        protected override void ObjRemoved(Adresa obj)
        {
            throw new NotImplementedException();
        }

        protected override void PrintObj(Adresa obj)
        {
            throw new NotImplementedException();
        }

        protected override void ReadUpdatedObj(Adresa obj)
        {
            throw new NotImplementedException();
        }
    }
}
