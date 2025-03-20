using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp28
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // 1. Kreiranje instance prodaje
                Prodaja prodaja1 = new Prodaja("Restoran", true);

                // 2. Kreiranje kolekcije kolača i popunjavanje obrnutim redosledom
                List<Kolac> kolekcijaKolaca = new List<Kolac>
            {
                new Kolac("Čokoladna", "torta", 1200, true, false),
                new Kolac("Voćni", "kolac", 900, false, true),
                new Kolac("Vanila", "kolac", 1200, true, true),
                new Kolac("Karamela", "torta", 800, false, false),
                new Kolac("Jagoda", "torta", 950, true, false),
                new Kolac("Malina", "kolac", 1100, false, true),
                new Kolac("Borovnica", "torta", 1050, true, false),
                new Kolac("Kokos","kolac", 1150, false, false),
                new Kolac("Lešnik", "torta", 1250, true, true),
                new Kolac("Keks", "kolac", 1300, false, true),
                new Kolac("Bela čokolada", "torta", 1400, true, false)
            };
                kolekcijaKolaca.Reverse();

                // 3. Prikazivanje prvih 5 kolača iz kolekcije
                Console.WriteLine("Prvih 5 kolača iz kolekcije:");
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine(kolekcijaKolaca[i]);
                }

                // 4. Dodavanje 5 kolača preko indeksa iz postojeće kolekcije
                for (int i = 0; i < 5; i++)
                {
                    prodaja1[i] = kolekcijaKolaca[i];
                }

                // 5. Demonstracija svih metoda
                Console.WriteLine("Porudžbenica:");
                prodaja1.Porudzbenica();
                Console.WriteLine("Ukupna cena kolača: " + prodaja1.CenaKolaca() + " dinara");

                // 6. Izvršenje LINQ upita i ispis rezultata
                Console.WriteLine("Rezultat LINQ upita:");
                prodaja1.Upit();

                // 7. Ispis rezultata sortiranja po dekoraciji koristeći IComparer
                Console.WriteLine("Sortirani kolači po dekoraciji:");
                prodaja1.IspisiSortirajPoDekoraciji();
            }
            catch (Exception ex)
            {
                Console.WriteLine("GREŠKA: " + ex.Message);
            }
        }  
    }
}

            
        
    



    


