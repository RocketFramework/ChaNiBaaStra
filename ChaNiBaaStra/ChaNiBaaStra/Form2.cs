using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChaNiBaaStra
{
    public partial class Form2 : Form
    {
        public class DataItem
        {
            public string House;
            public string Text;

            public DataItem(string house, string text)
            {
                House = house;
                Text = text;
            }
        }
        public class LordData
        {
            public string planet { get; set; }
            public string sign { get; set; }

            public List<DataItem> houseReading = new List<DataItem>();
        }
        public Form2()
        {
            InitializeComponent();
        }
        List<string> listMaster = new List<string>();
        List<LordData> listLordDatas = new List<LordData>();
        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            string code = "public string GetPrediction#HHHouseLord(EnumRasi rashi, EnumPlanet planet, int houseNumber){switch (rashi){";
            code = code.Replace("#HH", this.textBoxHouseNumber.Text);
            foreach (LordData data in listLordDatas)
            {
                string codePart = "";
                codePart += "\r\ncase EnumRasi.#sign:\r\n{\r\nswitch (planet)\r\n{\r\ncase EnumPlanet.#planet:\r\n{";
                codePart = codePart.Replace("#HH", this.textBoxHouseNumber.Text);
                codePart = codePart.Replace("#sign", data.sign);
                codePart = codePart.Replace("#planet", data.planet);
                code += codePart;
                code += "switch (houseNumber){\r\n";
                foreach (var s in data.houseReading)
                {
                    codePart = "\r\ncase #house: return \"#text\";";
                    codePart = codePart.Replace("#house", s.House);
                    codePart = codePart.Replace("#text", s.Text);
                    code += codePart;
                    codePart = "";
                }
                code += "  \r\n}\r\n}break;\r\n}break;\r\n}";
            }
            this.richTextBoxMainCode.Text = code + "\r\n}\r\nreturn \"\";}";
        }

        int h = 1;

        private void buttonAppend_Click(object sender, EventArgs e)
        {
            this.textBoxHouseNumber.Text = h.ToString();
            listMaster = new List<string>();
            if (richTextBoxMainText.Text != string.Empty)
                listMaster.AddRange(this.richTextBoxMainText.Text.Split(new char[] { '\r', '\n' }));
            foreach (string s in listMaster)
            {
                if ((s.Trim().Length > 0) && (!s.Contains("one after the other")))
                {
                    LordData data = new LordData();
                    if (s.StartsWith("Sun -"))
                    {
                        AddElement(s, data, "Sun");
                    }
                    else if (s.StartsWith("Moon -"))
                    {
                        AddElement(s, data, "Moon");
                    }
                    else if (s.StartsWith("Rahu -"))
                    {
                        AddElement(s, data, "Rahu");
                    }
                    else if (s.StartsWith("Kethu -"))
                    {
                        AddElement(s, data, "Kethu");
                    }
                    else if (s.Contains("Mars rules"))
                    {
                        AddElement(s, data, "Mars");
                    }
                    else if (s.Contains("Mercury rules"))
                    {
                        AddElement(s, data, "Mercury");
                    }
                    else if (s.Contains("Venus rules"))
                    {
                        AddElement(s, data, "Venus");
                    }
                    else if (s.Contains("Jupiter rules"))
                    {
                        AddElement(s, data, "Jupiter");
                    }
                    else if (s.Contains("Mars"))
                    {
                        AddElement(s, data, "Mars");
                    }
                    else if (s.Contains("Mercury"))
                    {
                        AddElement(s, data, "Mercury");
                    }
                    else if (s.Contains("Venus"))
                    {
                        AddElement(s, data, "Venus");
                    }
                    else if (s.Contains("Jupiter"))
                    {
                        AddElement(s, data, "Jupiter");
                    }
                    else if (s.StartsWith("In either sign"))
                    {
                        string[] twoSigns = taketwosigns(s);
                        if (listLordDatas.Exists(x => x.planet == "Saturn"))
                        {
                            LordData foundData1 = listLordDatas.Find(x => x.planet == "Saturn" && x.sign == findSignSinhala(twoSigns[0]));
                            foundData1.houseReading.Add(new DataItem(textBoxHouseNumber.Text, s));

                            LordData foundData2 = listLordDatas.Find(x => x.planet == "Saturn" && x.sign == findSignSinhala(twoSigns[1]));
                            foundData2.houseReading.Add(new DataItem(textBoxHouseNumber.Text, s));
                        }
                        else
                        {      
                            data.planet = "Saturn";
                            data.sign = findSignSinhala(twoSigns[0]);
                            data.houseReading = new List<DataItem>();
                            data.houseReading.Add(new DataItem(textBoxHouseNumber.Text, s));
                            listLordDatas.Add(data);

                            LordData data2 = new LordData();
                            data2.planet = "Saturn";
                            data2.sign = findSignSinhala(twoSigns[1]);
                            data2.houseReading = new List<DataItem>();
                            data2.houseReading.Add(new DataItem(textBoxHouseNumber.Text, s));
                            listLordDatas.Add(data2);
                        }
                    }

                }
            }

            this.richTextBoxMainText.Text = "";
            h += 1;
            this.textBoxHouseNumber.Text = h.ToString();
        }

        private void AddElement(string s, LordData data, string name)
        {
            string sign = findSign(s);
            if (listLordDatas.Exists(x => x.planet == name && x.sign == sign))
            {
                LordData foundData = listLordDatas.Find(x => x.planet == name && x.sign == sign);
                foundData.houseReading.Add(new DataItem(textBoxHouseNumber.Text, s));
            }
            else
            {
                data.planet = name;
                data.sign = sign;
                data.houseReading = new List<DataItem>();
                data.houseReading.Add(new DataItem(textBoxHouseNumber.Text, s));
                listLordDatas.Add(data);
            }
        }

        private string[] taketwosigns(string s)
        {
            // Define the regular expression pattern
            string pattern = @"\((for\s(.*?)\sAscendants\srespectively)\)";

            // Create a Regex object
            Regex regex = new Regex(pattern);

            // Find the match
            Match match = regex.Match(s);

            // Extract the matched value
            if (match.Success)
            {
                string extractedString = match.Groups[2].Value;
                return extractedString.Split('/');
            }
            return null;
        }

        private string takeRahusigns(string s)
        {
            // Define the regular expression pattern
            string pattern = @"\(house in \s(.*?)\s then\)";

            // Create a Regex object
            Regex regex = new Regex(pattern);

            // Find the match
            Match match = regex.Match(s);

            // Extract the matched value
            if (match.Success)
            {
                string extractedString = match.Groups[2].Value;
                return extractedString.Trim().Replace("sign", "");
            }
            return null;
        }

        private string takeKetusigns(string s)
        {
            // Define the regular expression pattern
            string pattern = @"\(house in \s(.*?)\s then\)";

            // Create a Regex object
            Regex regex = new Regex(pattern);

            // Find the match
            Match match = regex.Match(s);

            // Extract the matched value
            if (match.Success)
            {
                string extractedString = match.Groups[2].Value;
                return extractedString.Trim().Replace("sign", "");
            }
            return null;

        }
        private string findSign(string s)
        {
            if (s.Contains("Gemini Ascendant"))
                return "Mithuna";
            else if (s.Contains("Taurus Ascendant"))
                return "Vrishabha";
            else if (s.Contains("Aquarius Ascendant"))
                return "Kumbha";
            else if (s.Contains("Virgo Ascendant"))
                return "Kanya";
            else if (s.Contains("Aries Ascendant"))
                return "Mesha";
            else if (s.Contains("Cancer Ascendant"))
                return "Kataka";
            else if (s.Contains("Pisces Ascendant"))
                return "Meena";
            else if (s.Contains("Libra Ascendant"))
                return "Thula";
            else if (s.Contains("Capricorn Ascendant"))
                return "Makara";
            else if (s.Contains("Leo Ascendant"))
                return "Simha";
            else if (s.Contains("Scorpio Ascendant"))
                return "Vrichika";
            else if (s.Contains("Sagittarius Ascendant"))
                return "Dhanus";

            return "";
        }

        private string findSignSinhala(string s)
        {
            if (s.Contains("Gemini"))
                return "Mithuna";
            else if (s.Contains("Taurus"))
                return "Vrishabha";
            else if (s.Contains("Aquarius"))
                return "Kumbha";
            else if (s.Contains("Virgo"))
                return "Kanya";
            else if (s.Contains("Aries"))
                return "Mesha";
            else if (s.Contains("Cancer"))
                return "Kataka";
            else if (s.Contains("Pisces"))
                return "Meena";
            else if (s.Contains("Libra"))
                return "Thula";
            else if (s.Contains("Capricorn"))
                return "Makara";
            else if (s.Contains("Leo"))
                return "Simha";
            else if (s.Contains("Scorpio"))
                return "Vrichika";
            else if (s.Contains("Sagittarius"))
                return "Dhanus";

            return "";
        }
    }
}
