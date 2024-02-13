using ChaNiBaaStra.Dal.Models;
using ChaNiBaaStra.DataModels;
using ChaNiBaaStra.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ChaNiBaaStra.Calculator.AstroCalculator;

namespace ChaNiBaaStra
{
    public partial class AlternativeView : UserControl
    {
        public D9Chart D9Chart { get; set; }
        public AlternativeView()
        {
            InitializeComponent();
        }

        public void UpdateUI(ChartBase hrScope, bool isLagna)
        {
            D9Chart = new D9Chart(hrScope.OriginalHoroscope);
            if (this.Visible)
            {
                this.label1.Text = "[" + hrScope.House1.Loard.Name + "]";
                this.label2.Text = "[" + hrScope.House2.Loard.Name + "]";
                this.label3.Text = "[" + hrScope.House3.Loard.Name + "]";
                this.label4.Text = "[" + hrScope.House4.Loard.Name + "]";
                this.label5.Text = "[" + hrScope.House5.Loard.Name + "]";
                this.label6.Text = "[" + hrScope.House6.Loard.Name + "]";
                this.label7.Text = "[" + hrScope.House7.Loard.Name + "]";
                this.label8.Text = "[" + hrScope.House8.Loard.Name + "]";
                this.label9.Text = "[" + hrScope.House9.Loard.Name + "]";
                this.label10.Text = "[" + hrScope.House10.HouseRasi.Name + "]";
                this.label11.Text = "[" + hrScope.House11.HouseRasi.Name + "]";
                this.label12.Text = "[" + hrScope.House12.HouseRasi.Name + "]";

                this.flowLayoutPanel1.Controls.Clear();
                this.flowLayoutPanel2.Controls.Clear();
                this.flowLayoutPanel3.Controls.Clear();
                this.flowLayoutPanel4.Controls.Clear();
                this.flowLayoutPanel5.Controls.Clear();
                this.flowLayoutPanel6.Controls.Clear();
                this.flowLayoutPanel7.Controls.Clear();
                this.flowLayoutPanel8.Controls.Clear();
                this.flowLayoutPanel9.Controls.Clear();
                this.flowLayoutPanel10.Controls.Clear();
                this.flowLayoutPanel11.Controls.Clear();
                this.flowLayoutPanel12.Controls.Clear();
                if (isLagna)
                {
                    this.centerLabel.Text = hrScope.CurrentLagnaRashi.Name
                        + "\r\n(" + hrScope.CurrentLagnaRashi.AdhipathiEnumPlanets.FirstOrDefault()
                        + ")\r\n" + Math.Truncate(hrScope.CurrentLagnaRashi.RasiEndDegreesFromHorizon) + "°";

                    if (hrScope.House1 != null)
                        foreach (AstroPlanet planet in hrScope.House1.HousePlanets) AddPlanet(planet, flowLayoutPanel1, hrScope.CurrentLagnaRashi.Current);
                    if (hrScope.House2 != null)
                        foreach (AstroPlanet planet in hrScope.House2.HousePlanets) AddPlanet(planet, flowLayoutPanel2, hrScope.CurrentLagnaRashi.Current);
                    if (hrScope.House3 != null)
                        foreach (AstroPlanet planet in hrScope.House3.HousePlanets) AddPlanet(planet, flowLayoutPanel3, hrScope.CurrentLagnaRashi.Current);
                    if (hrScope.House4 != null)
                        foreach (AstroPlanet planet in hrScope.House4.HousePlanets) AddPlanet(planet, flowLayoutPanel4, hrScope.CurrentLagnaRashi.Current);
                    if (hrScope.House5 != null)
                        foreach (AstroPlanet planet in hrScope.House5.HousePlanets) AddPlanet(planet, flowLayoutPanel5, hrScope.CurrentLagnaRashi.Current);
                    if (hrScope.House6 != null)
                        foreach (AstroPlanet planet in hrScope.House6.HousePlanets) AddPlanet(planet, flowLayoutPanel6, hrScope.CurrentLagnaRashi.Current);
                    if (hrScope.House7 != null)
                        foreach (AstroPlanet planet in hrScope.House7.HousePlanets) AddPlanet(planet, flowLayoutPanel7, hrScope.CurrentLagnaRashi.Current);
                    if (hrScope.House8 != null)
                        foreach (AstroPlanet planet in hrScope.House8.HousePlanets) AddPlanet(planet, flowLayoutPanel8, hrScope.CurrentLagnaRashi.Current);
                    if (hrScope.House9 != null)
                        foreach (AstroPlanet planet in hrScope.House9.HousePlanets) AddPlanet(planet, flowLayoutPanel9, hrScope.CurrentLagnaRashi.Current);
                    if (hrScope.House10 != null)
                        foreach (AstroPlanet planet in hrScope.House10.HousePlanets) AddPlanet(planet, flowLayoutPanel10, hrScope.CurrentLagnaRashi.Current);
                    if (hrScope.House11 != null)
                        foreach (AstroPlanet planet in hrScope.House11.HousePlanets) AddPlanet(planet, flowLayoutPanel11, hrScope.CurrentLagnaRashi.Current);
                    if (hrScope.House12 != null)
                        foreach (AstroPlanet planet in hrScope.House12.HousePlanets) AddPlanet(planet, flowLayoutPanel12, hrScope.CurrentLagnaRashi.Current);
                }
            }
        }

