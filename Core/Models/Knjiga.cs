using System;
using System.Collections.Generic;
using System.Text; 

namespace Core.Models
{
    internal class Knjiga
    {
        private string ISBN;
        private string naziv;
        private string zanr;
        private int godina_izdanja;
        private double cena;
        private int br_strana;
        private List<Autor> autori;
        private Izdavac izdavac;
        private List<Posetilac> posetioci_kupili;
        private List<Posetilac> posetioci_lista_zelja;

        public string ISBN1 { get => ISBN; set => ISBN = value; }
        public string Naziv { get => naziv; set => naziv = value; }
        public string Zanr { get => zanr; set => zanr = value; }
        public int Godina_izdanja { get => godina_izdanja; set => godina_izdanja = value; }
        public double Cena { get => cena; set => cena = value; }
        public int Br_strana { get => br_strana; set => br_strana = value; }
        internal List<Autor> Autori { get => autori; set => autori = value; }
        internal Izdavac Izdavac { get => izdavac; set => izdavac = value; }
        internal List<Posetilac> Posetioci_kupili { get => posetioci_kupili; set => posetioci_kupili = value; }
        internal List<Posetilac> Posetioci_lista_zelja { get => posetioci_lista_zelja; set => posetioci_lista_zelja = value; }
    }
}
