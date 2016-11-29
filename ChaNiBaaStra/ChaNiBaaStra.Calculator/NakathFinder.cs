using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChaNiBaaStra.Dal.Models;
using ChaNiBaaStra.DataModels;
using ChaNiBaaStra.Utilities;

namespace ChaNiBaaStra.Calculator
{
    public enum ResultTypes
    {
        FALSE = 0,
        TRUE = 1,
        NA = 2
    }
    public class CheckResult
    {
        public CheckResult(string description, ResultTypes result)
        {
            this.Result = result;
            Description = description;
        }

        public string Description { get; private set; }
        public ResultTypes Result { get; private set; }
    }
    public class NakathFinder
    {
        public static NakathFinderInput Input { get; set; }
        public EnumRasi[] LangnaToConsider;// = Input.LangnaToConsider;
        public EnumNakath[] NakathToConsider;// = Input.NakathToConsider;
        public EnumThithi[] ThithiToConsider;// = Input.ThithiToConsider;
        public int[] NakathNumberFromRaviNakath;// = Input.NakathNumberFromRaviNakath;
        public int[] MaleficPlanetPosition;// = Input.MaleficPlanetPosition;
        public int[] BeneficPlanetPosition;// = Input.BeneficPlanetPosition;
        public int[] EmptyHousesToConsider;// = Input.EmptyHousesToConsider;
        public bool IsNakathConsidered;// = Input.DoCheckYoga;
        public bool IsThisValidResult { get; set; }
        public string ReasonToMakeInvalid { get; set; }
        public AstroTransitDate TransitDate { get; set; }
        public AstroTransitDate BirthDate { get; set; }

