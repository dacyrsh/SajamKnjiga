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

        
    }
}
