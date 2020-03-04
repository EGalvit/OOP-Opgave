using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Øvelse1_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;

            //objects
            Beer bent = new Beer("Royal Export", 5, 33, Beer.BeerType.Lager);

            Beer bobber = new Beer("Royal Export", 6, 50, Beer.BeerType.Lager);

            Beer bobby = new Beer("Tuborg Classic", 4, 33, Beer.BeerType.Lager);

            Beer benny = new Beer();
            //assigned values to the properties
            benny.Navn = "Corona";
            benny.Procent = 4;
            benny.Volume = 35;
            benny.Slags = Beer.BeerType.Pilsner;

            Beer føj = new Beer();
            føj = bent + bobby;

            Beer føj2 = new Beer();
            føj2 = benny + bent;

            Beer føj3 = new Beer();
            føj3 = bent + bobber;

            //a list of Beer objects
            List<Beer> bliste = new List<Beer>() { bent, bobby, føj, benny, føj2, bobber, føj3 };

            foreach (var item in bliste)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Listen er blevet sorteret efter antal af genstande\n--------------------------------");
            //sorting the list using the IComparable method 
            bliste.Sort();

            foreach (var item in bliste)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }

    class Beer : IComparable<Beer>
    {
        //properties 
        public enum BeerType { Lager, Pilsner, Münchener, WienerDortmunder, Bock, Doppelbock, Porter, Mix }
        public BeerType Slags { get; set; }
        public string Navn { get; set; }
        public float Procent { get; set; }
        public int Volume { get; set; }

        //empty constructor
        public Beer()
        {
        }

        //not empty constructor
        public Beer(string navn, float procent, int volume, BeerType s)
        {
            Navn = navn;
            Procent = procent;
            Volume = volume;
            Slags = s;
        }

        //used for comparing
        public int CompareTo(Beer beer)
        {
            if (GetUnits(this) < beer.GetUnits(beer))
            {
                return -1;
            }
            else if (GetUnits(this) > beer.GetUnits(beer))
            {
                return 1;
            }
            else
                return 0;
        }

        //method that does some math
        public double GetUnits(Beer beer)
        {
            double genstande = (beer.Volume * beer.Procent) / 150;

            return genstande;
        }

        //method that allows you to add two beers together
        public static Beer operator +(Beer b1, Beer b2)
        {
            Beer nyBeer = new Beer();
            if (b1.Navn == b2.Navn)
            {
                nyBeer.Navn = b2.Navn;
            }
            else
            {
                nyBeer.Navn = "Blandet Bajer";
            }

            nyBeer.Procent = ((b1.Volume * b1.Procent) + (b2.Volume * b2.Procent)) / (b1.Volume + b2.Volume);
            nyBeer.Volume = b1.Volume + b2.Volume;

            if (b1.Slags == b2.Slags)
            {
                nyBeer.Slags = b1.Slags;
            }
            else
                nyBeer.Slags = BeerType.Mix;

            return nyBeer;
        }

        //overrinding the ToString method
        public override string ToString()
        {
            return "Navn:\t\t" + Navn + "\nSlags:\t\t" + Slags + "\nProcenten:\t" + Math.Round(Procent, 2) + "\nVolume:\t\t" + Volume + "cl" + "\nGenstande:\t" + Math.Round(GetUnits(this), 2) + "\n--------------------------------";
        }

    }
}