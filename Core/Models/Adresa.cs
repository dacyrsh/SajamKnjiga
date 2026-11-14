using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    internal class Adresa
    {
        private string ulica;
        private int broj;
        private string grad;
        private string drzava;

        public string Ulica { get => ulica; set => ulica = value; }
        public int Broj { get => broj; set => broj = value; }
        public string Grad { get => grad; set => grad = value; }
        public string Drzava { get => drzava; set => drzava = value; }
    }
}
