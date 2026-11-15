using Core.Utils;
using System;
using System.Collections.Generic;
using System.Text; 

namespace Core.Models
{
    internal class Knjiga
    {

        //polja
        private string ISBN;
        private string naziv;
        private string zanr;
        private int godina_izdanja;
        private double cena;
        private int br_strana;
        private List<int> IDautora;
        private int IDizdavaca;
        private List<int> IDkupaca; // posetiloci koji su kupili knjigu
        private List<int> IDzelja; // posetioci koji su stavili knjigu na listu zelja

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
        internal List<int> IDAutora { get => IDautora; set => IDautora = value; }


        // serijalizacija   

        public void FromCSV(string[] values)
        {
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
            return new[] { ISBN1, Naziv, Zanr, Godina_izdanja.ToString(), Cena.ToString(), Br_strana.ToString(), IDIzdavaca.ToString(), CsvConversion.FromIds(IDKupaca), CsvConversion.FromIds(IDZelja), CsvConversion.FromIds(IDAutora) };
        }

    }
}
