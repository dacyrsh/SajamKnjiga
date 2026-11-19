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
        private readonly AutorDAO _autoriDAO = new();
        private readonly KnjigaDAO _knjigeDAO = new();

        private readonly IzdavacDAO _izdavaciDAO = new();
        private readonly PosetilacDAO _posetiociDAO = new();
        private readonly KupovinaDAO _kupovineDAO = new();

        private readonly AdresaView _adreseView;
        private readonly AutorView _autoriView;
        private readonly KnjigaView _knjigeView;

        private readonly IzdavacView _izdavaciView;
        private readonly PosetilacView _posetiociView;
        private readonly KupovinaView _kupovineView;

        public MainConsoleView()
        {
            _adreseView = new AdresaView(_adreseDAO, _autoriDAO);
            _autoriView = new AutorView(_autoriDAO, _knjigeDAO, _adreseDAO, _izdavaciDAO);
            _knjigeView = new KnjigaView(_knjigeDAO, _autoriDAO);

            _izdavaciView = new IzdavacView(_izdavaciDAO, _knjigeDAO);
            _posetiociView = new PosetilacView(_posetiociDAO, _adreseDAO, _kupovineDAO, _knjigeDAO);
            _kupovineView = new KupovinaView(_kupovineDAO, _posetiociDAO, _knjigeDAO);
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
                        _posetiociView.Run();
                        break;
                    case 2:
                        _autoriView.Run();
                        break;
                    case 3:
                        _knjigeView.Run();
                        break;
                    case 4:
                        _kupovineView.Run();
                        break;
                    case 5:
                        _izdavaciView.Run();
                        break;
                    case 6:
                        _adreseView.Run();
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
