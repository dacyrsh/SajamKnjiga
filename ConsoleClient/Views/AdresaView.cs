using Core.DAO;
using Core.Models;
using Core.Utils;

namespace ConsoleClient.Views
{
    internal class AdresaView : GenericView<Adresa>
    {
        private readonly AutorDAO _autoriDAO;
        //private readonly PosetilacDAO _posetiociDAO; (dodati svuda)

        public AdresaView(AdresaDAO adreseDAO, AutorDAO autoriDAO) : base(adreseDAO, "Adrese")
        {
            _autoriDAO = autoriDAO;
        }

        protected override Adresa InputObj()
        {
            return new Adresa
            {
                Ulica = ConsoleViewUtils.SafeInputStr("Naziv ulice: "),
                Broj = ConsoleViewUtils.SafeInputStr("Broj ulice: "),
                Grad = ConsoleViewUtils.SafeInputStr("Grad: "),
                Drzava = ConsoleViewUtils.SafeInputStr("Država: "),
            };
        }

        protected override void ObjRemoved(Adresa adresa)
        {
            foreach(Autor autor in _autoriDAO.GetAll().Where(autor => autor.IDAdrese == adresa.Id))
            {
                autor.IDAdrese = -1;
                _autoriDAO.Update(autor);
            }
            /*
             foreach(Posetilac posetilac in _posetiociDAO.GetAll().Where(posetilac => posetilac.IDAdrese == adresa.Id))
            {
                posetilac.IDAdrese = -1;
                _posetioci.Update(posetilac);
            }
             */
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
                System.Console.WriteLine($">---- Izmena adrese: {adresa.Ulica} {adresa.Broj} {adresa.Grad} {adresa.Drzava} ----<");
                System.Console.WriteLine("1 - Ulica");
                System.Console.WriteLine("2 - Broj");
                System.Console.WriteLine("3 - Grad");
                System.Console.WriteLine("4 - Država");
                System.Console.WriteLine("0 - Završi izmenu");
                System.Console.WriteLine(">-------------------------------------------------<");
                System.Console.WriteLine("Unesite broj vašeg izbora: ");
                choice = ConsoleViewUtils.SafeInputInt();
                System.Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        System.Console.Write($"Nova ulica (Stara ulica - [{adresa.Ulica}]): ");
                        adresa.Ulica = ConsoleViewUtils.SafeInputStr();
                        System.Console.WriteLine();
                        break;

                    case 2:
                        System.Console.Write($"Novi broj (Stari broj - [{adresa.Broj}]): ");
                        adresa.Broj = ConsoleViewUtils.SafeInputStr();
                        System.Console.WriteLine();
                        break;

                    case 3:
                        System.Console.Write($"Nova grad (Stara grad - [{adresa.Grad}]): ");
                        adresa.Grad = ConsoleViewUtils.SafeInputStr();
                        System.Console.WriteLine();
                        break;

                    case 4:
                        System.Console.Write($"Nova država (Stara država - [{adresa.Drzava}]): ");
                        adresa.Drzava = ConsoleViewUtils.SafeInputStr();
                        System.Console.WriteLine();
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