        public NakathFinder(AstroTransitDate nakathDate, NakathFinderInput input)
        {
            Input = input;
            TransitDate = nakathDate;
            NakathNumberFromRaviNakath = Input.NakathNumberFromRaviNakath;
            MaleficPlanetPosition = Input.MaleficPlanetPosition;
            BeneficPlanetPosition = Input.BeneficPlanetPosition;
            EmptyHousesToConsider = Input.EmptyHousesToConsider;
            NakathToConsider = Input.NakathToConsider;
            ThithiToConsider = Input.ThithiToConsider;
            LangnaToConsider = Input.LangnaToConsider;
            IsThisValidResult = true;
        }
        public NakathFinder(AstroTransitDate nakathDate
            , AstroTransitDate birthDate, NakathFinderInput input)
            : this(nakathDate, input)
        {
            BirthDate = birthDate;
            ReasonToMakeInvalid = nakathDate.CurrentDateTime.ToShortDateString() + " : " + nakathDate.CurrentDateTime.ToShortTimeString() + "\r\n";
        }
        /// <summary>
        /// 60
        /// </summary>
        /// <returns></returns>
        public bool OtherConditionsMatched()
        {
            if (!Input.DoCheckOtherConditions) return true;

            bool result = (this.GoodNakathThithiWeekDays() == ResultTypes.TRUE
                && this.GoodThithiWeekDay() == ResultTypes.TRUE);

            if (!result)
            {
                ReasonToMakeInvalid += "-Nakath and Thithi or Thithi is not good for this Day\r\n";
                IsThisValidResult = false;
            }
            return result;
        }
        /// <summary>
        /// 100
        /// </summary>
        /// <returns></returns>
        public ResultTypes NakathGoodWithBirthNakath()
        {
            if (!Input.DoCheckNakathWithMine) return ResultTypes.TRUE;

            EnumRelationshipTypes rel = BirthDate.Nakath.RelationshipWith(TransitDate.Nakath);

            ResultTypes result = (ResultTypes)Convert.ToInt16((rel == EnumRelationshipTypes.ParamaMythree ||
                rel == EnumRelationshipTypes.Mythree ||
                rel == EnumRelationshipTypes.Sampath ||
                rel == EnumRelationshipTypes.Sadhaka ||
                rel == EnumRelationshipTypes.Janma ||
                rel == EnumRelationshipTypes.Kshema));

            if  (result == ResultTypes.FALSE)
            {
                ReasonToMakeInvalid += "-Nakath does not matched with the birth Nakath\r\n";
                IsThisValidResult = false;
            }

            return result;

        }
        /// <summary>
        /// 55
        /// </summary>
        /// <returns></returns>
        public CheckResult HasGoodYoga()
        {
            return this.GoodNakathWeekDay();
        }
        /// <summary>
        /// 60
        /// </summary>
        public bool HasPanchaSuddhi
        {
            get
            {
                if (!Input.DoCheckPanchanga) return true;  
                     
                bool result = (IsGoodDay() == ResultTypes.TRUE
                        && IsGoodKarna() == ResultTypes.TRUE
                        && IsGoodNakath() == ResultTypes.TRUE
                        && IsGoodThithi() == ResultTypes.TRUE
                        && IsGoodYoga() == ResultTypes.TRUE);
                if (!result)
                {
                    ReasonToMakeInvalid += "-Panchanga is not good\r\n";
                    IsThisValidResult = false;
                }
                return result;
            }
        }
        /// <summary>
        /// 50
        /// </summary>
        /// <returns></returns>
        public ResultTypes LagnaMatched()
        {
            ResultTypes result = (ResultTypes)((LangnaToConsider != null && LangnaToConsider.Length > 0) ?
                Convert.ToInt16(LangnaToConsider.Contains(TransitDate.Horoscope.LagnaRasi.Current)) : 3);

            if (result == ResultTypes.FALSE)
            {
                ReasonToMakeInvalid += "-Lagna does not match \r\n";
                IsThisValidResult = false;
            }
            return result;
        }
        /// <summary>
        /// 30
        /// </summary>
        /// <returns></returns>
        public CheckResult MoonIsStrong()
        {
            ResultTypes result = ResultTypes.TRUE;
            if (!Input.DoCheckMoonStength)
                return new CheckResult(string.Empty, result);

           int[] moonNotPos = new int[] { 6, 8, 12 };
            EnumRelationshipTypes rel = BirthDate.Nakath.RelationshipWith(TransitDate.Moon.Nakatha);
            if (rel == EnumRelationshipTypes.Prathyaari || rel == EnumRelationshipTypes.Vada || rel == EnumRelationshipTypes.Vipath)
            {
                IsThisValidResult = false;
                ReasonToMakeInvalid += "-Moon is not strong\r\n";
                return new CheckResult("Moon ocupy a bad Nakath", ResultTypes.FALSE);
            }
            if (moonNotPos.Contains(TransitDate.Moon.HouseNumber))
            {
                IsThisValidResult = false;
                ReasonToMakeInvalid += "-Moon is not strong\r\n";
                return new CheckResult(string.Format("Moon in {0} house of the Trasit Horoscope!", TransitDate.Moon.HouseNumber), ResultTypes.FALSE);
            }
            int moonPlace = moonNotPos.FirstOrDefault(x=> BirthDate.Horoscope.RasiHouseList[x-1].CurrentInt == TransitDate.Moon.Rasi.CurrentInt);
            if (moonPlace > 0)
            {
                IsThisValidResult = false;
                ReasonToMakeInvalid += "-Moon is not strong\r\n";
                return new CheckResult(string.Format("Moon in {0} house from the Birth Horoscope!", moonPlace), ResultTypes.FALSE);
            }
            AstroRasi moonRasi = TransitDate.Horoscope.RasiHouseList.FirstOrDefault(x => x.CurrentInt == TransitDate.Moon.Rasi.CurrentInt);
            string desc = string.Empty;
            foreach (AstroPlanet planet in moonRasi.Planets)
            {
                if (!planet.DataModel.IsGood)
                    desc += planet.Name + ", ";
            }
            if (!string.IsNullOrEmpty(desc))
            {
                IsThisValidResult = false;
                ReasonToMakeInvalid += "-Moon is not strong\r\n";
                return new CheckResult(desc.TrimEnd(',', ' ') + " with Moon", ResultTypes.FALSE);
            }
            // Ignored Bad Plant having Sapthama Drusti on Moon

            return new CheckResult(string.Empty, ResultTypes.TRUE);
        }
        /// <summary>
        /// 60
        /// </summary>
        /// <returns></returns>
        public ResultTypes NakathMatched()
        {
            ResultTypes result = (ResultTypes)((NakathToConsider != null && NakathToConsider.Length > 0) ?
                Convert.ToInt16(NakathToConsider.Contains(TransitDate.Nakath.Current)) : 2);

            if (result == ResultTypes.FALSE)
            {
                ReasonToMakeInvalid += "-Nakath does not match\r\n";
                IsThisValidResult = false;
            }
            return result;
        }
        /// <summary>
        /// 60
        /// </summary>
        /// <returns></returns>
        public ResultTypes ThithiMatched()
        {
            ResultTypes result = (ResultTypes)((ThithiToConsider != null && ThithiToConsider.Length > 0) ?
                Convert.ToInt16(ThithiToConsider.Contains(TransitDate.Thithi.Current)) : 2);

            if (result == ResultTypes.FALSE)
            {
                ReasonToMakeInvalid += "-Thithi does not match\r\n";
                IsThisValidResult = false;
            }
            return result;
        }
        /// <summary>
        /// 60
        /// </summary>
        /// <returns></returns>
        public ResultTypes NakathNumberFromRaviNakathMatched()
        {
            Mod mod27 = new Mod(27);
            int difInt = mod27.sub(TransitDate.Sun.Nakatha.CurrentInt, TransitDate.Nakath.CurrentInt);
            ResultTypes result = (ResultTypes)((NakathNumberFromRaviNakath != null 
                && NakathNumberFromRaviNakath.Length > 0) ?
                Convert.ToInt16(NakathNumberFromRaviNakath.Contains(difInt)) : 2);

            if (result == ResultTypes.FALSE)
            {
                ReasonToMakeInvalid += "-Nakath number from Sun's nakath does not match\r\n";
                IsThisValidResult = false;
            }
            return result;
        }
        /// <summary>
        /// 30
        /// </summary>
        /// <returns></returns>
        public ResultTypes EmptyHousesToConsiderMatched()
        {
            ResultTypes result = (ResultTypes)((EmptyHousesToConsider != null && EmptyHousesToConsider.Length > 0) ?
                Convert.ToInt16(!TransitDate.Horoscope.RasiHouseList.Any(x => x.Planets.Count != 0 
                && EmptyHousesToConsider.Contains(x.HouseNumber))) : 2);

            if (result == ResultTypes.FALSE)
            {
                ReasonToMakeInvalid += "-Expected empty houses are not empty\r\n";
                IsThisValidResult = false;
            }
            return result;
        }
        /// <summary>
        /// 30
        /// </summary>
        /// <returns></returns>
        public ResultTypes GoodPlanetInGoodPosition()
        {
            if (BeneficPlanetPosition != null && BeneficPlanetPosition.Length > 0)
            {
                List<AstroPlanet> goodPlanetNotInGoodPositionList = TransitDate.Horoscope.RasiPlanetList
                    .FindAll(x => x.DataModel.IsGood && !BeneficPlanetPosition.Contains(x.HouseNumber));
                ResultTypes result = (ResultTypes)Convert.ToInt16(goodPlanetNotInGoodPositionList.Count == 0);

                if (result == ResultTypes.FALSE)
                {
                    ReasonToMakeInvalid += "-Good planets are not moving on given good houses\r\n";
                    IsThisValidResult = false;
                }
                return result;
            }
            else
                return ResultTypes.TRUE;
        }
        /// <summary>
        /// 30
        /// </summary>
        /// <returns></returns>
        public ResultTypes BadPlanetInGoodPosition()
        {
            if (MaleficPlanetPosition != null && MaleficPlanetPosition.Length > 0)
            {
                List<AstroPlanet> badPlanetNotInGoodPositionList = TransitDate.Horoscope.RasiPlanetList
                .FindAll(x => !x.DataModel.IsGood && !MaleficPlanetPosition.Contains(x.HouseNumber));
                ResultTypes result = (ResultTypes)Convert.ToInt16(badPlanetNotInGoodPositionList.Count == 0);

                if (result == ResultTypes.FALSE)
                {
                    ReasonToMakeInvalid += "-Bad planets are not moving on given bad houses\r\n";
                    IsThisValidResult = false;
                }
                return result;
            }
            else
                return ResultTypes.TRUE;
        }
        /// <summary>
        /// 80
        /// </summary>
        /// <returns></returns>
        public ResultTypes GoodNakathThithiWeekDays()
        {
            int thithiId = TransitDate.Thithi.DataModel.ThithiId;
            int nakathId = TransitDate.Nakath.DataModel.NakathId;
            return (ResultTypes)Convert.ToInt16(TransitDate.WeekDay
                .DataModel.NakathThithiWeekDays
                .Any(x => x.NakathId == nakathId && x.ThithiId == thithiId && x.IsGood));
        }
        /// <summary>
        /// 60
        /// </summary>
        /// <returns></returns>
        public ResultTypes GoodThithiWeekDay()
        {
            int thithiId = TransitDate.Thithi.DataModel.ThithiId;
            return (ResultTypes)Convert
                .ToInt16(TransitDate.WeekDay.DataModel.ThithiWeekDays
                .Any(x => x.ThithiId == thithiId && x.IsGood));
        }
        /// <summary>
        /// 60
        /// </summary>
        /// <returns></returns>
        private CheckResult GoodNakathWeekDay()
        {
            if (!Input.DoCheckYoga)
                return new CheckResult(string.Empty, ResultTypes.TRUE);

            int nakathId = TransitDate.Nakath.DataModel.NakathId;
            NakathWeekDay result = TransitDate.WeekDay.DataModel.NakathWeekDays
                .FirstOrDefault(x => x.NakathId == nakathId && x.IsGood);

            if (result.IsGood)
                return new CheckResult(String.Format("Remove {0} minutes from the start!", result.BeneficCondition.MinuteToRemove)
                    , ResultTypes.TRUE);
            else
            {
                ReasonToMakeInvalid += "-Yoga is not good";
                IsThisValidResult = false;
            }

            return new CheckResult(string.Empty, ResultTypes.FALSE);
        }
        /// <summary>
        /// 60
        /// </summary>
        /// <returns></returns>
        public ResultTypes IsGoodNakath()
        {
            return (ResultTypes)Convert
                .ToInt16(TransitDate.Nakath.IsGood);
        }
        /// <summary>
        /// 30
        /// </summary>
        /// <returns></returns>
        public ResultTypes IsGoodThithi()
        {
            return (ResultTypes)Convert
                .ToInt16(TransitDate.Thithi.IsGood);
        }
        /// <summary>
        /// 30
        /// </summary>
        /// <returns></returns>
        public ResultTypes IsGoodYoga()
        {
            return (ResultTypes)Convert
                .ToInt16(TransitDate.Yoga.IsGood);
        }
        /// <summary>
        /// 30
        /// </summary>
        /// <returns></returns>
        public ResultTypes IsGoodKarna()
        {
            return (ResultTypes)Convert
                .ToInt16(TransitDate.Karna.IsGood);
        }
        /// <summary>
        /// 50
        /// </summary>
        /// <returns></returns>
        public ResultTypes IsGoodDay()
        {
            return (ResultTypes)Convert
                .ToInt16(TransitDate.WeekDay.IsGood);
        }

