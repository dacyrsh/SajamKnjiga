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

        protected override void ObjRemoved(Adresa adresa)
        {
            foreach(Autor autor in _autoriDAO.GetAll().Where(autor => autor.IDAdrese == adresa.Id))
            {
                autor.IDAdrese = 0;
                _autoriDAO.Update(autor);
            }
        }

        protected override void PrintObj(Adresa adresa)
        {
            System.Console.WriteLine($"[{adresa.Id}] {adresa.Ulica} {adresa.Broj} {adresa.Grad} {adresa.Drzava}");
        }

        protected override void ReadUpdatedObj(Adresa adresa)
        {
            int choice;
            do
            {
                System.Console.WriteLine($"\n>---- Izmena adrese: {adresa} ----<");
                System.Console.WriteLine("1 - Ulica");
                System.Console.WriteLine("2 - Broj");
                System.Console.WriteLine("3 - Grad");
                System.Console.WriteLine("4 - Drzava");
                System.Console.WriteLine("0 - Završi izmenu");
                System.Console.WriteLine("Unesite broj vašeg izbora: ");
                choice = ConsoleViewUtils.SafeInputInt();

                switch (choice)
                {
                    case 1:
                        System.Console.WriteLine($"Nova ulica (Stara ulica - [{adresa.Ulica}]: ");
                        adresa.Ulica = ConsoleViewUtils.SafeInputStr();
                        break;

                    case 2:
                        System.Console.WriteLine($"Novi broj (Stari broj - [{adresa.Broj}]: ");
                        adresa.Broj = ConsoleViewUtils.SafeInputStr();
                        break;

                    case 3:
                        System.Console.WriteLine($"Nova grad (Stara grad - [{adresa.Grad}]: ");
                        adresa.Grad = ConsoleViewUtils.SafeInputStr();
                        break;

                    case 4:
                        System.Console.WriteLine($"Nova drzava (Stara drzava - [{adresa.Drzava}]: ");
                        adresa.Drzava = ConsoleViewUtils.SafeInputStr();
                        break;

                    case 0:
                        break;

                    default:
                        System.Console.WriteLine("Greška!!! Unešeni broj nije u opsegu.");
                        break;
                }
            } while (choice != 0);
        }
    }
}
