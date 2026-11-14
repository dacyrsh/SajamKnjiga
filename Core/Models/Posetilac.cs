using System;
using System.Collections.Generic;
using System.Text;

enum TipStatusa { Regular = 'R', Vip = 'V'};

namespace Core.Models
{
    internal class Posetilac
    {
        private string ime;
        private string prezime;
        private string datum;
        private Adresa adresa;
        private string telefon;
        private string email;
        private string clanska_karta;
        private int godina_clanstva;
        private TipStatusa status;
        private double ocena_recenzija;
        private List<Kupovina> kupljene_knjige;
        private List<Knjiga> lista_zelja;

        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public string Datum { get => datum; set => datum = value; }
        public string Telefon { get => telefon; set => telefon = value; }
        public string Email { get => email; set => email = value; }
        public string Clanska_karta { get => clanska_karta; set => clanska_karta = value; }
        public int Godina_clanstva { get => godina_clanstva; set => godina_clanstva = value; }
        public double Ocena_recenzija { get => ocena_recenzija; set => ocena_recenzija = value; }
        internal Adresa Adresa { get => adresa; set => adresa = value; }
        internal TipStatusa Status { get => status; set => status = value; }
        internal List<Kupovina> Kupljene_knjige { get => kupljene_knjige; set => kupljene_knjige = value; }
        internal List<Knjiga> Lista_zelja { get => lista_zelja; set => lista_zelja = value; }



    }
}
