using System;
using System.Collections.Generic;
using System.Text;
using Core.DAO;
using Core.Interfaces;

namespace ConsoleClient.Views
{
    internal abstract class GenericView<T> where T : class, I_ID
    {
        private readonly IEntityDAO<T> _dao;
        private readonly string _objName;

        protected GenericView(IEntityDAO<T> dao, string objName)
        {
            _dao = dao;
            _objName = objName;
        }

        // Unos (Create)

        private void Add(string nameOfObj)
        {
            T obj = InputObj();
            _dao.Add(obj);
            System.Console.WriteLine($"{nameOfObj} je uspesno dodat. ID = {obj.Id} ");
        }

        protected abstract T InputObj();

        // Ispis (Read)
        
        private void PrintAll(string nameOfObj)
        {
            List<T> objs = _dao.GetAll();

            if (objs.Count == 0)
                System.Console.WriteLine("Trenutno nema ni jedan podatak.");
            else
            {
                System.Console.WriteLine($"{nameOfObj}:");
                foreach (T obj in objs)
                {
                    PrintObj(obj);
                }
            }
        }

        protected abstract void PrintObj(T obj);

        // Izmena (Update)

    
        }
    }
}
