using System;
using System.Collections.Generic;
using System.Text;
using Core.Models;

namespace Core.DAO
{
    public class AdresaDAO : GenericDAO<Adresa>
    {
        public AdresaDAO(string fileName):base("adrese.txt")
        {

        }
    }
}
