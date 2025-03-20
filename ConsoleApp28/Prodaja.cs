using System;
using System.Collections.Generic;

namespace ConsoleApp28
{
    // Klasa "Prodaja" implementira interfejs "IPoslasticarnica" i modelira proces prodaje kolača
    internal class Prodaja : IPoslasticarnica
    {
        // Privatna lista koja sadrži naručene kolače
        private List<Kolac> kolaci;

        // Ukupna cena svih kolača u narudžbini
        private double cena;

        // Tip narudžbine (može biti npr. "Restoran" ili "Pojedinačna kupovina")
        private string porudzbina;

        // Sertifikat je potreban ako je porudžbina namenjena restoranu
        private bool sertifikat;

        // Javni svojstvo koje omogućava pristup listi kolača
        public List<Kolac> Kolaci => kolaci;

        // Svojstvo koje omogućava čitanje ukupne cene
        public double Cena
        {
            get { return cena; }
            private set { cena = value; } // Postavljanje cene može samo unutar klase
        }

        // Svojstvo za tip porudžbine
        public string Porudzbina
        {
            get { return porudzbina; }
            set
            {
                // Ako je porudžbina za restoran, mora postojati sertifikat
                if (value == "Restoran" && !sertifikat)
                {
                    throw new Exception("Za restoran je potreban sertifikat!");
                }
                porudzbina = value;
            }
        }

        // Svojstvo koje postavlja ili vraća sertifikat
        public bool Sertifikat
        {
            get { return sertifikat; }
            set
            {
                // Ako je porudžbina za restoran, sertifikat mora biti postavljen
                if (porudzbina == "Restoran" && !value)
                {
                    throw new Exception("Sertifikat je obavezan za restoran!");
                }
                sertifikat = value;
            }
        }

        // Konstruktor klase koji inicijalizuje listu kolača i postavlja vrednosti svojstava
        public Prodaja(string porudzbina, bool sertifikat)
        {
            this.kolaci = new List<Kolac>(); // Kreiramo praznu listu kolača
            this.porudzbina = porudzbina;
            this.sertifikat = sertifikat;
            this.cena = 0; // Početna cena je 0
        }

        // Indeksator koji omogućava direktan pristup kolačima u listi pomoću indeksa
        public Kolac this[int index]
        {
            get { return kolaci[index]; }
            set { kolaci[index] = value; }
        }

        // Metoda koja sortira listu kolača po dekoraciji i ispisuje ih
        public void IspisiSortirajPoDekoraciji(IComparer<Kolac> comparer = null)
        {
            if (comparer == null)
            {
                // Ako nije prosleđen poseban kriterijum sortiranja, sortiramo po dekoraciji
                kolaci.Sort((a, b) => a.Dekoracija.CompareTo(b.Dekoracija));
            }
            else
            {
                // Ako je prosleđen drugi kriterijum, koristimo njega
                kolaci.Sort(comparer);
            }

            // Ispisujemo sortiranu listu kolača
            foreach (var kolac in kolaci)
            {
                Console.WriteLine(kolac);
            }
        }

        // Implementacija metoda interfejsa IPoslasticarnica

        // Dodaje kolač u listu i povećava ukupnu cenu
        public void PoruciKolac(Kolac k)
        {
            kolaci.Add(k);
            cena += k.Cena;
            Console.WriteLine($"Dodali ste kolač: {k.Naziv}, cena: {k.Cena} RSD.");
        }

        // Ispisuje detalje o porudžbini, uključujući sve kolače i ukupnu cenu
        public void Porudzbenica()
        {
            Console.WriteLine("=== Porudžbenica ===");
            foreach (var kolac in kolaci)
            {
                Console.WriteLine($"- {kolac.Naziv}: {kolac.Cena} RSD");
            }
            Console.WriteLine($"Ukupna cena: {cena} RSD");
        }

        // Vraća ukupnu cenu svih kolača
        public double CenaKolaca()
        {
            return cena;
        }

        // Otkazuje porudžbinu, briše sve kolače i resetuje cenu
        public void OdustajanjeOdPorudzbine()
        {
            kolaci.Clear(); // Brišemo sve kolače iz liste
            cena = 0; // Resetujemo cenu
            Console.WriteLine("Porudžbina je otkazana.");
        }
    }
}
