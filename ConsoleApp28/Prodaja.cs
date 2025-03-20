using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp28
{
    internal class Prodaja : IPoslasticarnica
    {
        
    
        private List<Kolac> kolaci;
        private double cena;
        private string porudzbina;
        private bool sertifikat;

        public List<Kolac> Kolaci => kolaci;

        public double Cena
        {
            get { return cena; }
            private set { cena = value; }
        }

        public string Porudzbina
        {
            get { return porudzbina; }
            set
            {
                if (value == "Restoran" && !sertifikat)
                {
                    throw new Exception("Za restoran je potreban sertifikat!");
                }
                porudzbina = value;
            }
        }

        public bool Sertifikat
        {
            get { return sertifikat; }
            set
            {
                if (porudzbina == "Restoran" && !value)
                {
                    throw new Exception("Za restoran je obavezan sertifikat!");
                }
                sertifikat = value;
            }
        }

        // Podrazumevani konstruktor
        public Prodaja()
        {
            kolaci = new List<Kolac>();
            cena = 0;
            porudzbina = "";
            sertifikat = false;
        }

        // Indekser za pristup kolačima
        public Kolac this[int index]
        {
            get
            {
                if (index < 0 || index >= kolaci.Count)
                    throw new IndexOutOfRangeException("Nevalidan indeks!");
                return kolaci[index];
            }
        }

        // Implementacija metoda interfejsa
        public void PoruciKolac(Kolac k)
        {
            if (kolaci.Count >= 5)
            {
                throw new Exception("Nije moguće dodati više od 5 kolača!");
            }
            kolaci.Add(k);
        }

        public void Porudzbenica()
        {
            Console.WriteLine("Poručeni kolači:");
            foreach (var k in kolaci)
            {
                Console.WriteLine(k);
            }
        }

        public double CenaKolaca()
        {
            double osnovnaCena = kolaci.Sum(k => Cena);

            if (porudzbina == "Restoran")
            {
                if (sertifikat)
                    return osnovnaCena * 1.3; // +30% uz sertifikat
                return osnovnaCena * 1.2; // +20% bez sertifikata
            }
            else if (porudzbina == "Kuca" && sertifikat)
            {
                return osnovnaCena * 1.1; // +10% uz sertifikat
            }

            return osnovnaCena;
        }

        public void OdustajanjeOdPorudzbine()
        {
            kolaci.Clear();
        }

        // Metod za LINQ upit - filtriranje i sortiranje kolača
        public void Upit()
        {
            var filtriraniKolaci = kolaci
                .Where(k => porudzbina == "Restoran" && k.Tezina > 1200)
                .OrderBy(k => k.Naziv)
                .ToList();

            Console.WriteLine("Kolači teži od 1200g sortirani po nazivu:");
            foreach (var k in filtriraniKolaci)
            {
                Console.WriteLine(k);
            }
        }

        // Metod za sortiranje koristeći IComparer
        public void IspisiSortirajPoDekoraciji(IComparer<Kolac> comparer)
        {
            kolaci.Sort(comparer);
            Console.WriteLine("Kolači sortirani prema dekoraciji:");
            foreach (var k in kolaci)
            {
                Console.WriteLine(k);
            }
        }
    }








}






