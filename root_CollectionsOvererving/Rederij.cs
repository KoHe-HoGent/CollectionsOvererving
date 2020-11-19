using System;
using System.Collections.Generic;

namespace Prog3_Scheepvaart
{
    class Rederij
    {
        //rederij. naam
        public string Naam { get; set; }

        //rederij. dictionary
        private Dictionary<string, Vloot> Vloten = new Dictionary<string, Vloot>();

        //rederij. toevoegen op basis naam (elk mag 1 keer voorkomen)
        public void VoegToe(Vloot vloot)
        {
            if (!Vloten.ContainsKey(vloot.Naam))
            {
                Vloten.Add(vloot.Naam, vloot);
            }
        }

        //rederij. verwijderen op basis naam
        public void VerwijderVloot(string vlootNaam)
        {
            if (Vloten.ContainsKey(vlootNaam))
            {
                Vloten.Remove(vlootNaam);
            }
        }

        //rederij. opzoekfunctie
        public Vloot ZoekVloot(string VlootNaam)
        {
            if (Vloten.TryGetValue(VlootNaam, out Vloot vloot))
            {
                return vloot;
            }
            else { return null; }
        }

        //rederij. boot in rederij op basis van naam
        public Schip ZoekSchipInRederij(string SchipNaam) //kan niet via zoekmethod van vloot, want dan returnt het meteen null na eerste value te bekijken
        {
            foreach (Vloot vloot in Vloten.Values) //alle vloten in dictionary
            {
                Schip schip; //declareer
                if ((schip = vloot.ZoekSchipInVloot(SchipNaam)) != null) //zit schipnaam in een vloot? return schip
                {
                    return schip;
                }
            }
            return null; //schip nergens gevonden
        }

        //rederij. verplaats schip naar andere vloot
        public void VerplaatsSchipInRederij(string SchipNaam, String VlootNaam)
        {
            Schip schip = ZoekSchipInRederij(SchipNaam); //methode hierboven
            if (schip != null)
            {
                Vloten[schip.Vloot.Naam].VerwijderSchipUitVloot(schip); //schip kent vloot waarin het zit, gebruik dit om de vloot het schip te laten verwijderen
                Vloten[VlootNaam].VoegSchipToeAanVloot(schip); //voeg schip nu toe aan andere vloot
                schip.Vloot = Vloten[VlootNaam]; //schip laten weten in welke vloot het nu zit (anders is dit null door VerwijderSchipUitVloot())
            }
        
        }

        //rederij. som cargowaarde
        public decimal TotaleCargowaarde()
        {
            decimal som = 0;
            foreach (Vloot vloot in Vloten.Values)
            {
                som += vloot.CargoWaarde();
            }
            return som;
        }

        //rederij. som passagiers
        public int SomPassagiers()
        {
            int som = 0;
            foreach (Vloot vloot in Vloten.Values)
            {
                som += vloot.Passagiers();
            }
            return som;
        }

        //rederij. tonnage per vloot
        public SortedDictionary<double, List<Vloot>> TonnagePerVloot()
        {
            SortedDictionary<double, List<Vloot>> tpv = new SortedDictionary<double, List<Vloot>>(); //List<Vloot> ipv Vloot want 2 vloten kunnen zelfde double tonnage hebben
            foreach (Vloot vloot in Vloten.Values) //alle vloten in een rederij
            {
                double tonnage = vloot.Tonnage(); //methode van Vloot
                if (tpv.ContainsKey(tonnage))
                {
                    tpv[tonnage].Add(vloot); //voeg toe aan dictionary
                }
                else tpv.Add(tonnage, new List<Vloot>() { vloot }); //indien nodig, maak key en list value aan
            }
            return tpv;
        }

        //overzicht sleepboten
        public void OverzichtSleepboten()
        {
            foreach (Vloot vloot in Vloten.Values) //voor elke vloot in rederij
            {
                foreach (string sleepboot in vloot.Sleepboten()) //haal sleepbotennamen op
                {
                    Console.WriteLine(sleepboot); ; //geef oplijsting van elke sleepbootnaam
                }
            }
        }

        //havens
        public List<String> lijstHavens = new List<String>();

        //havens overzicht
        public void OverzichtHavens()
        {
            Console.WriteLine("Overzicht Havens:");
            lijstHavens.Sort();
            foreach (string Haven in lijstHavens) { Console.Write(" " + Haven); }
        }

        //havens. toevoegen op basis naam (uniek)
        public void VoegHavenToe(String Haven)
        {
            if (lijstHavens.IndexOf(Haven) == -1) { lijstHavens.Add(Haven); }
        }

        //havens. verwijderen op basis naam
        public void VerwijderHaven(String Haven)
        {
            if (lijstHavens.IndexOf(Haven) == -1) { lijstHavens.Add(Haven); }
        }
    }
}