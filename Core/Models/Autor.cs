using Core.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Storage.Serialization;
using Core.Interfaces;

namespace Core.Models
{
    public class Autor : ISerializable, I_ID
    {

        // polja
        public int Id { get; set; }
        private string ime;
        private string prezime;
        private DateOnly datum;
        private int IDadrese;
        private string email;
        private string licna_karta;
        private int godine_iskustva;
        private List<int> IDnapisanih_knjiga;


        // gets & sets
        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public DateOnly Datum { get => datum; set => datum = value; }
        public int IDAdrese { get => IDadrese; set => IDadrese = value; }
        public string Email { get => email; set => email = value; }
        public string Licna_karta { get => licna_karta; set => licna_karta = value; }
        public int Godine_iskustva { get => godine_iskustva; set => godine_iskustva = value; }
        internal List<int> IDNapisanih_knjiga { get => IDnapisanih_knjiga; set => IDnapisanih_knjiga = value; }

        // konstruktor

        public Autor()
        {

        }


        public Autor(int id, string ime, string prezime, DateOnly datum, string email, string licna_karta, int godine_iskustva)
        {
            Id = id;
            Ime = ime;
            Prezime = prezime;
            Datum = datum;
            Email = email;
            Licna_karta = licna_karta;
            Godine_iskustva = godine_iskustva;
        }

        // serijalizacija
        public void FromCSV(string[] values)
        {
            Id = int.Parse(values[0]);
            Ime = values[1];
            Prezime = values[2];
            Datum = DateOnly.Parse(values[3]);
            IDAdrese = int.Parse(values[4]);
            Email = values[5];
            Licna_karta = values[6];
            Godine_iskustva = int.Parse(values[7]);
            IDNapisanih_knjiga = CsvConversion.ToIds(values[8]);
        }

        public string[] ToCSV()
        {
            return new[] { Id.ToString(), Ime, Prezime, Datum.ToString(), IDAdrese.ToString(), Email, Licna_karta, Godine_iskustva.ToString(), CsvConversion.FromIds(IDnapisanih_knjiga)};
        }
    }
}