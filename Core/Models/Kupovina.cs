using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    internal class Kupovina
    {
        private Posetilac posetilac;
        private Knjiga knjiga;
        private string datum_kupovine;
        private int ocena;
        private string komentar;

        public string Datum_kupovine { get => datum_kupovine; set => datum_kupovine = value; }
        public int Ocena { get => ocena; set => ocena = value; }
        public string Komentar { get => komentar; set => komentar = value; }
        internal Posetilac Posetilac { get => posetilac; set => posetilac = value; }
        internal Knjiga Knjiga { get => knjiga; set => knjiga = value; }
    }
}
