using System;
using System.Collections.Generic;
using System.Text;
using Core.Models;

namespace Core.DAO
{
    public class KnjigaDAO : GenericDAO<Knjiga>
    {
        public KnjigaDAO(string filename) : base("knjige.txt")
        {

        }
    }
}
