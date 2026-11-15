using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    internal class Autor
    {

        // polja
        int ID;
        private string ime;
        private string prezime;
        private DateOnly datum;
        private int IDadrese;
        private string email;
        private string licna_karta;
        private int godine_iskustva;
        private List<Knjiga> napisane_knjige;
        

        // gets & sets
        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public DateOnly Datum { get => datum; set => datum = value; }
        public int IDAdrese { get => IDadrese; set => IDadrese = value; }
        public string Email { get => email; set => email = value; }
        public string Licna_karta { get => licna_karta; set => licna_karta = value; }
        public int Godine_iskustva { get => godine_iskustva; set => godine_iskustva = value; }
        public int ID1 { get => ID; set => ID = value; }
        internal List<Knjiga> Napisane_knjige { get => napisane_knjige; set => napisane_knjige = value; }


        // serijalizacija
        public void FromCSV(string[] vrednosti)
        {
            ID1 = int.Parse(vrednosti[0]);
            Ime = vrednosti[1];
            Prezime = vrednosti[2];
            Datum = DateOnly.Parse(vrednosti[3]);
            IDAdrese = int.Parse(vrednosti[4]);
            Email = vrednosti[5];
            Licna_karta = vrednosti[6];
            Godine_iskustva = int.Parse(vrednosti[7]);
        }

        public string[] ToCSV()
        {
            return new[] { ID1.ToString(), Ime, Prezime, Datum.ToString(), IDAdrese.ToString(), Email, Licna_karta, Godine_iskustva.ToString()};
        }
    }
}