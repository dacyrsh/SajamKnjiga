using Core.DAO;
using Core.Models;
using Core.Utils;

namespace ConsoleClient.Views
{
    internal class AutorView : GenericView<Autor>
    {
        private readonly AutorDAO _autoriDAO = new();
        private readonly KnjigaDAO _knjigeDAO = new();
        //private readonly IzdavacDAO _izdavaciDAO = new();

        public AutorView(AutorDAO autoriDAO, KnjigaDAO knjigeDAO) : base(autoriDAO, "autori.txt")
        {
            _knjigeDAO = knjigeDAO;
        }

        protected override Autor InputObj()
        {
            return new Autor
            {
                Ime = ConsoleViewUtils.SafeInputStr("Ime: "),
                Prezime = ConsoleViewUtils.SafeInputStr("Prezime: "),
                Datum = ConsoleViewUtils.SafeInputDateOnly("Datum: "),
                Email = ConsoleViewUtils.SafeInputStr("Email :"),
                Licna_karta = ConsoleViewUtils.SafeInputStr("Licna karta: "),
                Godine_iskustva = ConsoleViewUtils.SafeInputInt("Godine iskustva: ")
            }; 
        }

        protected override void ObjRemoved(Autor autor)
        {
            
        }

        protected override void PrintObj(Autor autor)
        {
        }

        protected override void ReadUpdatedObj(Autor autor)
        {
        
        }
    }
}
