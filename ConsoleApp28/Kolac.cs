using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp28
{
    internal class Kolac
    {
        private string naziv, vrsta;
        private int tezina;
        private bool dekoracija, dostava;
        public double Cena { get; set; }

        // Konstruktor
        public Kolac(string naziv, string vrsta, int tezina, bool dekoracija, bool dostava)
        {
            this.naziv = naziv;
            this.vrsta = vrsta;
            this.tezina = tezina;
            this.dekoracija = dekoracija;
            this.dostava = dostava;
        }

        // Svojstva (geteri i seteri)
        public string Naziv => naziv;
        public string Vrsta => vrsta;
        public int Tezina => tezina;
        public bool Dekoracija => dekoracija;
        public bool Dostava => dostava;

        // Metode za proveru dekoracije i dostave
        public string DaLiJePotrebnaDekoracija()
        {
            return dekoracija ? "potrebna" : "nije potrebna";
        }

        public string DaLiJePotrebnaDostava()
        {
            return dostava ? "potrebna" : "nije potrebna";
        }

        // Metoda za ispis podataka o kolaču
        public override string ToString()
        {
            return "Naziv: {naziv}, Vrsta: {vrsta}, Težina: {tezina}g, Dekoracija: {DaLiJePotrebnaDekoracija()}, Dostava: {DaLiJePotrebnaDostava()}";
        }
    }

}

