using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Storage.Serialization;
using Core.Utils;

namespace Core.Models
{
    enum TipStatusa { Regular = 'R', Vip = 'V'};
    internal class Posetilac : ISerializable, I_ID
    {
        // polja
        public int Id { get; set; }
        private string ime;
        private string prezime;
        private DateOnly datumRodjenja;
        private int IdAdrese;
        private string telefon;
        private string email;
        private string clanska_karta;
        private int godina_clanstva;
        private TipStatusa status;
        private double ocena_recenzija;
        private List<int> kupljene_knjige=new();
        private List<int> lista_zelja=new();

        // get i set metode

        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public DateOnly DatumRodjenja { get => datumRodjenja; set => datumRodjenja = value; }
        public string Telefon { get => telefon; set => telefon = value; }
        public string Email { get => email; set => email = value; }
        public string Clanska_karta { get => clanska_karta; set => clanska_karta = value; }
        public int Godina_clanstva { get => godina_clanstva; set => godina_clanstva = value; }
        public double Ocena_recenzija { get => ocena_recenzija; set => ocena_recenzija = value; }
        internal int IDAdrese { get => IdAdrese; set => IdAdrese = value; }
        internal TipStatusa Status { get => status; set => status = value; }
        internal List<int> Kupljene_knjige { get => kupljene_knjige; set => kupljene_knjige = value; }
        internal List<int> Lista_zelja { get => lista_zelja; set => lista_zelja = value; }

        // konstruktori
        public Posetilac() { }
        public Posetilac(int id, string ime, string prezime, DateOnly datumRodjenja, int IdAdrese, string telefon, string email, string clanska_karta, int godina_clanstva, TipStatusa status, double ocena_recenzija)
        {
            Id = id;
            Ime = ime;
            Prezime = prezime;
            DatumRodjenja = datumRodjenja;
            IDAdrese = IdAdrese;
            Telefon = telefon;
            Email = email;
            Clanska_karta = clanska_karta;
            Godina_clanstva = godina_clanstva;
            Status = status;
            Ocena_recenzija = ocena_recenzija;
        }
        public void FromCSV(string[] values)
        {
            Id = int.Parse(values[0]);
            Ime = values[1];
            Prezime=values[2];
            DatumRodjenja = DateOnly.Parse(values[3]);
            IDAdrese = int.Parse(values[4]);
            Telefon = values[5];
            Email = values[6];
            Clanska_karta = values[7];
            Godina_clanstva = int.Parse(values[8]);
            Status = (TipStatusa)char.Parse(values[9]);
            Ocena_recenzija = double.Parse(values[10]);
            Kupljene_knjige = CsvConversion.ToIds(values[11]);
            Lista_zelja = CsvConversion.ToIds(values[12]);
        }
        public string[] ToCSV()
        {
            return new[]
            {
                Id.ToString(),
                Ime,
                Prezime, 
                DatumRodjenja.ToString(),
                IDAdrese.ToString(),
                Telefon,
                Email,
                Clanska_karta,
                Godina_clanstva.ToString(),
                ((char)Status).ToString(),
                Ocena_recenzija.ToString(),
                CsvConversion.FromIds(Kupljene_knjige),
                CsvConversion.FromIds(Lista_zelja)
            };
        }


    }
}
