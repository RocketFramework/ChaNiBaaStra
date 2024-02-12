using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaNiBaaStra.DataModels
{
    public abstract class ChartBase
    {
        public ChartBase(Horoscope horoscope) { Planets = new List<AstroPlanet>(); }
        public AstroRasi OriginalRagnaRashi { get; set; }
        public AstroRasi CurrentLagnaRashi { get; set; }
        public List<AstroPlanet> Planets { get; set; }
        public House House1 { get; set; }
        public House House2 { get; set; }
        public House House3 { get; set; }
        public House House4 { get; set; }
        public House House5 { get; set; }
        public House House6 { get; set; }
        public House House7 { get; set; }
        public House House8 { get; set; }
        public House House9 { get; set; }
        public House House10 { get; set; }
        public House House11 { get; set; }
        public House House12 { get; set; }
        public AstroPlanet GetLoard(EnumRasi rasi)
        {
            switch (rasi)
            {
                case EnumRasi.Mesha: return Planets.FirstOrDefault(x => x.Current == EnumPlanet.Mars);
                case EnumRasi.Vrishabha: return Planets.FirstOrDefault(x => x.Current == EnumPlanet.Venus);
                case EnumRasi.Mithuna: return Planets.FirstOrDefault(x => x.Current == EnumPlanet.Mercury);
                case EnumRasi.Kataka: return Planets.FirstOrDefault(x => x.Current == EnumPlanet.Moon);
                case EnumRasi.Simha: return Planets.FirstOrDefault(x => x.Current == EnumPlanet.Sun);
                case EnumRasi.Kanya: return Planets.FirstOrDefault(x => x.Current == EnumPlanet.Mercury);
                case EnumRasi.Thula: return Planets.FirstOrDefault(x => x.Current == EnumPlanet.Venus);
                case EnumRasi.Vrichika: return Planets.FirstOrDefault(x => x.Current == EnumPlanet.Mars);
                case EnumRasi.Dhanus: return Planets.FirstOrDefault(x => x.Current == EnumPlanet.Jupiter);
                case EnumRasi.Makara: return Planets.FirstOrDefault(x => x.Current == EnumPlanet.Saturn);
                case EnumRasi.Kumbha: return Planets.FirstOrDefault(x => x.Current == EnumPlanet.Saturn);
                case EnumRasi.Meena: return Planets.FirstOrDefault(x => x.Current == EnumPlanet.Jupiter);
            }
            return null;
        }
    }

    public class House
    {
        public ChartBase ChartBase { get; set; }
        public House(AstroRasi houseRasi, List<AstroPlanet> housePlanets)
        {
            HouseRasi = houseRasi;
            if (HousePlanets != null && HousePlanets.Count > 0)
                HousePlanets.AddRange(housePlanets);
            else
                HousePlanets = housePlanets;
        }

        public House(AstroRasi houseRashi, ChartBase cBase)
        {
            HouseRasi = houseRashi;
            HousePlanets = new List<AstroPlanet>();
            ChartBase = cBase;
        }
        public AstroRasi HouseRasi { get; set; }
        public List<AstroPlanet> HousePlanets { get; set; }
        public AstroPlanet Loard
        {
            get { return ChartBase.GetLoard(HouseRasi.Current); }
        }
    }

    public class D9Chart: ChartBase
    {
        public D9Chart(Horoscope horoscope) : base(horoscope)
        {
            int gap = horoscope.LagnaRasi.ofRasi(horoscope.NavamsaRasi.Current - 1);
            this.CurrentLagnaRashi = horoscope.NavamsaRasi;          
            Intialize();
            // Get the original lagna
            this.OriginalRagnaRashi = horoscope.LagnaRasi;
            // Now the lagan becoem the current rashi
            // it could be Kataka where as orginal lagna could be Kanya
            // Now if I want to make Kataka the lagna and then each planet posistion according to their 
            // Nawamsa rashi
            // I have to loop through each planet and then take its Nawamsa and calculate the house position 
            // base on the kataka to planet nawamsa count before the house
            foreach (AstroPlanet planet in horoscope.CompletePlanetList)
            {
                int house = horoscope.NavamsaRasi.absoluteHouseFromRasi(planet.NawamsaRasi.Current);
                planet.CurrentlyActiveRashi = planet.NawamsaRasi;
                planet.CurrentlyActiveHouseNumber = house;

                planet.GenericUpdateAdhipathis();
                this.Planets.Add(planet);

                switch (house)
                {
                    case 1:
                        if (House1 == null)
                            House1 = new House(planet.NawamsaRasi, new List<AstroPlanet> { planet });
                        else
                            House1.HousePlanets.Add(planet);
                        break;
                    case 2:
                        if (House2 == null)
                            House2 = new House(planet.NawamsaRasi, new List<AstroPlanet> { planet });
                        else
                            House2.HousePlanets.Add(planet);
                        break;
                    case 3:
                        if (House3 == null)
                            House3 = new House(planet.NawamsaRasi, new List<AstroPlanet> { planet });
                        else
                            House3.HousePlanets.Add(planet);
                        break;
                    case 4:
                        if (House4 == null)
                            House4 = new House(planet.NawamsaRasi, new List<AstroPlanet> { planet });
                        else
                            House4.HousePlanets.Add(planet);
                        break;
                    case 5:
                        if (House5 == null)
                            House5 = new House(planet.NawamsaRasi, new List<AstroPlanet> { planet });
                        else
                            House5.HousePlanets.Add(planet);
                        break;
                    case 6:
                        if (House6 == null)
                            House6 = new House(planet.NawamsaRasi, new List<AstroPlanet> { planet });
                        else
                            House6.HousePlanets.Add(planet);
                        break;
                    case 7:
                        if (House7 == null)
                            House7 = new House(planet.NawamsaRasi, new List<AstroPlanet> { planet });
                        else
                            House7.HousePlanets.Add(planet);
                        break;
                    case 8:
                        if (House8 == null)
                            House8 = new House(planet.NawamsaRasi, new List<AstroPlanet> { planet });
                        else
                            House8.HousePlanets.Add(planet);
                        break;
                    case 9:
                        if (House9 == null)
                            House9 = new House(planet.NawamsaRasi, new List<AstroPlanet> { planet });
                        else
                            House9.HousePlanets.Add(planet);
                        break;
                    case 10:
                        if (House10 == null)
                            House10 = new House(planet.NawamsaRasi, new List<AstroPlanet> { planet });
                        else
                            House10.HousePlanets.Add(planet);
                        break;
                    case 11:
                        if (House11 == null)
                            House11 = new House(planet.NawamsaRasi, new List<AstroPlanet> { planet });
                        else
                            House11.HousePlanets.Add(planet);
                        break;
                    case 12:
                        if (House12 == null)
                            House12 = new House(planet.NawamsaRasi, new List<AstroPlanet> { planet });
                        else
                            House12.HousePlanets.Add(planet);
                        break;
                }
            }
            /*
            int h1 = horoscope.NavamsaRasi.absoluteHouseFromRasi(horoscope.RasiHouseList.FirstOrDefault(y => y.HouseNumber == 1).Current);
            House1 = new House(horoscope.RasiHouseList.FirstOrDefault(x => x.HouseNumber == h1), horoscope.RasiHouseList.FirstOrDefault(x => x.HouseNumber == h1).Planets);
            int h2 = horoscope.NavamsaRasi.absoluteHouseFromRasi(horoscope.RasiHouseList.FirstOrDefault(y => y.HouseNumber == 2).Current);
            House2 = new House(horoscope.RasiHouseList.FirstOrDefault(x => x.HouseNumber == h2), horoscope.RasiHouseList.FirstOrDefault(x => x.HouseNumber == h2).Planets);
            int h3 = horoscope.NavamsaRasi.absoluteHouseFromRasi(horoscope.RasiHouseList.FirstOrDefault(y => y.HouseNumber == 3).Current);
            House3 = new House(horoscope.RasiHouseList.FirstOrDefault(x => x.HouseNumber == h3), horoscope.RasiHouseList.FirstOrDefault(x => x.HouseNumber == h3).Planets);
            int h4 = horoscope.RasiHouseList.FirstOrDefault(y => y.HouseNumber == 4).absoluteHouseFromRasi(horoscope.NavamsaRasi.Current);
            House4 = new House(horoscope.RasiHouseList.FirstOrDefault(x => x.HouseNumber == h4), horoscope.RasiHouseList.FirstOrDefault(x => x.HouseNumber == h4).Planets);
            int h5 = horoscope.RasiHouseList.FirstOrDefault(y => y.HouseNumber == 5).absoluteHouseFromRasi(horoscope.NavamsaRasi.Current);
            House5 = new House(horoscope.RasiHouseList.FirstOrDefault(x => x.HouseNumber == h5), horoscope.RasiHouseList.FirstOrDefault(x => x.HouseNumber == h5).Planets);
            int h6 = horoscope.RasiHouseList.FirstOrDefault(y => y.HouseNumber == 6).absoluteHouseFromRasi(horoscope.NavamsaRasi.Current);
            House6 = new House(horoscope.RasiHouseList.FirstOrDefault(x => x.HouseNumber == h6), horoscope.RasiHouseList.FirstOrDefault(x => x.HouseNumber == h6).Planets);
            int h7 = horoscope.RasiHouseList.FirstOrDefault(y => y.HouseNumber == 7).absoluteHouseFromRasi(horoscope.NavamsaRasi.Current);
            House7 = new House(horoscope.RasiHouseList.FirstOrDefault(x => x.HouseNumber == h7), horoscope.RasiHouseList.FirstOrDefault(x => x.HouseNumber == h7).Planets);
            int h8 = horoscope.RasiHouseList.FirstOrDefault(y => y.HouseNumber == 8).absoluteHouseFromRasi(horoscope.NavamsaRasi.Current);
            House8 = new House(horoscope.RasiHouseList.FirstOrDefault(x => x.HouseNumber == h8), horoscope.RasiHouseList.FirstOrDefault(x => x.HouseNumber == h8).Planets);
            int h9 = horoscope.RasiHouseList.FirstOrDefault(y => y.HouseNumber == 9).absoluteHouseFromRasi(horoscope.NavamsaRasi.Current);
            House9 = new House(horoscope.RasiHouseList.FirstOrDefault(x => x.HouseNumber == h9), horoscope.RasiHouseList.FirstOrDefault(x => x.HouseNumber == h9).Planets);
            int h10 = horoscope.RasiHouseList.FirstOrDefault(y => y.HouseNumber == 10).absoluteHouseFromRasi(horoscope.NavamsaRasi.Current);
            House10 = new House(horoscope.RasiHouseList.FirstOrDefault(x => x.HouseNumber == h10), horoscope.RasiHouseList.FirstOrDefault(x => x.HouseNumber == h10).Planets);
            int h11 = horoscope.RasiHouseList.FirstOrDefault(y => y.HouseNumber == 11).absoluteHouseFromRasi(horoscope.NavamsaRasi.Current);
            House11 = new House(horoscope.RasiHouseList.FirstOrDefault(x => x.HouseNumber == h11), horoscope.RasiHouseList.FirstOrDefault(x => x.HouseNumber == h11).Planets);
            int h12 = horoscope.RasiHouseList.FirstOrDefault(y => y.HouseNumber == 12).absoluteHouseFromRasi(horoscope.NavamsaRasi.Current);
            House12 = new House(horoscope.RasiHouseList.FirstOrDefault(x => x.HouseNumber == h12), horoscope.RasiHouseList.FirstOrDefault(x => x.HouseNumber == h12).Planets);*/
        }

        private void Intialize()
        {
            House1 = new House(CurrentLagnaRashi, this);
            EnumRasi activeRasi = House1.HouseRasi.next();
            House2 = new House(new AstroRasi(activeRasi), this);
            activeRasi = House2.HouseRasi.next();
            House3 = new House(new AstroRasi(activeRasi), this);
            activeRasi = House3.HouseRasi.next();
            House4 = new House(new AstroRasi(activeRasi), this);
            activeRasi = House4.HouseRasi.next();
            House5 = new House(new AstroRasi(activeRasi), this);
            activeRasi = House5.HouseRasi.next();
            House6 = new House(new AstroRasi(activeRasi), this);
            activeRasi = House6.HouseRasi.next();
            House7 = new House(new AstroRasi(activeRasi), this);
            activeRasi = House7.HouseRasi.next();
            House8 = new House(new AstroRasi(activeRasi), this);
            activeRasi = House8.HouseRasi.next();
            House9 = new House(new AstroRasi(activeRasi), this);
            activeRasi = House9.HouseRasi.next();
            House10 = new House(new AstroRasi(activeRasi), this);
            activeRasi = House10.HouseRasi.next();
            House11 = new House(new AstroRasi(activeRasi), this);
            activeRasi = House11.HouseRasi.next();
            House12 = new House(new AstroRasi(activeRasi), this);
        }
    }
}
