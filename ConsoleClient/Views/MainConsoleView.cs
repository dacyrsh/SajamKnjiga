using System;
using System.Collections.Generic;
using System.Text;
using Core.DAO;
using Core.Utils;

namespace ConsoleClient.Views
{
    internal class MainConsoleView
    {
        private readonly AdresaDAO _adreseDAO = new();
        private readonly AutorDAO _autorDAO = new();
        private readonly KnjigaDAO _knjigaDAO = new();

        private readonly AdresaView _adresaView;

        public MainConsoleView()
        {
            _adresaView = new AdresaView(_adreseDAO, _autorDAO);
        }

        public void Run()
        {
            int choice;
            do
            {
                // meni
                System.Console.WriteLine(">------- Sajam Knjiga -------<");
                System.Console.WriteLine("1 - Posetioci");
                System.Console.WriteLine("2 - Autori");
                System.Console.WriteLine("3 - Knjige");
                System.Console.WriteLine("4 - Kupovine");
                System.Console.WriteLine("5 - Izdavači");
                System.Console.WriteLine("6 - Adrese");
                System.Console.WriteLine("0 - Izlaz iz aplikacije");
                System.Console.WriteLine(">----------------------------<");

                System.Console.Write("Unesite broj vašeg izbora: ");
                choice = ConsoleViewUtils.SafeInputInt();
                System.Console.WriteLine();

                switch (choice)
                {

                    case 1:

                        break;
                    case 2:

                        break;
                    case 3:

                        break;
                    case 4:

                        break;
                    case 5:

                        break;
                    case 6:
                        _adresaView.Run();
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
