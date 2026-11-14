using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    internal class Izdavac
    {
        private string sifra;
        private string naziv;
        private Autor sef;
        private List<Autor> autori;
        private List<Knjiga> knjige;

        public string Sifra { get => sifra; set => sifra = value; }
        public string Naziv { get => naziv; set => naziv = value; }
        internal Autor Sef { get => sef; set => sef = value; }
        internal List<Autor> Autori { get => autori; set => autori = value; }
        internal List<Knjiga> Knjige { get => knjige; set => knjige = value; }
    }
}