        private void AddPlanetNawamsa(AstroPlanet planet, FlowLayoutPanel flowLayoutPanel, EnumRasi lagnaRasi)
        {
            ChaNiBaaStra.PlanetHolder planetHolder = new PlanetHolder();
            planetHolder.UpdateUI(planet, true);
            planetHolder.buttonMiddle.Click += delegate (object sender, EventArgs e) { ButtonMiddle_Click(sender, e, planet, lagnaRasi); };
            flowLayoutPanel.Controls.Add(planetHolder);
            planetHolder.Size = new Size(55, 40);
        }

        private void AddPlanet(AstroPlanet planet, FlowLayoutPanel flowLayoutPanel, EnumRasi lagnaRasi)
        {
            ChaNiBaaStra.PlanetHolder planetHolder = new PlanetHolder();
            planetHolder.UpdateUI(planet, true);
            
            planetHolder.buttonMiddle.Click += delegate (object sender, EventArgs e) { ButtonMiddle_Click(sender, e, planet, lagnaRasi); };
            flowLayoutPanel.Controls.Add(planetHolder);
            planetHolder.Size = new Size(55, 40);
        }

        private void ButtonMiddle_Click(object sender, EventArgs e, AstroPlanet p, EnumRasi lagnaRasi)
        {
            ResetButtonColor();
            // NOT SURE
            foreach (int houseNumber in p.AdhipathiHouses)
            {
                /*int houseNumber = AstroUtility.AstroCycleIncrease((int)lagnaRasi, p.Rasi.absoluteGabOfRasi(rasi));
                if (houseNumber == 0) houseNumber = 12;*/
                switch (houseNumber)
                {
                    case 1: this.button1.BackColor = Color.Yellow; this.button1.Text = AstroUtility.HouseGab(houseNumber, p.CurrentlyActiveHouseNumber).ToString(); break;
                    case 2: this.button2.BackColor = Color.Yellow; this.button2.Text = AstroUtility.HouseGab(houseNumber, p.CurrentlyActiveHouseNumber).ToString(); break;
                    case 3: this.button3.BackColor = Color.Yellow; this.button3.Text = AstroUtility.HouseGab(houseNumber, p.CurrentlyActiveHouseNumber).ToString(); break;
                    case 4: this.button4.BackColor = Color.Yellow; this.button4.Text = AstroUtility.HouseGab(houseNumber, p.CurrentlyActiveHouseNumber).ToString(); break;
                    case 5: this.button5.BackColor = Color.Yellow; this.button5.Text = AstroUtility.HouseGab(houseNumber, p.CurrentlyActiveHouseNumber).ToString(); break;
                    case 6: this.button6.BackColor = Color.Yellow; this.button6.Text = AstroUtility.HouseGab(houseNumber, p.CurrentlyActiveHouseNumber).ToString(); break;
                    case 7: this.button7.BackColor = Color.Yellow; this.button7.Text = AstroUtility.HouseGab(houseNumber, p.CurrentlyActiveHouseNumber).ToString(); break;
                    case 8: this.button8.BackColor = Color.Yellow; this.button8.Text = AstroUtility.HouseGab(houseNumber, p.CurrentlyActiveHouseNumber).ToString(); break;
                    case 9: this.button9.BackColor = Color.Yellow; this.button9.Text = AstroUtility.HouseGab(houseNumber, p.CurrentlyActiveHouseNumber).ToString(); break;
                    case 10: this.button10.BackColor = Color.Yellow; this.button10.Text = AstroUtility.HouseGab(houseNumber, p.CurrentlyActiveHouseNumber).ToString(); break;
                    case 11: this.button11.BackColor = Color.Yellow; this.button11.Text = AstroUtility.HouseGab(houseNumber, p.CurrentlyActiveHouseNumber).ToString(); break;
                    case 12: this.button12.BackColor = Color.Yellow; this.button12.Text = AstroUtility.HouseGab(houseNumber, p.CurrentlyActiveHouseNumber).ToString(); break;
                }
            }
        }

