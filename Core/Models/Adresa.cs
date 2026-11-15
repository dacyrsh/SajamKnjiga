using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    internal class Adresa
    {
        // polja
        private int ID;
        private string ulica;
        private string broj;
        private string grad;
        private string drzava;


        // konstruktori
        public Adresa()
        {
        }
        public Adresa(string ulica, string broj, string grad, string drzava, int iD1)
        {
            Ulica = ulica;
            Broj = broj;
            Grad = grad;
            Drzava = drzava;
            ID1 = iD1;
        }

        //gets & sets

        public string Ulica { get => ulica; set => ulica = value; }
        public string Broj { get => broj; set => broj = value; }
        public string Grad { get => grad; set => grad = value; }
        public string Drzava { get => drzava; set => drzava = value; }
        public int ID1 { get => ID; set => ID = value; }


        // Serializer baziran na Vezbama 3

        public void FromCSV(string[] vrednosti)
        {
            ID1 = int.Parse(vrednosti[0]);
            Ulica = vrednosti[1];
            Broj = vrednosti[2];
            Grad = vrednosti[3];
            Drzava = vrednosti[4];
        }

        public string[] ToCSV()
        {
            return new[] {ID1.ToString(), Ulica, Broj, Grad, Drzava};
        }

        
    }
}
