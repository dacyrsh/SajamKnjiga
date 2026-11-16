using System;
using System.Collections.Generic;
using System.Text;
using Core.Models;

namespace Core.DAO
{
    public class AutorDAO : GenericDAO<Autor>
    {
        public AutorDAO(string fileName) : base("autori.txt")
        {
        }
    }
}