        private void ResetButtonColor()
        {
            this.button1.BackColor = Color.Transparent;
            this.button2.BackColor = Color.Transparent;
            this.button3.BackColor = Color.Transparent;
            this.button4.BackColor = Color.Transparent;
            this.button5.BackColor = Color.Transparent;
            this.button6.BackColor = Color.Transparent;
            this.button7.BackColor = Color.Transparent;
            this.button8.BackColor = Color.Transparent;
            this.button9.BackColor = Color.Transparent;
            this.button10.BackColor = Color.Transparent;
            this.button11.BackColor = Color.Transparent;
            this.button12.BackColor = Color.Transparent;

            this.button1.Text = "";
            this.button2.Text = "";
            this.button3.Text = "";
            this.button4.Text = "";
            this.button5.Text = "";
            this.button6.Text = "";
            this.button7.Text = "";
            this.button8.Text = "";
            this.button9.Text = "";
            this.button10.Text = "";
            this.button11.Text = "";
            this.button12.Text = "";

        }

        private void flowLayoutPanel1_MouseHover(object sender, EventArgs e)
        {

        }

        private void button_MouseHover(object sender, EventArgs e)
        {
            Button b  = (Button)sender;
            int houseNumber = Convert.ToInt32(b.Tag);
            switch (houseNumber)
            {
                case 1: { this.toolTipBotton.ToolTipTitle = "Self";  this.toolTipBotton.Show(ChaNiBaaStra.Utilities.HouseData.GetHouseData(1), b, 10000); break; }
                case 2: { this.toolTipBotton.ToolTipTitle = "Wealth and Family"; this.toolTipBotton.Show(ChaNiBaaStra.Utilities.HouseData.GetHouseData(2), b, 10000); break; }
                case 3: { this.toolTipBotton.ToolTipTitle = "Siblings, Courage and Valour"; this.toolTipBotton.Show(ChaNiBaaStra.Utilities.HouseData.GetHouseData(3), b, 10000); break; }
                case 4: { this.toolTipBotton.ToolTipTitle = "House, Mother and Happiness"; this.toolTipBotton.Show(ChaNiBaaStra.Utilities.HouseData.GetHouseData(4), b, 10000); break; } 
                case 5: { this.toolTipBotton.ToolTipTitle = "Children and Knowledge"; this.toolTipBotton.Show(ChaNiBaaStra.Utilities.HouseData.GetHouseData(5), b, 10000); break; }
                case 6: { this.toolTipBotton.ToolTipTitle = "Enemies, Debts and Deceases"; this.toolTipBotton.Show(ChaNiBaaStra.Utilities.HouseData.GetHouseData(6), b, 10000); break; }
                case 7: { this.toolTipBotton.ToolTipTitle = "Marriage and Partnerships"; this.toolTipBotton.Show(ChaNiBaaStra.Utilities.HouseData.GetHouseData(7), b, 10000); break; }
                case 8: { this.toolTipBotton.ToolTipTitle = "Longivity of Life"; this.toolTipBotton.Show(ChaNiBaaStra.Utilities.HouseData.GetHouseData(8), b, 10000); break; }
                case 9: { this.toolTipBotton.ToolTipTitle = "Religion, Father and Luck"; this.toolTipBotton.Show(ChaNiBaaStra.Utilities.HouseData.GetHouseData(9), b, 10000); break; }
                case 10: { this.toolTipBotton.ToolTipTitle = "Career or Profession"; this.toolTipBotton.Show(ChaNiBaaStra.Utilities.HouseData.GetHouseData(10), b, 10000); break; }
                case 11: { this.toolTipBotton.ToolTipTitle = "Income and Gains"; this.toolTipBotton.Show(ChaNiBaaStra.Utilities.HouseData.GetHouseData(11), b, 10000); break; }
                case 12: { this.toolTipBotton.ToolTipTitle = "Expenditure & Losses"; this.toolTipBotton.Show(ChaNiBaaStra.Utilities.HouseData.GetHouseData(12), b, 10000); break; }
            }
        }

