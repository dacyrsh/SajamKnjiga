using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    internal class Izdavac
    {
        public string sifra;
        public string naziv;
        public Autor sef;
        public List<Autor> autori;
        public List<Knjiga> knjige;
    }
}
