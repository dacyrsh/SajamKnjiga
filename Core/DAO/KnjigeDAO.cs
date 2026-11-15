using System;
using System.Collections.Generic;
using System.Text;
using Core.Models;

namespace Core.DAO
{
    internal class KnjigeDAO : GenericDAO<Knjiga>
    {
        public KnjigeDAO(string filename) : base("knjige.txt")
        {

        }
    }
}