        private void labelNawamsa_Click(object sender, EventArgs e)
        {
            string message = "";
            if (D9Chart.House1.HousePlanets.Exists(x => x.Current == EnumPlanet.Sun) ||
                D9Chart.House5.HousePlanets.Exists(x => x.Current == EnumPlanet.Sun) ||
                D9Chart.House9.HousePlanets.Exists(x => x.Current == EnumPlanet.Sun))
                message += "\r\nSun in 1, 5, 9th in D9. The person has rhythm, may play some musical instrument, and is very interested in music.The person may also read a lot.";

            if (D9Chart.House1.HousePlanets.Exists(x => x.Current == EnumPlanet.Moon) ||
                D9Chart.House5.HousePlanets.Exists(x => x.Current == EnumPlanet.Moon) ||
                D9Chart.House9.HousePlanets.Exists(x => x.Current == EnumPlanet.Moon))
                message += "\r\nMoon in 1, 5, 9th in D9. Has a very nice voice and could be a singer.";

            if (D9Chart.House1.HousePlanets.Exists(x => x.Current == EnumPlanet.Mars) ||
                D9Chart.House5.HousePlanets.Exists(x => x.Current == EnumPlanet.Mars) ||
                D9Chart.House9.HousePlanets.Exists(x => x.Current == EnumPlanet.Mars))
                message += "\r\nMars in 1, 5, 9th in D9. Short-tempered, courageous, and warrior tendencies.";

            if (D9Chart.House1.HousePlanets.Exists(x => x.Current == EnumPlanet.Mercury) ||
                D9Chart.House5.HousePlanets.Exists(x => x.Current == EnumPlanet.Mercury) ||
                D9Chart.House9.HousePlanets.Exists(x => x.Current == EnumPlanet.Mercury))
                message += "\r\nMercury in 1, 5, 9th in D9. Very good speaker, does not like conflicts and is good in business";

            if (D9Chart.House1.HousePlanets.Exists(x => x.Current == EnumPlanet.Jupiter) ||
                D9Chart.House5.HousePlanets.Exists(x => x.Current == EnumPlanet.Jupiter) ||
                D9Chart.House9.HousePlanets.Exists(x => x.Current == EnumPlanet.Jupiter))
                message += "\r\nJupiter in 1, 5, 9th in D9.  wise and knowledgeable. Has a lot of knowledge about various things.";

            if (D9Chart.House1.HousePlanets.Exists(x => x.Current == EnumPlanet.Saturn) ||
                D9Chart.House5.HousePlanets.Exists(x => x.Current == EnumPlanet.Saturn) ||
                D9Chart.House9.HousePlanets.Exists(x => x.Current == EnumPlanet.Saturn))
                message += "\r\nSaturn in 1, 5, 9th in D9. Hard-working, traditional and orthodox.";

            if (D9Chart.House1.HousePlanets.Exists(x => x.Current == EnumPlanet.Venus) ||
                D9Chart.House5.HousePlanets.Exists(x => x.Current == EnumPlanet.Venus) ||
                D9Chart.House9.HousePlanets.Exists(x => x.Current == EnumPlanet.Venus))
                message += "\r\nVenus in 1, 5, 9th in D9. Eye for details, artistic abilities, photographic memory, better with faces than names.";

            if (D9Chart.House1.HousePlanets.Exists(x => x.Current == EnumPlanet.Rahu) ||
                D9Chart.House5.HousePlanets.Exists(x => x.Current == EnumPlanet.Rahu) ||
                D9Chart.House9.HousePlanets.Exists(x => x.Current == EnumPlanet.Rahu))
                message += "\r\nRahu in 1, 5, 9th in D9. Ability to handle big machines without fear. Skilled in research, philosophy, and mathematics.";

            if (D9Chart.House1.HousePlanets.Exists(x => x.Current == EnumPlanet.Kethu) ||
                D9Chart.House5.HousePlanets.Exists(x => x.Current == EnumPlanet.Kethu) ||
                D9Chart.House9.HousePlanets.Exists(x => x.Current == EnumPlanet.Kethu))
                message += "\r\nKethu in 1, 5, 9th in D9. Great with mobile devices, computers, and electronics. Very spiritual and has the capability to show the path for people.";

            AstroRasi rasi = D9Chart.OriginalHoroscope.RasiHouseList.FirstOrDefault(x => x.HouseNumber == 9);
            if (rasi.Loard.IsExtremelyExaltedInRashi(rasi.Loard.NawamsaRasi.Current) || rasi.Loard.IsExaltedInRashi(rasi.Loard.NawamsaRasi.Current))
                message += "\r\nLoard of 9th house " + rasi.Loard.Name + " of D1 chart is exalted in the D9 chart. It signifies great fortune";
            else if (rasi.Loard.IsExtremelyDebilitatedInRashi(rasi.Loard.NawamsaRasi.Current) || rasi.Loard.IsExtremelyDebilitatedInRashi(rasi.Loard.NawamsaRasi.Current))
                message += "\r\nLoard of 9th house " + rasi.Loard.Name + " of D1 chart is deblitated in the D9 chart. You may have to work harder and life could be challenging";

            if (D9Chart.CurrentLagnaRashi.Loard.IsExtremelyExaltedInRashi(D9Chart.CurrentLagnaRashi.Loard.NawamsaRasi.Current) || D9Chart.CurrentLagnaRashi.Loard.IsExaltedInRashi(rasi.Loard.NawamsaRasi.Current) || D9Chart.CurrentLagnaRashi.Loard.PlanetRasiRelation == EnumPlanetRasiRelationTypes.Swashesthra)
                message += "\r\nLoard of D9 " + D9Chart.CurrentLagnaRashi.Loard.Name + " is exalted or in own house. Add strength to the chart";

            if (D9Chart.CurrentLagnaRashi.Current == D9Chart.OriginalHoroscope.LagnaRasi.Current)
                message += "\r\nD9 lagna " + D9Chart.CurrentLagnaRashi.Name + " is vargottama, therefore it promises a long life.";

            if (D9Chart.CurrentLagnaRashi.GetIncrementRashi(7) == D9Chart.OriginalHoroscope.NavamsaRasi.Current)
                message += "\r\nNavamsha lagna " + D9Chart.OriginalHoroscope.NavamsaRasi.Name + " is in the 8th house of Rashi lagna. So there will be one setback in your life which will make you very spiritual.";

            if (D9Chart.House10.HousePlanets.Exists(x => x.MelificOrBenific == PlanetTypes.Melific))
                message += "\r\nThe 10th house in d9 shows the flow of money or income. You have malefic planets here so the wealth may be fluctuating.";
            else if (D9Chart.House10.HousePlanets.Exists(x => x.MelificOrBenific == PlanetTypes.Benefic))
                message += "\r\nThe 10th house in d9 shows the flow of money or income. You have benefic planets here so the wealth may flow steadilly.";

            if (D9Chart.House7.HousePlanets.Exists(x => x.MelificOrBenific == PlanetTypes.Melific))
                message += "\r\nMalefic planets placed in the 7th house of the D9 chart. Can create problems in relationships.";
            else if (D9Chart.House7.HousePlanets.Exists(x => x.MelificOrBenific == PlanetTypes.Benefic))
                message += "\r\nBenefic planets placed in the 7th house of the D9 chart. It is good for relationships.";

            List<AstroPlanet> planets = D9Chart.Planets.FindAll(x => x.NawamsaRasi.Current == EnumRasi.Thula || x.NawamsaRasi.Current == EnumRasi.Vrishabha);
            if (planets.Count > 0)
                foreach (AstroPlanet p in planets)
                    message += "\r\n Your life style influenced by the previous birth is  " + p.GetPlanetQuality();
            AstroPlanet saniNawamsaLoardPlanet = D9Chart.Planets.FirstOrDefault(x => x.Current == EnumPlanet.Saturn).NawamsaRasi.Loard;
            if (saniNawamsaLoardPlanet.IsVargoththama || saniNawamsaLoardPlanet.IsPowerful)
                message += "\r\nThe rashi load (" + saniNawamsaLoardPlanet.Name + ") of D9 where Saturn is placed either vargoththama or well placed. You will somehow come out of suffering and pain in life";

            if (D9Chart.House1.Loard.IsPowerful)
                message += "\r\nStrong Navamsa lagna lord, " + D9Chart.House1.Loard.Name + " in Rashi (D1) chart promises good health";
            if (D9Chart.House10.Loard.IsPowerful)
                message += "\r\n10th house lord of Navamsa, " + D9Chart.House10.Loard.Name + " is strong in Rashi so it promises great wealth";
            if (D9Chart.House4.Loard.IsPowerful)
                message += "\r\n4th house lord of Navamsa, " + D9Chart.House4.Loard.Name + " is strong in Rashi so it is great for spirituality";
            if (D9Chart.House7.Loard.IsPowerful)
                message += "\r\n7th house lord of Navamsa, " + D9Chart.House7.Loard.Name + " is strong in Rashi so it is  good for joy and happiness in life";
            AstroPlanet moonPlanet = D9Chart.Planets.FirstOrDefault(x => x.Current == EnumPlanet.Moon);

            message += "\r\nMoon Khara Nawamsa =" + ((D9Chart)D9Chart).GetKharaNavamsa(EnumPlanet.Moon) + ", The Loard (Look for depression, diseases or problems related with water or even death) = " + D9Chart.OriginalHoroscope.GetKharaNavamsaLoard(EnumPlanet.Moon).Name;
            message += "\r\nLagna Khara Nawamsa =" + D9Chart.OriginalHoroscope.GetLagnaKharaNawamsa() + ", The Loard (Look for diseases, accidents or physical pains in their Dasha or Antardasha) = " + D9Chart.OriginalHoroscope.GetLagnaKharakaNawamsaLoard().Name;
            message += "\r\nKhara Nawamsa =" + D9Chart.House4.HouseRasi.Name + ", The planets (Look for diseases, accidents or physical pains in its Dasha or Antardasha) =" + D9Chart.House4.HousePlanets.ToAstroPlanetShortString();

            if (D9Chart.OriginalHoroscope.NavamsaRasi.Current == D9Chart.OriginalHoroscope.LagnaRasi.GetIncrementRashi(11))
                message += "\r\nThe person will be core and awful.";
            if (D9Chart.OriginalHoroscope.NavamsaRasi.Current == D9Chart.OriginalHoroscope.LagnaRasi.GetIncrementRashi(8))
                message += "\r\nThe person will be passionate.";
            if (D9Chart.OriginalHoroscope.NavamsaRasi.Current == D9Chart.OriginalHoroscope.LagnaRasi.GetIncrementRashi(10))
                message += "\r\nThe person will obtain moksha.";
            if (D9Chart.OriginalHoroscope.NavamsaRasi.Current == D9Chart.OriginalHoroscope.LagnaRasi.GetIncrementRashi(6))
                message += "\r\nThe person will not be ethical.";

            //this.SetToolTip(toolTipBotton, message);
        }
    }
}
