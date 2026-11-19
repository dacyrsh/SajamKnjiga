using System;
using System.Collections.Generic;
using System.Text;
using Core.Interfaces;
using Core.Storage.Serialization;
using Core.Utils;

namespace Core.Models
{
    public class Kupovina : ISerializable, I_ID
    {
        // polja
        public int Id { get; set; }
        private int IdPosetioca;
        private int IdKnjige;
        private DateOnly datum_kupovine;
        private int ocena;
        private string komentar;

        // get i set metode
        public int IDposetioca { get => IdPosetioca; set => IdPosetioca = value; }
        public int IDknjige { get => IdKnjige; set => IdKnjige = value; }
        public DateOnly Datum_kupovine { get => datum_kupovine; set => datum_kupovine = value; }
        public int Ocena { get => ocena; set => ocena = value; }
        public string Komentar { get => komentar; set => komentar = value; }
        

        // kontruktori

        public Kupovina() { }

        public Kupovina(int id, int IdPosetioca, int IdKnjige, DateOnly datum_kupovine, int ocena, string komentar) 
        {
            Id = id;
            IDposetioca = IdPosetioca;
            IDknjige = IdKnjige;
            Datum_kupovine = datum_kupovine;
            Ocena = ocena;
            Komentar = komentar;
        }

        public void FromCSV(string[] values)
        {
            Id = int.Parse(values[0]);
            IDposetioca = int.Parse(values[1]);
            IDknjige = int.Parse(values[2]);
            Datum_kupovine = CsvConversion.ToDate(values[3]);
            Ocena = int.Parse(values[4]);
            Komentar = values[5];

        }
        public string[] ToCSV()
        {
            return new[]
            { 
                Id.ToString(),
                IDposetioca.ToString(),
                IDknjige.ToString(),
                CsvConversion.FromDate(Datum_kupovine),
                Ocena.ToString(),
                Komentar
            };
        }

    }
}
