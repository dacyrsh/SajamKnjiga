using System;
using System.Collections.Generic;
using System.Text;

enum TipStatusa { P, B};

namespace Core.Models
{
    internal class Posetilac
    {
        private string ime;
        private string prezime;
        private string datum;
        private string adresa;
        private string telefon;
        private string email;
        private string clanska_karta;
        private int godina_clanstva;
        private TipStatusa status;

        private double ocena_recenzija;



        public Posetilac()
        {

        }
    }
}
