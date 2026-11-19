using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using Core.DAO;
using Core.Interfaces;
using Core.Utils;

namespace ConsoleClient.Views
{
    internal abstract class GenericView<T> where T : class, I_ID
    {
        private readonly IEntityDAO<T> _dao;
        private readonly string _objName;

        protected virtual string ExtraMenu=> null;

        protected virtual void ShowExtraMenu()
        {

        }

        protected GenericView(IEntityDAO<T> dao, string objName)
        {
            _dao = dao;
            _objName = objName;
        }



        // Run

        public void Run()
        {
            int choice;

            do
            {
                // meni
                System.Console.WriteLine($">---- {_objName} ----<");
                System.Console.WriteLine("1 - Prikaži sve");
                System.Console.WriteLine("2 - Dodaj");
                System.Console.WriteLine("3 - Izmeni");
                System.Console.WriteLine("4 - Obriši");
                if (ExtraMenu is not null)
                    System.Console.WriteLine($"5 - {ExtraMenu}");
                System.Console.WriteLine("0 - Nazad");
                System.Console.WriteLine(">-------------------<");

                System.Console.Write("Unesite broj vašeg izbora: ");
                choice = ConsoleViewUtils.SafeInputInt();
                System.Console.WriteLine();

                switch (choice)
                {

                    case 1:
                        PrintAll();
                        break;
                    case 2:
                        Add();
                        break;
                    case 3:
                        Update();
                        break;
                    case 4:
                        Remove();
                        break;

                    case 5 when ExtraMenu is not null:
                        ShowExtraMenu();
                        break;
                    case 0:
                        break;

                    default:
                        System.Console.WriteLine("Greška!!! Unešeni broj nije u opsegu.");
                        break;
                }
            } while (choice != 0);
        
        }

        // Unos (Create)

        private void Add()
        {
            T obj = InputObj();
            _dao.Add(obj);
            System.Console.WriteLine($"Objekat je uspesno dodat. ID = {obj.Id} ");
            System.Console.WriteLine();
        }

        protected abstract T InputObj();

        // Ispis (Read)
        
        private void PrintAll()
        {
            List<T> objs = _dao.GetAll();

            if (objs.Count == 0)
                System.Console.WriteLine("Trenutno nema ni jedan podatak.");
            else
            {
                System.Console.WriteLine($"{_objName}:");
                foreach (T obj in objs)
                {
                    PrintObj(obj);
                }
                Console.WriteLine();
            }
        }

        protected abstract void PrintObj(T obj);

        // Izmena (Update)

        private void Update()
        {
            Console.Write("Unesite ID koji zelite menjati: ");
            int id = ConsoleViewUtils.SafeInputInt();
            Console.WriteLine();

            T obj = _dao.GetById(id);

            if(obj == null)
            {
                System.Console.WriteLine("ID " + id + " ne postoji u sistemu!\n");
                return;
            }

            ReadUpdatedObj(obj);
            _dao.Update(obj);
        }

        protected abstract void ReadUpdatedObj(T obj);

        // Brisanje (Delete)

        private void Remove()
        {
            Console.Write("ID za brisanje: ");
            int id = ConsoleViewUtils.SafeInputInt();
            Console.WriteLine(); 
            T obj = _dao.GetById(id);

            if(obj == null)
            {
                System.Console.WriteLine("ID " + id + " ne postoji u sistemu!");
                System.Console.WriteLine(); 
                return;
            }

            _dao.Remove(id);
            ObjRemoved(obj);
        }

        protected abstract void ObjRemoved(T obj);


    }
}
