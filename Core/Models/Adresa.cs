using System;
using System.Collections.Generic;
using System.Text;
using Core.Interfaces;
using Core.Storage.Serialization;

namespace Core.Models
{
    public class Adresa : ISerializable, I_ID
    {
        // polja
        public int Id { get; set; }
        private string ulica;
        private string broj;
        private string grad;
        private string drzava;


        // konstruktori
        public Adresa()
        {
        }
        public Adresa(string ulica, string broj, string grad, string drzava, int id)
        {
            Ulica = ulica;
            Broj = broj;
            Grad = grad;
            Drzava = drzava;
            Id = id;
        }

        //gets & sets

        public string Ulica { get => ulica; set => ulica = value; }
        public string Broj { get => broj; set => broj = value; }
        public string Grad { get => grad; set => grad = value; }
        public string Drzava { get => drzava; set => drzava = value; }


        // Serializer baziran na Vezbama 3

        public void FromCSV(string[] values)
        {
            Id = int.Parse(values[0]);
            Ulica = values[1];
            Broj = values[2];
            Grad = values[3];
            Drzava = values[4];
        }

        public string[] ToCSV()
        {
            return new[] {Id.ToString(), Ulica, Broj, Grad, Drzava};
        }


        public override string ToString()
        {
            return $"{Ulica} {Broj}, {Grad}, {Drzava}";
        }
        
    }
}
