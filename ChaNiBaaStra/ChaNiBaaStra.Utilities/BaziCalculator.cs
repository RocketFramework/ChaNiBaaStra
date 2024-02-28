using System;
using System.Collections.Generic;
using System.Text;

public class BaziCalculator
{
    public enum ElementTypes
    {
        Wood = 1,
        Fire = 2,
        Earth = 3,
        Metal = 4,
        Water = 5
    }

    public enum Relationship
    {
        Generate,
        Control,
        Destroy,
        Weaken,
        NoRelation
    }



    // Define the Earthly Branches and Heavenly Stems
    private static readonly string[] EarthlyBranches = { "Zi (Rat)", "Chou (Ox)", "Yin (Tiger)", "Mao (Rabbit)", "Chen (Dragon)", "Si (Snake)", "Wu (Horse)", "Wei (Goat)", "Shen (Monkey)", "You (Rooster)", "Xu (Dog)", "Hai (Pig)" };
    private static readonly string[] HeavenlyStems = { "Jia", "Yi", "Bing", "Ding", "Wu", "Ji", "Geng", "Xin", "Ren", "Gui" };

    // Define supportive relationships
    private static readonly Dictionary<string, string[]> SupportiveElements = new Dictionary<string, string[]>
    {
        {"JiaWood", new [] {"JiaWood", "YiWood", "YinFire"}},
        {"YiWood", new [] {"JiaWood", "YiWood", "YinFire"}},
        {"YinFire", new [] {"YangFire", "YangEarth"}},
        {"YangEarth", new [] {"YinEarth", "YinMetal"}},
        {"YinMetal", new [] {"YangMetal", "YangWater"}},
        {"YangWater", new [] {"YinWater", "YinWood"}},
        {"YinWood", new [] {"YangWood", "YangFire"}}
    };

    // Define temperature adjustments
    private static readonly Dictionary<string, string[]> TemperatureAdjustments = new Dictionary<string, string[]>
    {
        {"JiaWood", new [] {"YangMetal", "YangFire"}},
        {"YiWood", new [] {"YangMetal", "YangFire"}},
        {"YinFire", new [] {"YinMetal", "YangWood"}},
        {"YangEarth", new [] {"YangWater", "YinMetal"}},
        {"YinMetal", new [] {"YangEarth", "YinWater"}},
        {"YangWater", new [] {"YangWood", "YinFire"}},
        {"YinWood", new [] {"YangFire", "YinEarth"}}
    };

    // Method to calculate the Earth Day Master
    public static string CalculateEarthDayMasterPrediction(DateTime birthDate)
    {
        int yearIndex = (birthDate.Year - 4) % 10; // Calculate Heavenly Stem index
        int yearStemIndex = yearIndex < 0 ? yearIndex + 10 : yearIndex;
        string yearStem = HeavenlyStems[yearStemIndex]; // Get Heavenly Stem for year

        // Determine Earth Day Master
        string earthDayMaster = string.Empty;
        if (yearStem == "Jia" || yearStem == "Yi") // Jia and Yi are associated with Wood
        {
            earthDayMaster = yearStem + "Wood"; // Remove space between Heavenly Stem and Element
        }
        else if (yearStem == "Bing" || yearStem == "Ding") // Bing and Ding are associated with Fire
        {
            earthDayMaster = "YinFire";
        }
        else if (yearStem == "Wu" || yearStem == "Ji") // Wu and Ji are associated with Earth
        {
            earthDayMaster = "YangEarth";
        }
        else if (yearStem == "Geng" || yearStem == "Xin") // Geng and Xin are associated with Metal
        {
            earthDayMaster = "YinMetal";
        }
        else if (yearStem == "Ren" || yearStem == "Gui") // Ren and Gui are associated with Water
        {
            earthDayMaster = "YangWater";
        }

        return ProvideInsights(earthDayMaster);
    }