        public bool IsGoodForBirth()
        {
            bool test = (TransitDate.Sun.NavamsaRasi.Current == EnumRasi.Simha
                && TransitDate.Moon.NavamsaRasi.Current == EnumRasi.Kataka
                && (TransitDate.Venus.NavamsaRasi.Current == EnumRasi.Vrishabha
                || TransitDate.Venus.NavamsaRasi.Current == EnumRasi.Kanya)
                && (TransitDate.Mars.NavamsaRasi.Current == EnumRasi.Mesha
                || TransitDate.Mars.NavamsaRasi.Current == EnumRasi.Vrichika));
            if (test) return test;
            test = ((TransitDate.Jupiter.HouseNumber == 5) || (TransitDate.Jupiter.HouseNumber == 9));
            if (test) return test;
            int[] upachaya = new int[] { 3, 6, 10, 11 };
            Mod mod12 = new Mod(12);
            int dif = mod12.sub(TransitDate.Horoscope.LagnaRasi.CurrentInt, BirthDate.Horoscope.LagnaRasi.CurrentInt);//6
            test = ((upachaya.Contains(mod12.sub(TransitDate.Sun.HouseNumber, dif)) && (TransitDate.Sun.NavamsaRasi.Current == EnumRasi.Simha)) && ((TransitDate.Venus.NavamsaRasi.Current == EnumRasi.Vrishabha
                || TransitDate.Venus.NavamsaRasi.Current == EnumRasi.Kanya) && upachaya.Contains(mod12.sub(TransitDate.Venus.HouseNumber, dif))));
            if (test) return test;
            return false;
        }
        public bool IsGoodForTwinBirth()
        {
            bool test = (TransitDate.Moon.Rasi.CurrentInt.IsEven() && TransitDate.Venus.Rasi.CurrentInt.IsEven());
            if (test) return test;
            test =  (!TransitDate.Mars.Rasi.CurrentInt.IsEven() && !TransitDate.Jupiter.Rasi.CurrentInt.IsEven() && !TransitDate.Mercury.Rasi.CurrentInt.IsEven() && !TransitDate.Horoscope.LagnaRasi.CurrentInt.IsEven());
            if (test) return test;
            test = (TransitDate.Horoscope.LagnaRasi.CurrentInt.IsEven() && TransitDate.Moon.Rasi.CurrentInt.IsEven());
            if (test) return test;
            test = (TransitDate.Mars.Rasi.CurrentInt.IsEven() && TransitDate.Jupiter.Rasi.CurrentInt.IsEven() && TransitDate.Mercury.Rasi.CurrentInt.IsEven() && TransitDate.Horoscope.LagnaRasi.CurrentInt.IsEven());
            if (test) return test;
            if (!test)
                ReasonToMakeInvalid += "-Not a Twin Yoga";
            return test;
        }
    }
}
