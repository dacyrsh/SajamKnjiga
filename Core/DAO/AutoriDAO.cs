using System;
using System.Collections.Generic;
using System.Text;
using Core.Models;

namespace Core.DAO
{
    internal class AutoriDAO : GenericDAO<Autor>
    {
        public AutoriDAO(string fileName) : base("autori.txt")
        {
        }
    }
}
