using System;
using System.Collections.Generic;

namespace ConsoleApp28
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Kreiramo instancu klase "Prodaja" sa tipom porudžbine "Restoran" i sertifikatom
                Prodaja prodaja1 = new Prodaja("Restoran", true);

                // Kreiramo kolekciju kolača sa različitim karakteristikama
                List<Kolac> kolekcijaKolaca = new List<Kolac>
                {
                    new Kolac("Čokoladna", "torta", 1200, true, false),
                    new Kolac("Voćni", "kolac", 900, false, true),
                    new Kolac("Vanila", "kolac", 1200, true, true),
                    new Kolac("Karamela", "torta", 800, false, false),
                    new Kolac("Jagoda", "torta", 950, true, false),
                    new Kolac("Malina", "kolac", 1100, false, true),
                    new Kolac("Borovnica", "torta", 1050, true, false),
                };

                // Dodajemo kolače u listu narudžbine unutar prodaje
                foreach (var kolac in kolekcijaKolaca)
                {
                    prodaja1.Kolaci.Add(kolac);
                }

                // Primer korišćenja indeksatora - menjamo prvi kolač u listi
                prodaja1[0] = new Kolac("Leshnik", "torta", 1300, true, true);

                // Pozivamo metodu za sortiranje kolača po dekoraciji
                // Ako ne prosledimo posebni kriterijum, koristiće se podrazumevani kriterijum sortiranja
                prodaja1.IspisiSortirajPoDekoraciji();

                
            }
            catch (Exception ex)
            {
                // Hvatanje i ispisivanje eventualnih grešaka tokom izvršavanja programa
                Console.WriteLine($"Greška: {ex.Message}");
            }
        }
    }
}