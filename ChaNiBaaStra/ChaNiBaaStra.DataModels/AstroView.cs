using ChaNiBaaStra.Utilities;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaNiBaaStra.DataModels
{
    public enum ViewTypes
    {
        Conjunction,
        Opposite,
        Square,
        Second,
        Third,
        Fourth,
        Sixth,
        Eigth,
        Tentth,
        Eleventh,
        Twelth,
        Triangle,
        None
    }

    public enum ViewStates
    {
        UpComing,
        Passed
    }

    public class AstroViewDetail
    {
        public AstroPlanet SourcePlanet { get; set; }
        public ViewTypes ViewType { get; set; }
        public AstroPlanet SourceCanSeeThisPlanet { get; set; }
        public double Degrees { get; set; }
        public ViewStates ViewState { get; set; }
        public DateTime ProjectedViewDate { get; set; }

    }

    public class AstroViewDetails
    {
        public List<AstroViewDetail> ISeeThemDetails { get; set; }
        public List<AstroViewDetail> TheySeeMeDetails { get; set; }
        public bool IsTransitHoroscope { get; set; }
        public List<AstroViewDetail> OtherHoroscopePlanetSeeMeDetails { get; set; }
        public List<AstroViewDetail> ISeeOtherHoroscopePlanetDetails { get; set; }
        public AstroPlanet FocusPlanet { get; set; }
        public AstroViewDetails(AstroPlanet focusPlanet)
        {
            ISeeThemDetails = new List<AstroViewDetail>();
            TheySeeMeDetails = new List<AstroViewDetail>();
            OtherHoroscopePlanetSeeMeDetails = new List<AstroViewDetail>();
            ISeeOtherHoroscopePlanetDetails = new List<AstroViewDetail>();
            IsTransitHoroscope = false;
            FocusPlanet = focusPlanet;
        }

        public AstroViewDetails(AstroPlanet focusPlanet, List<AstroPlanet> completePlanetList) : this(focusPlanet)
        {
            UpdateDetails(completePlanetList);
        }

        public void AstroTransitViewDetails(AstroPlanet focusPlanet, List<AstroPlanet> completePlanetList)
        {
            UpdateDetails(focusPlanet, completePlanetList);
        }

        public void AstroBirthViewDetails(AstroPlanet focusPlanet, List<AstroPlanet> completePlanetList)
        {
            UpdateDetails(focusPlanet, completePlanetList);
        }
        private void UpdateDetails(AstroPlanet focPlanet, List<AstroPlanet> completeOtherHoroscopePlanetList)
        {
            foreach (AstroPlanet planet in completeOtherHoroscopePlanetList)
            {
                if (focPlanet.Views.ICanSeeThem.Contains(planet.HouseNumber))
                {
                    if (focPlanet.Current != planet.Current)
                    {
                        int i = focPlanet.Rasi.absoluteHouseFromRasi(planet.Rasi.Current);
                        AstroViewDetail detail = new AstroViewDetail();
                        detail.ViewType = GetViewType(i, planet.Longitude, focPlanet.Longitude);
                        if (detail.ViewType != ViewTypes.None)
                        {
                            detail.SourceCanSeeThisPlanet = planet;
                            detail.SourcePlanet = focPlanet;
                            detail.Degrees = AstroUtility.CalculateAngularGap(planet.Longitude, focPlanet.Longitude);
                            detail.ViewState = (detail.Degrees < (i - 1) * 30) ? ViewStates.UpComing : ViewStates.Passed;
                            detail.ProjectedViewDate = DateTime.Now.AddDays(((i - 1) * 30 - detail.Degrees) * Math.Abs(planet.SpeedInLongitude - FocusPlanet.SpeedInLongitude));
                            ISeeOtherHoroscopePlanetDetails.Add(detail);
                        }
                    }
                }

                if (planet.Views.TheyCanSeeMee.Exists(x => x.HouseNumber == focPlanet.HouseNumber))
                {
                    if (focPlanet.Current != planet.Current)
                    {
                        int i = planet.Rasi.absoluteHouseFromRasi(focPlanet.Rasi.Current);
                        AstroViewDetail detail = new AstroViewDetail();
                        detail.ViewType = GetViewType(i, planet.Longitude, focPlanet.Longitude);
                        if (detail.ViewType != ViewTypes.None)
                        {
                            detail.SourceCanSeeThisPlanet = planet;
                            detail.SourcePlanet = focPlanet;
                            detail.Degrees = AstroUtility.CalculateAngularGap(planet.Longitude, focPlanet.Longitude);
                            detail.ViewState = (detail.Degrees < (i - 1) * 30) ? ViewStates.UpComing : ViewStates.Passed;
                            detail.ProjectedViewDate = DateTime.Now.AddDays(((i - 1) * 30 - detail.Degrees) * Math.Abs(planet.SpeedInLongitude - FocusPlanet.SpeedInLongitude));
                            OtherHoroscopePlanetSeeMeDetails.Add(detail);
                        }
                    }
                }
            }
        }

        private void UpdateDetails(List<AstroPlanet> completePlanetList)
        {
            foreach (AstroPlanet planet in completePlanetList)
            {
                if (FocusPlanet.Views.ICanSeeThem.Contains(planet.HouseNumber))
                {
                    if (FocusPlanet.Current != planet.Current)
                    {
                        int i = FocusPlanet.Rasi.absoluteHouseFromRasi(planet.Rasi.Current);
                        AstroViewDetail detail = new AstroViewDetail();
                        detail.ViewType = GetViewType(i, planet.Longitude, FocusPlanet.Longitude);
                        if (detail.ViewType != ViewTypes.None)
                        {
                            detail.SourceCanSeeThisPlanet = planet;
                            detail.SourcePlanet = FocusPlanet;
                            detail.Degrees = AstroUtility.CalculateAngularGap(planet.Longitude, FocusPlanet.Longitude);
                            detail.ViewState = (detail.Degrees < (i - 1) * 30) ? ViewStates.UpComing : ViewStates.Passed;
                            detail.ProjectedViewDate = DateTime.Now.AddDays(((i - 1) * 30 - detail.Degrees) * Math.Abs(planet.SpeedInLongitude - FocusPlanet.SpeedInLongitude));
                            ISeeThemDetails.Add(detail);
                        }
                    }
                }

                if (planet.Views.TheyCanSeeMee.Exists(x => x.HouseNumber == FocusPlanet.HouseNumber))
                {
                    if (FocusPlanet.Current != planet.Current)
                    {
                        int i = planet.Rasi.absoluteHouseFromRasi(FocusPlanet.Rasi.Current);
                        AstroViewDetail detail = new AstroViewDetail();
                        detail.ViewType = GetViewType(i, planet.Longitude, FocusPlanet.Longitude);
                        if (detail.ViewType != ViewTypes.None)
                        {
                            detail.SourceCanSeeThisPlanet = planet;
                            detail.SourcePlanet = FocusPlanet;
                            detail.Degrees = AstroUtility.CalculateAngularGap(planet.Longitude, FocusPlanet.Longitude);
                            detail.ViewState = (detail.Degrees < (i - 1) * 30) ? ViewStates.UpComing : ViewStates.Passed;
                            detail.ProjectedViewDate = DateTime.Now.AddDays(((i - 1) * 30 - detail.Degrees) * Math.Abs(planet.SpeedInLongitude - FocusPlanet.SpeedInLongitude));
                            TheySeeMeDetails.Add(detail);
                        }
                    }
                }
            }
        }

        private ViewTypes GetViewType(int houseGap, double longitude1, double longitude2)
        {
            double debgreeGap = AstroUtility.CalculateAngularGap(longitude1, longitude2);
            switch (houseGap)
            {
                case 1: return (0 <= debgreeGap && debgreeGap <= 15) ? ViewTypes.Conjunction : ViewTypes.None;
                case 2: return (15 <= debgreeGap && debgreeGap <= 45) ? ViewTypes.Second : ViewTypes.None;
                case 3: return (45 <= debgreeGap && debgreeGap <= 75) ? ViewTypes.Third : ViewTypes.None;
                case 4: return (75 <= debgreeGap && debgreeGap <= 105) ? ViewTypes.Fourth : ViewTypes.None;
                case 5: return (105 <= debgreeGap && debgreeGap <= 135) ? ViewTypes.Triangle : ViewTypes.None;
                case 6: return (135 <= debgreeGap && debgreeGap <= 165) ? ViewTypes.Sixth : ViewTypes.None;
                case 7: return (165 <= debgreeGap && debgreeGap <= 195) ? ViewTypes.Opposite : ViewTypes.None;
                case 8: return (195 <= debgreeGap && debgreeGap <= 225) ? ViewTypes.Eigth : ViewTypes.None;
                case 9: return (225 <= debgreeGap && debgreeGap <= 255) ? ViewTypes.Triangle : ViewTypes.None;
                case 10: return (255 <= debgreeGap && debgreeGap <= 255) ? ViewTypes.Tentth : ViewTypes.None;
                case 11: return (255 <= debgreeGap && debgreeGap <= 285) ? ViewTypes.Eleventh : ViewTypes.None;
                case 12: return (285 <= debgreeGap && debgreeGap <= 315) ? ViewTypes.Twelth : ViewTypes.None;
            }
            return ViewTypes.None;
        }
    }
    public class AstroView
    {
        public enum EnumViewStrengths
        {
            VeryGood,
            Good,
            Bad,
            VeryBad
        }
        private AstroUtility utility = new AstroUtility();

        public List<int> ICanSeeThem { get; set; }
        public List<AstroPlanet> TheyCanSeeMee { get; set; }
        public List<int> SeeRashiHouses { get; set; }
        public List<int> SeeBhavaHouses { get; set; }
        public AstroView(AstroPlanet planet)
        {
            ICanSeeThem = new List<int>();
            TheyCanSeeMee = new List<AstroPlanet>();
            SeeBhavaHouses = new List<int>();
            UpdateForViews(planet);
        }

        public static bool CanPlanetSeeThisRashiHouse(EnumPlanet planet, int planetInHouse, int toSeeHouse)
        {
            return GetHouses_ForPlanetBe_ToSeeThisHouse(planet, toSeeHouse).Contains(planetInHouse);
        }

        public static List<int> GetHouses_ForPlanetBe_ToSeeThisHouse(EnumPlanet planet, int toSeeHouse)
        {
            int i, j, k, l;
            switch (planet)
            {
                case EnumPlanet.Sun:
                case EnumPlanet.Moon:
                    {
                        i = AstroUtility.AstroCycleDecreaseNew(toSeeHouse, 3);
                        j = AstroUtility.AstroCycleDecreaseNew(toSeeHouse, 9);
                        k = AstroUtility.AstroCycleDecreaseNew(toSeeHouse, 7);

                        return new List<int> { i, j, k };
                    }
                case EnumPlanet.Saturn:
                    {
                        i = AstroUtility.AstroCycleDecreaseNew(toSeeHouse, 3);
                        j = AstroUtility.AstroCycleDecreaseNew(toSeeHouse, 7);
                        k = AstroUtility.AstroCycleDecreaseNew(toSeeHouse, 10);

                        return new List<int> { i, j, k };
                    }
                case EnumPlanet.Mars:
                case EnumPlanet.Mercury:
                    {
                        i = AstroUtility.AstroCycleDecreaseNew(toSeeHouse, 4);
                        j = AstroUtility.AstroCycleDecreaseNew(toSeeHouse, 8);
                        k = AstroUtility.AstroCycleDecreaseNew(toSeeHouse, 7);

                        return new List<int> { i, j, k };
                    }
                case EnumPlanet.Jupiter:
                case EnumPlanet.Venus:
                    {
                        i = AstroUtility.AstroCycleDecreaseNew(toSeeHouse, 5);
                        j = AstroUtility.AstroCycleDecreaseNew(toSeeHouse, 9);
                        k = AstroUtility.AstroCycleDecreaseNew(toSeeHouse, 7);

                        return new List<int> { i, j, k };
                    }
                case EnumPlanet.Rahu:
                case EnumPlanet.Kethu:
                    {
                        i = AstroUtility.AstroCycleDecreaseNew(toSeeHouse, 5);
                        j = AstroUtility.AstroCycleDecreaseNew(toSeeHouse, 9);
                        k = AstroUtility.AstroCycleDecreaseNew(toSeeHouse, 7);
                        l = AstroUtility.AstroCycleDecreaseNew(toSeeHouse, 12);

                        return new List<int> { i, j, k, l };
                    }
                case EnumPlanet.Pluto:
                case EnumPlanet.Neptune:
                case EnumPlanet.Uranus:
                    return new List<int> { AstroUtility.AstroCycleDecreaseNew(toSeeHouse, 7) };
            }
            return new List<int>();
        }

        public static List<int> GetAllHousesPlanetSee(EnumPlanet planet, int planetHouse)
        {
            int i, j, k, l;
            switch (planet)
            {
                case EnumPlanet.Sun:
                case EnumPlanet.Moon:
                    {
                        i = AstroUtility.AstroCycleIncreaseNew(planetHouse, 3);
                        j = AstroUtility.AstroCycleIncreaseNew(planetHouse, 9);
                        k = AstroUtility.AstroCycleIncreaseNew(planetHouse, 7);

                        return new List<int> { i, j, k }.OrderBy(x => x).ToList();
                    }
                case EnumPlanet.Saturn:
                    {
                        i = AstroUtility.AstroCycleIncreaseNew(planetHouse, 3);
                        j = AstroUtility.AstroCycleIncreaseNew(planetHouse, 7);
                        k = AstroUtility.AstroCycleIncreaseNew(planetHouse, 10);

                        return new List<int> { i, j, k }.OrderBy(x => x).ToList();
                    }
                case EnumPlanet.Mars:
                case EnumPlanet.Mercury:
                    {
                        i = AstroUtility.AstroCycleIncreaseNew(planetHouse, 4);
                        j = AstroUtility.AstroCycleIncreaseNew(planetHouse, 8);
                        k = AstroUtility.AstroCycleIncreaseNew(planetHouse, 7);

                        return new List<int> { i, j, k }.OrderBy(x => x).ToList();
                    }
                case EnumPlanet.Jupiter:
                case EnumPlanet.Venus:
                    {
                        i = AstroUtility.AstroCycleIncreaseNew(planetHouse, 5);
                        j = AstroUtility.AstroCycleIncreaseNew(planetHouse, 9);
                        k = AstroUtility.AstroCycleIncreaseNew(planetHouse, 7);

                        return new List<int> { i, j, k }.OrderBy(x => x).ToList();
                    }
                case EnumPlanet.Rahu:
                case EnumPlanet.Kethu:
                    {
                        i = AstroUtility.AstroCycleIncreaseNew(planetHouse, 5);
                        j = AstroUtility.AstroCycleIncreaseNew(planetHouse, 9);
                        k = AstroUtility.AstroCycleIncreaseNew(planetHouse, 7);
                        l = AstroUtility.AstroCycleIncreaseNew(planetHouse, 12);

                        return new List<int> { i, j, k, l }.OrderBy(x => x).ToList();
                    }
                case EnumPlanet.Pluto:
                case EnumPlanet.Neptune:
                case EnumPlanet.Uranus:
                    return new List<int> { AstroUtility.AstroCycleIncreaseNew(planetHouse, 7) };
            }
            return new List<int>();
        }

        private void UpdateForViews(AstroPlanet planet)
        {
            int i, j, k, l;
            switch (planet.Current)
            {
                case EnumPlanet.Sun:
                case EnumPlanet.Moon:
                    {
                        i = AstroUtility.AstroCycleIncreaseNew(planet.HouseNumber, 3);
                        j = AstroUtility.AstroCycleIncreaseNew(planet.HouseNumber, 9);
                        k = AstroUtility.AstroCycleIncreaseNew(planet.HouseNumber, 7);

                        ICanSeeThem = new List<int> { i, j, k };

                        i = AstroUtility.AstroCycleIncreaseNew(planet.Bhava.BhavaNumber, 3);
                        j = AstroUtility.AstroCycleIncreaseNew(planet.Bhava.BhavaNumber, 9);
                        k = AstroUtility.AstroCycleIncreaseNew(planet.Bhava.BhavaNumber, 7);

                        SeeBhavaHouses = new List<int> { i, j, k };
                        break;
                    }
                case EnumPlanet.Saturn:
                    {
                        i = AstroUtility.AstroCycleIncreaseNew(planet.HouseNumber, 3);
                        j = AstroUtility.AstroCycleIncreaseNew(planet.HouseNumber, 7);
                        k = AstroUtility.AstroCycleIncreaseNew(planet.HouseNumber, 10);

                        ICanSeeThem = new List<int> { i, j, k };

                        i = AstroUtility.AstroCycleIncreaseNew(planet.Bhava.BhavaNumber, 3);
                        j = AstroUtility.AstroCycleIncreaseNew(planet.Bhava.BhavaNumber, 7);
                        k = AstroUtility.AstroCycleIncreaseNew(planet.Bhava.BhavaNumber, 10);

                        SeeBhavaHouses = new List<int> { i, j, k };
                        break;
                    }
                case EnumPlanet.Mars:
                case EnumPlanet.Mercury:
                    {
                        i = AstroUtility.AstroCycleIncreaseNew(planet.HouseNumber, 4);
                        j = AstroUtility.AstroCycleIncreaseNew(planet.HouseNumber, 8);
                        k = AstroUtility.AstroCycleIncreaseNew(planet.HouseNumber, 7);

                        ICanSeeThem = new List<int> { i, j, k };

                        i = AstroUtility.AstroCycleIncreaseNew(planet.Bhava.BhavaNumber, 4);
                        j = AstroUtility.AstroCycleIncreaseNew(planet.Bhava.BhavaNumber, 8);
                        k = AstroUtility.AstroCycleIncreaseNew(planet.Bhava.BhavaNumber, 7);

                        SeeBhavaHouses = new List<int> { i, j, k };
                        break;
                    }
                case EnumPlanet.Jupiter:
                case EnumPlanet.Venus:
                    {
                        i = AstroUtility.AstroCycleIncreaseNew(planet.HouseNumber, 5);
                        j = AstroUtility.AstroCycleIncreaseNew(planet.HouseNumber, 9);
                        k = AstroUtility.AstroCycleIncreaseNew(planet.HouseNumber, 7);

                        ICanSeeThem = new List<int> { i, j, k };

                        i = AstroUtility.AstroCycleIncreaseNew(planet.Bhava.BhavaNumber, 5);
                        j = AstroUtility.AstroCycleIncreaseNew(planet.Bhava.BhavaNumber, 9);
                        k = AstroUtility.AstroCycleIncreaseNew(planet.Bhava.BhavaNumber, 7);

                        SeeBhavaHouses = new List<int> { i, j, k };
                        break;
                    }
                case EnumPlanet.Rahu:
                case EnumPlanet.Kethu:
                    {
                        i = AstroUtility.AstroCycleIncreaseNew(planet.HouseNumber, 5);
                        j = AstroUtility.AstroCycleIncreaseNew(planet.HouseNumber, 9);
                        k = AstroUtility.AstroCycleIncreaseNew(planet.HouseNumber, 7);
                        l = AstroUtility.AstroCycleIncreaseNew(planet.HouseNumber, 12);

                        ICanSeeThem = new List<int> { i, j, k, l };

                        i = AstroUtility.AstroCycleIncreaseNew(planet.Bhava.BhavaNumber, 5);
                        j = AstroUtility.AstroCycleIncreaseNew(planet.Bhava.BhavaNumber, 9);
                        k = AstroUtility.AstroCycleIncreaseNew(planet.Bhava.BhavaNumber, 7);
                        l = AstroUtility.AstroCycleIncreaseNew(planet.Bhava.BhavaNumber, 12);

                        SeeBhavaHouses = new List<int> { i, j, k, l };
                        break;
                    }
                case EnumPlanet.Pluto:
                case EnumPlanet.Neptune:
                case EnumPlanet.Uranus:
                    ICanSeeThem = new List<int> { AstroUtility.AstroCycleIncreaseNew(planet.HouseNumber, 7) };
                    break;
            }
        }
    }
}
