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

        private string izdavac;
        private List<Posetilac> posetioci_kupili;
        private List<Posetilac> posetioci_lista_zelja;
    }
}
