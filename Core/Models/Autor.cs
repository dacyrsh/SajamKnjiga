using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    internal class Autor
    {
        private string ime;
        private string prezime;
        private string datum;
        private Adresa adresa;
        private string email;
        private string licna_karta;
        private int godine_iskustva;
        private List<Knjiga> napisane_knjige;

        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public string Datum { get => datum; set => datum = value; }
        public string Email { get => email; set => email = value; }
        public string Licna_karta { get => licna_karta; set => licna_karta = value; }
        public int Godine_iskustva { get => godine_iskustva; set => godine_iskustva = value; }
        internal Adresa Adresa { get => adresa; set => adresa = value; }
        internal List<Knjiga> Napisane_knjige { get => napisane_knjige; set => napisane_knjige = value; }
    }
}
