using System;
using System.Collections.Generic;

namespace Prog3_Scheepvaart
{
    abstract class Schip
    {
        public double Lengte { get; set;  }
        public double Breedte { get; set; }
        public double Tonnage { get; set; }
        public string Naam { get; set; }
        public Vloot Vloot { get; set; }
        public virtual void Overzicht()
        {
            Console.WriteLine("Naam: " + Naam.ToString() + "\nLengte: " + Lengte.ToString() + "\nBreedte: " + Breedte.ToString() + "\nTonnage: " + Tonnage.ToString());
        }
    }

    class Containerschip : Schip
    {
        public int AantalContainers { get; set; }
        public decimal Cargowaarde { get; set; }
        public override void Overzicht() //alternatief: via delegates string toevoegen
        {
            Console.WriteLine("Naam: " + Naam.ToString() + "\nLengte: " + Lengte.ToString() + "\nBreedte: " + Breedte.ToString() + "\nTonnage: " + Tonnage.ToString()
                + "\nAantal Containers: " + AantalContainers.ToString() + "\nCargowaarde: " + Cargowaarde.ToString());
        }
    }

    class RoRoschip : Schip
    {
        public int AantalAutos { get; set; }
        public int AantalTrucks { get; set; }
        public decimal Cargowaarde { get; set; }
        public override void Overzicht()
        {
            Console.WriteLine("Naam: " + Naam.ToString() + "\nLengte: " + Lengte.ToString() + "\nBreedte: " + Breedte.ToString() + "\nTonnage: " + Tonnage.ToString()
                + "\nAantal Autos: " + AantalAutos.ToString() + "\nAantal Trucks: " + AantalTrucks.ToString());
        }
    }

    class Cruiseschip : Schip
    {
        public int AantalPassagiers { get; set; }
        public List<string> Traject = new List<string>(2); //traject 2 havens
        public override void Overzicht()
        {
            Console.WriteLine("Naam: " + Naam.ToString() + "\nLengte: " + Lengte.ToString() + "\nBreedte: " + Breedte.ToString() + "\nTonnage: " + Tonnage.ToString()
                + "\nAantal Passagiers: " + AantalPassagiers.ToString() + "\nTraject: " + Traject[0] + "naar" + Traject[1]);
        }
    }

    class Veerboot : Schip 
    {
        public int AantalPassagiers { get; set; }
        public List<string> Traject = new List<string>(); //traject kan vele havens hebben. volgorde van belang
        public override void Overzicht()
        {
            Console.WriteLine("Naam: " + Naam.ToString() + "\nLengte: " + Lengte.ToString() + "\nBreedte: " + Breedte.ToString() + "\nTonnage: " + Tonnage.ToString()
                + "\nAantal Passagiers: " + AantalPassagiers.ToString() + "\nTraject: ");
            foreach (string haven in Traject) 
            {
                Console.Write(haven + " ");
            }
        }
    }

    class Olietanker : Schip
    {
        public decimal Cargowaarde { get; set; }
        public double Volume { get; set; }
        public LadingOlie Lading { get; set; }
        public override void Overzicht()
        {
            Console.WriteLine("Naam: " + Naam.ToString() + "\nLengte: " + Lengte.ToString() + "\nBreedte: " + Breedte.ToString() + "\nTonnage: " + Tonnage.ToString()
                + "\nCargowaarde: " + Cargowaarde.ToString() + "\nVolume: " + Volume.ToString() + "\nLading: " + Lading.ToString());
        }
    }

    class Gastanker : Schip
    {

        public decimal Cargowaarde { get; set; }
        public double Volume { get; set; }
        public LadingGas Lading { get; set; }
        public override void Overzicht()
        {
            Console.WriteLine("Naam: " + Naam.ToString() + "\nLengte: " + Lengte.ToString() + "\nBreedte: " + Breedte.ToString() + "\nTonnage: " + Tonnage.ToString()
                + "\nCargowaarde: " + Cargowaarde.ToString() + "\nVolume: " + Volume.ToString() + "\nLading: " + Lading.ToString());
        }
    }

    class Sleepboot : Schip { }
}