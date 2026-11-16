using System;
using System.Collections.Generic;
using System.Text;
using Core.Models;

namespace Core.DAO
{
    internal class AdreseDAO : GenericDAO<Adresa>
    {
        public AdresaDAO(string fileName):base("adrese.txt")
        {

        }
    }
}
