using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    internal class Autor
    {
        int ID;
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
        public int ID1 { get => ID; set => ID = value; }
        public Adresa Adresa { get => adresa; set => adresa = value; }
        internal List<Knjiga> Napisane_knjige { get => napisane_knjige; set => napisane_knjige = value; }


        public void FromCSV(string[] vrednosti)
        {
            ID1 = int.Parse(vrednosti[0]);
            Ime = vrednosti[1];
            Prezime = vrednosti[2];
            Datum = vrednosti[3];
            Email = vrednosti[4];
            Licna_karta = vrednosti[5];
            Godine_iskustva = int.Parse(vrednosti[6]);
        }

        public string[] ToCSV()
        {
            return new[] { ID1.ToString(), Ime, Prezime, Datum, Email, Licna_karta, Godine_iskustva.ToString()};
        }
    }
}