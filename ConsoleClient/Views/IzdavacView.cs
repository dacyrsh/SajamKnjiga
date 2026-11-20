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
        private readonly KnjigaDAO _knjigeDAO = new();
        private readonly AutorDAO _autoriDAO = new();
        public IzdavacView(IzdavacDAO izdavacDAO, KnjigaDAO knjigeDAO, AutorDAO autoriDAO) : base(izdavacDAO, "Izdavaci")
        {
            _izdavacDAO = izdavacDAO;
            _knjigeDAO = knjigeDAO;
            _autoriDAO = autoriDAO;
        }
        // unos izdavaca
        protected override Izdavac InputObj()
        {
            int idSefa;
            Autor sef;
            do
            {
                idSefa = ConsoleViewUtils.SafeInputInt("ID sefa: ");
                sef = _autoriDAO.GetById(idSefa);
                if (sef == null)
                {
                    Console.WriteLine("Autor ne postoji!");
                    Console.WriteLine();
                }
                else if (sef.Godine_iskustva < 5)
                {
                    Console.WriteLine("Autor mora imati najmanje 5 godina iskustva!");
                    Console.WriteLine();
                    sef = null;
                }
            } while (sef == null);
            return new Izdavac 
            { 
                Sifra = ConsoleViewUtils.SafeInputStr("Sifra: "),
                Naziv = ConsoleViewUtils.SafeInputStr("Naziv: "),
                IDsefa = idSefa
            };
        }
        // ispis izdavaca
        protected override void PrintObj(Izdavac izdavac)
        {
            System.Console.WriteLine($"[{izdavac.Id}] {izdavac.Naziv} ({izdavac.Sifra})");
            System.Console.WriteLine($"---> ID sefa: {izdavac.IDsefa}");
            Console.WriteLine();

        }
        // izmene izdavaca
        protected override void ReadUpdatedObj(Izdavac izdavac)
        {
            int choice;
            do
            {
                System.Console.WriteLine($">--- Izmena izdavaca: {izdavac.Naziv}---<");
                System.Console.WriteLine("1 - Sifra");
                System.Console.WriteLine("2 - Naziv");
                System.Console.WriteLine("3 - ID sefa");
                System.Console.WriteLine("0 - Zavrsi izmenu");
                System.Console.WriteLine(">-------------------------------------------------<");
                System.Console.Write("Unesite broj vaseg izbora: ");
                choice = ConsoleViewUtils.SafeInputInt();
                System.Console.WriteLine();

                switch(choice)
                {
                    case 1:
                        System.Console.Write($"Nova sifra (stara sifra - [{izdavac.Sifra}]): ");
                        izdavac.Sifra = ConsoleViewUtils.SafeInputStr();
                        System.Console.WriteLine();
                        break;
                    case 2:
                        System.Console.Write($"Novi naziv (stari naziv - [{izdavac.Naziv}]): ");
                        izdavac.Naziv = ConsoleViewUtils.SafeInputStr();
                        System.Console.WriteLine();
                        break;
                    case 3:
                        Autor autor;
                        int noviSef;
                        do
                        {
                            Console.Write($"Novi ID sefa (stari ID sefa - [{izdavac.IDsefa}]): ");
                            noviSef = ConsoleViewUtils.SafeInputInt();
                            autor = _autoriDAO.GetById(noviSef);
                            if (autor == null)
                            {
                                Console.WriteLine("Autor ne postoji!");
                                Console.WriteLine();
                            }
                            else if (autor.Godine_iskustva < 5)
                            {
                                Console.WriteLine("Autor mora imati najmanje 5 godina iskustva!");
                                Console.WriteLine();
                                autor = null;
                            }
                        } while (autor == null);
                        izdavac.IDsefa = noviSef;
                        break;
                    case 0:
                        break;
                    default:
                        System.Console.WriteLine("Greska!!! Uneseni broj nije u opsegu");
                        System.Console.WriteLine();
                        break;
                }
            } while (choice != 0);
        }
        // brisanje izdavaca
        protected override void ObjRemoved(Izdavac izdavac)
        {
            foreach (Knjiga knjiga in _knjigeDAO.GetAll().Where(knjiga => knjiga.IDIzdavaca == izdavac.Id))
            {
                knjiga.IDIzdavaca=-1;
                _knjigeDAO.Update(knjiga);
            }
        }
    }
}
