using Core.Interfaces;
using Core.Storage.Serialization;
using Core.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    internal class Izdavac : ISerializable, I_ID
    {
        // polja
        public int Id { get; set; }
        private string sifra;
        private string naziv;
        private int Idsefa;
        private List<int> autori = new();
        private List<int> knjige = new();

        // get i set metode
        public string Sifra { get => sifra; set => sifra = value; }
        public string Naziv { get => naziv; set => naziv = value; }
        internal int IDsefa { get => Idsefa; set => Idsefa = value; }
        internal List<int> Autori { get => autori; set => autori = value; }
        internal List<int> Knjige { get => knjige; set => knjige = value; }

        // konstruktori
        public Izdavac() { }
        public Izdavac(int id, string sifra, string naziv, int Idsefa)
        {
            Id = id;
            Sifra = sifra;
            Naziv = naziv;
            IDsefa = Idsefa;
        }

        public void FromCSV(string[] values)
        {
            Id = int.Parse(values[0]);
            Sifra = values[1];
            Naziv= values[2];
            IDsefa = int.Parse(values[3]);
            Autori = CsvConversion.ToIds(values[4]);
            Knjige = CsvConversion.ToIds(values[5]);
        }
        public string[] ToCSV()
        {
            return new[]
            {
                Id.ToString(),
                Sifra,
                Naziv,
                Idsefa.ToString(),
                CsvConversion.FromIds(Autori),
                CsvConversion.FromIds(Knjige)
            };
        }
    }
}