    // Method to provide insights based on Earth Day Master
    // Method to provide insights based on Earth Day Master
    public static string ProvideInsights(string earthDayMaster)
    {
        earthDayMaster = earthDayMaster.Replace(" ", ""); // Remove space from Earth Day Master

        if (!SupportiveElements.ContainsKey(earthDayMaster) || !TemperatureAdjustments.ContainsKey(earthDayMaster))
        {
            return "Invalid Earth Day Master.";
        }

        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Earth Day Master: {earthDayMaster}");

        // Get the index of Earth Day Master in Heavenly Stems
        int index = Array.IndexOf(HeavenlyStems, earthDayMaster.Substring(0, earthDayMaster.Length - 4));

        // Determine the corresponding Earthly Branch
        //string earthlyBranch = EarthlyBranches[index];

        //sb.AppendLine($"Earthly Branch: {earthlyBranch}");

        // Strengths and weaknesses
        switch (earthDayMaster)
        {
            case "JiaWood":
                sb.AppendLine("Strengths: Creative, flexible, adaptable, ambitious.");
                sb.AppendLine("Weaknesses: Indecisive, prone to mood swings, can be overly competitive.");
                break;
            case "YiWood":
                sb.AppendLine("Strengths: Nurturing, supportive, intuitive, empathetic.");
                sb.AppendLine("Weaknesses: Overly sensitive, may struggle with assertiveness, indecisiveness.");
                break;
            case "YinFire":
                sb.AppendLine("Strengths: Passionate, charismatic, enthusiastic, expressive.");
                sb.AppendLine("Weaknesses: Impulsive, impatient, prone to burnout.");
                break;
            case "YangEarth":
                sb.AppendLine("Strengths: Grounded, reliable, practical, patient.");
                sb.AppendLine("Weaknesses: Stubborn, rigid, slow to adapt to change.");
                break;
            case "YinMetal":
                sb.AppendLine("Strengths: Disciplined, organized, analytical, detail-oriented.");
                sb.AppendLine("Weaknesses: Critical, rigid, may struggle with empathy.");
                break;
            case "YangWater":
                sb.AppendLine("Strengths: Intuitive, resourceful, adaptable, persuasive.");
                sb.AppendLine("Weaknesses: Moody, unpredictable, may lack follow-through.");
                break;
            default:
                sb.AppendLine("Invalid Earth Day Master.");
                break;
        }

        // Supportive elements
        sb.AppendLine($"Supportive Elements: {string.Join(", ", SupportiveElements[earthDayMaster])}");

        // Temperature adjustments
        sb.AppendLine($"Temperature Adjustments: {string.Join(", ", TemperatureAdjustments[earthDayMaster])}");

        return sb.ToString();
    }
}
/*
using System;
using System.Collections.Generic;

public enum Element
{
    YangWood,
    YinWood,
    YangFire,
    YinFire,
    YangEarth,
    YinEarth,
    YangMetal,
    YinMetal,
    YangWater,
    YinWater
}

public enum Zodiac
{
    Rat,
    Ox,
    Tiger,
    Rabbit,
    Dragon,
    Snake,
    Horse,
    Goat,
    Monkey,
    Rooster,
    Dog,
    Pig
}

public enum Relationship
{
    Generate,
    Control,
    Destroy,
    Opposite,
    NoRelation
}

public class BaziCalculator
{
    public static string CalculateEarthDayMasterPrediction(DateTime date)
    {
        int day = date.Day;
        int month = date.Month;
        Element earthDayMaster = Element.YangWood;

        switch (month)
        {
            case 1:
                if (day <= 5)
                    earthDayMaster = Element.YangEarth;
                else
                    earthDayMaster = Element.YinEarth;
                break;
            case 2:
                if (day < 4)
                    earthDayMaster = Element.YinEarth;
                else
                    earthDayMaster = Element.YangMetal;
                break;
            case 3:
                if (day < 5)
                    earthDayMaster = Element.YinMetal;
                else
                    earthDayMaster = Element.YangWater;
                break;
            case 4:
                if (day < 4)
                    earthDayMaster = Element.YangWater;
                else
                    earthDayMaster = Element.YinWater;
                break;
            case 5:
                if (day < 5)
                    earthDayMaster = Element.YinWater;
                else
                    earthDayMaster = Element.YangWood;
                break;
            case 6:
                if (day < 5)
                    earthDayMaster = Element.YangWood;
                else
                    earthDayMaster = Element.YinWood;
                break;
            case 7:
                if (day < 7)
                    earthDayMaster = Element.YinWood;
                else
                    earthDayMaster = Element.YangFire;
                break;
            case 8:
                if (day < 7)
                    earthDayMaster = Element.YangFire;
                else
                    earthDayMaster = Element.YinFire;
                break;
            case 9:
                if (day < 7)
                    earthDayMaster = Element.YinFire;
                else
                    earthDayMaster = Element.YangEarth;
                break;
            case 10:
                if (day < 8)
                    earthDayMaster = Element.YangEarth;
                else
                    earthDayMaster = Element.YinEarth;
                break;
            case 11:
                if (day < 7)
                    earthDayMaster = Element.YinEarth;
                else
                    earthDayMaster = Element.YangMetal;
                break;
            case 12:
                if (day < 7)
                    earthDayMaster = Element.YangMetal;
                else
                    earthDayMaster = Element.YangWood;
                break;
            default:
                break;
        }

        return ProvideInsights(earthDayMaster);
    }

    public static string ProvideInsights(Element earthDayMaster)
    {
        Dictionary<Element, string> elementZodiacMap = new Dictionary<Element, string>()
        {
            { Element.YangWood, "Rat" },
            { Element.YinWood, "Ox" },
            { Element.YangFire, "Tiger" },
            { Element.YinFire, "Rabbit" },
            { Element.YangEarth, "Dragon" },
            { Element.YinEarth, "Snake" },
            { Element.YangMetal, "Horse" },
            { Element.YinMetal, "Goat" },
            { Element.YangWater, "Monkey" },
            { Element.YinWater, "Rooster" }
        };

        Dictionary<Element, (string strengths, string weaknesses)> elementTraitsMap = new Dictionary<Element, (string strengths, string weaknesses)>()
        {
            { Element.YangWood, ("Adaptable, sympathetic, compassionate", "Indecisive, self-doubting, moody") },
            { Element.YinWood, ("Nurturing, intuitive, imaginative", "Overly sensitive, easily overwhelmed, lacks assertiveness") },
            { Element.YangFire, ("Passionate, energetic, charismatic", "Impulsive, impatient, prone to burnout") },
            { Element.YinFire, ("Creative, empathetic, sociable", "Inconsistent, overly dramatic, struggles with boundaries") },
            { Element.YangEarth, ("Grounded, reliable, practical", "Stubborn, resistant to change, overly cautious") },
            { Element.YinEarth, ("Organized, disciplined, loyal", "Rigid, critical, struggles with spontaneity") },
            { Element.YangMetal, ("Disciplined, analytical, ambitious", "Critical, inflexible, may struggle with empathy") },
            { Element.YinMetal, ("Determined, focused, detail-oriented", "Perfectionistic, judgmental, struggles with flexibility") },
            { Element.YangWater, ("Intuitive, wise, adaptable", "Fearful, secretive, may struggle with emotional expression") },
            { Element.YinWater, ("Empathetic, perceptive, insightful", "Overly sensitive, escapist, struggles with boundaries") }
        };

        Dictionary<Element, string> supportiveElements = new Dictionary<Element, string>()
        {
            { Element.YangWood, "Yin Metal" },
            { Element.YinWood, "Yang Metal" },
            { Element.YangFire, "Yin Metal" },
            { Element.YinFire, "Yang Metal" },
            { Element.YangEarth, "Yin Wood" },
            { Element.YinEarth, "Yang Wood" },
            { Element.YangMetal, "Yin Earth" },
            { Element.YinMetal, "Yang Earth" },
            { Element.YangWater, "Yin Fire" },
            { Element.YinWater, "Yang Fire" }
        };

        Dictionary<Element, string> temperatureAdjustments = new Dictionary<Element, string>()
        {
            { Element.YangWood, "Increase" },
            { Element.YinWood, "Decrease" },
            { Element.YangFire, "Increase" },
            { Element.YinFire, "Decrease" },
            { Element.YangEarth, "Increase" },
            { Element.YinEarth, "Decrease" },
            { Element.YangMetal, "Increase" },
            { Element.YinMetal, "Decrease" },
            { Element.YangWater, "Increase" },
            { Element.YinWater, "Decrease" }
        };

        string result = "";

        if (!elementZodiacMap.ContainsKey(earthDayMaster))
        {
            return "Invalid Earth Day Master.";
        }

        string zodiac = elementZodiacMap[earthDayMaster];
        result += $"Earth Day Master: {earthDayMaster}\r\nZodiac: {zodiac}\r\n";

        if (elementTraitsMap.ContainsKey(earthDayMaster))
        {
            var (strengths, weaknesses) = elementTraitsMap[earthDayMaster];
            result += $"Strengths: {strengths}\r\nWeaknesses: {weaknesses}";
        }


        if (supportiveElements.ContainsKey(earthDayMaster))
        {
            string supportiveElement = supportiveElements[earthDayMaster];
            result += $"Supportive Element: {supportiveElement}\r\n";
        }

        if (temperatureAdjustments.ContainsKey(earthDayMaster))
        {
            string temperatureAdjustment = temperatureAdjustments[earthDayMaster];
            result += $"Temperature Adjustment: {temperatureAdjustment}\r\n";
        }
        return result;
    }
}*/

