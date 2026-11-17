using Core.Interfaces;
using Core.Storage.Serialization;
using Core.Utils;
using System;
using System.Collections.Generic;
using System.Text; 

namespace Core.Models
{
    public class Knjiga : ISerializable, I_ID
    {

        //polja
        public int Id { get; set; }
        private string ISBN;
        private string naziv;
        private string zanr;
        private int godina_izdanja;
        private double cena;
        private int br_strana;
        private List<int> IDautora = new();
        private int IDizdavaca = -1;
        private List<int> IDkupaca = new(); // posetiloci koji su kupili knjigu
        private List<int> IDzelja = new(); // posetioci koji su stavili knjigu na listu zelja

        //gets & sets
        public string ISBN1 { get => ISBN; set => ISBN = value; }
        public string Naziv { get => naziv; set => naziv = value; }
        public string Zanr { get => zanr; set => zanr = value; }
        public int Godina_izdanja { get => godina_izdanja; set => godina_izdanja = value; }
        public double Cena { get => cena; set => cena = value; }
        public int Br_strana { get => br_strana; set => br_strana = value; }
        public int IDIzdavaca { get => IDizdavaca; set => IDizdavaca = value; }
        public List<int> IDKupaca { get => IDkupaca; set => IDkupaca = value; }
        public List<int> IDZelja { get => IDzelja; set => IDzelja = value; }
        public List<int> IDAutora { get => IDautora; set => IDautora = value; }


        // Konstruktori
        public Knjiga() { }

        public Knjiga(int id, string iSBN, string naziv, string zanr, int godina_izdanja, double cena, int br_strana, List<int> iDautora, int iDizdavaca, List<int> iDkupaca, List<int> iDzelja)
        {
            Id = id;
            ISBN = iSBN;
            Naziv = naziv;
            Zanr = zanr;
            Godina_izdanja = godina_izdanja;
            Cena = cena;
            Br_strana = br_strana;
            IDAutora = iDautora;
            IDIzdavaca = iDizdavaca;
            IDKupaca = iDkupaca;
            IDZelja = iDzelja;
        }



        // serijalizacija   

        public void FromCSV(string[] values)
        {
            Id = int.Parse(values[0]);
            ISBN1 = values[1];
            Naziv = values[2];
            Zanr = values[3];
            Godina_izdanja = int.Parse(values[4]);
            Cena = double.Parse(values[5]);
            Br_strana =  int.Parse(values[6]);
            IDIzdavaca = int.Parse(values[7]);
            IDKupaca = CsvConversion.ToIds(values[8]);
            IDZelja = CsvConversion.ToIds(values[9]);
            IDAutora = CsvConversion.ToIds(values[10]);
        }


        public string[] ToCSV()
        {
            return new[] { Id.ToString(), ISBN1, Naziv, Zanr, Godina_izdanja.ToString(), Cena.ToString(), Br_strana.ToString(), IDIzdavaca.ToString(), CsvConversion.FromIds(IDKupaca), CsvConversion.FromIds(IDZelja), CsvConversion.FromIds(IDAutora) };
        }

    }
}
