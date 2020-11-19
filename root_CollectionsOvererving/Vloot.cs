using System;
using System.Collections.Generic;

namespace Prog3_Scheepvaart
{
    class Vloot
    {
        //vloot. naam
        public string Naam { get; set; }

        //vloot. schepen
        private Dictionary<string, Schip> Schepen = new Dictionary<string, Schip>();

        //vloot. toevoegen (elk schip mag 1 keer voorkomen)
        public void VoegSchipToeAanVloot(Schip schip)
        {
            if (!Schepen.ContainsKey(schip.Naam)) //als schipnaam nog niet in dictionary
            {
                Schepen.Add(schip.Naam, schip); //voeg schip toe
                schip.Vloot = this; //schip weet in welke vloot het zit
            }
        }

        //vloot. verwijderen op basis naam
        public void VerwijderSchipUitVloot(Schip schip)
        {
            if (Schepen.ContainsKey(schip.Naam)) //als schipnaam in dictionary
            {
                Schepen.Remove(schip.Naam); //verwijder entry
                schip.Vloot = null; //schip object bevat geen info over eigen vloot want zit niet in een vloot
            }
        }

        //vloot. opzoekfunctie
        public Schip ZoekSchipInVloot(string SchipNaam)
        {
            if (Schepen.TryGetValue(SchipNaam, out Schip Schip)) //probeer schipnaam te vinden (bool). Indien ja, geef Schip. kan ook gewoon met ContainsKey
            {
                return Schip;
            }
            else { return null; }
        }

        //vloot. overzicht
        public void Overzicht()
        {
            Console.WriteLine($"Overzicht vloot {Naam}");
            foreach (KeyValuePair<string, Schip> entry in Schepen)
            {
                entry.Value.Overzicht();
                Console.WriteLine("\n\n");
            }
        }

        //vloot. Tonnage (voor bij methode TonngePerVloot rederij)
        public double Tonnage()
        {
            double Tonnage = 0;
            foreach (Schip schip in Schepen.Values) //tel tonnage van alle schepen in dictionary op, return waarde
            {
                Tonnage += schip.Tonnage;
            }
            return Tonnage;
        }

        //vloot. passagiers in vloot
        public int Passagiers()
        {
            int passagiers = 0;
            foreach (Schip schip in Schepen.Values) //alle schepen overlopen en als er passagiers zijn, toevoegen aan totaal
            {
                if (schip is Cruiseschip) //in deze oplossing niet met meerdere overervingen gewerkt. code is minder efficiënt maar slides overkopiëren is ook niet de bedoeling
                {
                    passagiers += ((Cruiseschip)schip).AantalPassagiers;
                }
                else if (schip is Veerboot)
                {
                    passagiers += ((Veerboot)schip).AantalPassagiers;
                }
            }
            return passagiers;
        }

        public decimal CargoWaarde()
        {
            decimal cargowaarde = 0;
            foreach (Schip schip in Schepen.Values) //alle schepen overlopen. bij cargowaarde: toevoegen aan totaal
            {
                if (schip is Containerschip) //in deze oplossing niet met meerdere overervingen gewerkt. code is minder efficiënt maar slides overkopiëren is ook niet de bedoeling
                {
                    cargowaarde += ((Containerschip)schip).Cargowaarde;
                }
                else if (schip is RoRoschip)
                {
                    cargowaarde += ((RoRoschip)schip).Cargowaarde;
                }
                else if (schip is Olietanker)
                {
                    cargowaarde += ((Olietanker)schip).Cargowaarde;
                }
                else if (schip is Gastanker)
                {
                    cargowaarde += ((Gastanker)schip).Cargowaarde;
                }
            }
            return cargowaarde;
        }

        public List<string> Sleepboten() //alle sleepboten uit vloot returnen voor method OverzichtSleepboten in rederij
        {
            List<string> sleepboten = new List<string>();
            foreach (Schip schip in Schepen.Values)
            {
                if (schip is Sleepboot)
                {
                    sleepboten.Add(schip.Naam);
                }
            }
            return sleepboten;
        }
    }
}