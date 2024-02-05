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
    public partial class HoroscopeView : UserControl
    {
        public HoroscopeView()
        {
            InitializeComponent();
        }

        public void UpdateUI(Horoscope hrScope, bool isLagna)
        {
            if (this.Visible)
            {
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
                    this.centerLabel.Text = hrScope.LagnaRasi.Name
                        + "\r\n(" + hrScope.LagnaRasi.AdhipathiEnumPlanets.FirstOrDefault()
                        + ")\r\n" + Math.Truncate(hrScope.LagnaRasi.RasiEndDegreesFromHorizon) + "°";

                    foreach (AstroRasi rasi in hrScope.RasiHouseList)
                    {
                        switch (rasi.HouseNumber)
                        {
                            case 1:
                                {
                                    foreach (AstroPlanet planet in rasi.Planets) AddPlanet(planet, flowLayoutPanel1, hrScope.LagnaRasi.Current);
                                    break;
                                }
                            case 2:
                                {
                                    foreach (AstroPlanet planet in rasi.Planets) AddPlanet(planet, flowLayoutPanel2, hrScope.LagnaRasi.Current);
                                    break;
                                }
                            case 3:
                                {
                                    foreach (AstroPlanet planet in rasi.Planets) AddPlanet(planet, flowLayoutPanel3, hrScope.LagnaRasi.Current);
                                    break;
                                }
                            case 4:
                                {
                                    foreach (AstroPlanet planet in rasi.Planets) AddPlanet(planet, flowLayoutPanel4, hrScope.LagnaRasi.Current);
                                    break;
                                }
                            case 5:
                                {
                                    foreach (AstroPlanet planet in rasi.Planets) AddPlanet(planet, flowLayoutPanel5, hrScope.LagnaRasi.Current);
                                    break;
                                }
                            case 6:
                                {
                                    foreach (AstroPlanet planet in rasi.Planets) AddPlanet(planet, flowLayoutPanel6, hrScope.LagnaRasi.Current);
                                    break;
                                }
                            case 7:
                                {
                                    foreach (AstroPlanet planet in rasi.Planets) AddPlanet(planet, flowLayoutPanel7, hrScope.LagnaRasi.Current);
                                    break;
                                }
                            case 8:
                                {
                                    foreach (AstroPlanet planet in rasi.Planets) AddPlanet(planet, flowLayoutPanel8, hrScope.LagnaRasi.Current);
                                    break;
                                }
                            case 9:
                                {
                                    foreach (AstroPlanet planet in rasi.Planets) AddPlanet(planet, flowLayoutPanel9, hrScope.LagnaRasi.Current);
                                    break;
                                }
                            case 10:
                                {
                                    foreach (AstroPlanet planet in rasi.Planets) AddPlanet(planet, flowLayoutPanel10, hrScope.LagnaRasi.Current);
                                    break;
                                }
                            case 11:
                                {
                                    foreach (AstroPlanet planet in rasi.Planets) AddPlanet(planet, flowLayoutPanel11, hrScope.LagnaRasi.Current);
                                    break;
                                }
                            case 12:
                                foreach (AstroPlanet planet in rasi.Planets) AddPlanet(planet, flowLayoutPanel12, hrScope.LagnaRasi.Current);
                                break;
                        }
                    }
                }
                else
                {
                    this.centerLabel.Text = hrScope.NavamsaRasi.Name + "\r\n(" + hrScope.NavamsaRasi.AdhipathiEnumPlanets.FirstOrDefault() + ")\r\n" + Math.Truncate(hrScope.LagnaRasi.RasiEndDegreesFromHorizon) + "°";
                    foreach (AstroRasi rasi in hrScope.RasiHouseList)
                    {
                        foreach (AstroPlanet planet in rasi.Planets)
                        {
                            int houseNumber = hrScope.NavamsaRasi.ofRasi(planet.NawamsaRasi.Current);
                            switch (houseNumber)
                            {
                                case 1:
                                    {
                                        AddPlanetNawamsa(planet, this.flowLayoutPanel1, hrScope.LagnaRasi.Current);
                                        break;
                                    }
                                case 2:
                                    {
                                        AddPlanetNawamsa(planet, this.flowLayoutPanel2, hrScope.LagnaRasi.Current);
                                        break;
                                    }
                                case 3:
                                    {
                                        AddPlanetNawamsa(planet, this.flowLayoutPanel3, hrScope.LagnaRasi.Current);
                                        break;
                                    }
                                case 4:
                                    {
                                        AddPlanetNawamsa(planet, this.flowLayoutPanel4, hrScope.LagnaRasi.Current);
                                        break;
                                    }
                                case 5:
                                    {
                                        AddPlanetNawamsa(planet, this.flowLayoutPanel5, hrScope.LagnaRasi.Current);
                                        break;
                                    }
                                case 6:
                                    {
                                        AddPlanetNawamsa(planet, this.flowLayoutPanel6, hrScope.LagnaRasi.Current);
                                        break;
                                    }
                                case 7:
                                    {
                                        AddPlanetNawamsa(planet, this.flowLayoutPanel7, hrScope.LagnaRasi.Current);
                                        break;
                                    }
                                case 8:
                                    {
                                        AddPlanetNawamsa(planet, this.flowLayoutPanel8, hrScope.LagnaRasi.Current);
                                        break;
                                    }
                                case 9:
                                    {
                                        AddPlanetNawamsa(planet, this.flowLayoutPanel9, hrScope.LagnaRasi.Current);
                                        break;
                                    }
                                case 10:
                                    {
                                        AddPlanetNawamsa(planet, this.flowLayoutPanel10, hrScope.LagnaRasi.Current);
                                        break;
                                    }
                                case 11:
                                    {
                                        AddPlanetNawamsa(planet, this.flowLayoutPanel11, hrScope.LagnaRasi.Current);
                                        break;
                                    }
                                case 12:
                                    {
                                        AddPlanetNawamsa(planet, this.flowLayoutPanel12, hrScope.LagnaRasi.Current);
                                        break;
                                    }
                            }
                        }
                    }
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
            planetHolder.UpdateUI(planet);
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
                    case 1: this.button1.BackColor = Color.Yellow; this.button1.Text = AstroUtility.HouseGab(houseNumber, p.HouseNumber).ToString(); break;
                    case 2: this.button2.BackColor = Color.Yellow; this.button2.Text = AstroUtility.HouseGab(houseNumber, p.HouseNumber).ToString(); break;
                    case 3: this.button3.BackColor = Color.Yellow; this.button3.Text = AstroUtility.HouseGab(houseNumber, p.HouseNumber).ToString(); break;
                    case 4: this.button4.BackColor = Color.Yellow; this.button4.Text = AstroUtility.HouseGab(houseNumber, p.HouseNumber).ToString(); break;
                    case 5: this.button5.BackColor = Color.Yellow; this.button5.Text = AstroUtility.HouseGab(houseNumber, p.HouseNumber).ToString(); break;
                    case 6: this.button6.BackColor = Color.Yellow; this.button6.Text = AstroUtility.HouseGab(houseNumber, p.HouseNumber).ToString(); break;
                    case 7: this.button7.BackColor = Color.Yellow; this.button7.Text = AstroUtility.HouseGab(houseNumber, p.HouseNumber).ToString(); break;
                    case 8: this.button8.BackColor = Color.Yellow; this.button8.Text = AstroUtility.HouseGab(houseNumber, p.HouseNumber).ToString(); break;
                    case 9: this.button9.BackColor = Color.Yellow; this.button9.Text = AstroUtility.HouseGab(houseNumber, p.HouseNumber).ToString(); break;
                    case 10: this.button10.BackColor = Color.Yellow; this.button10.Text = AstroUtility.HouseGab(houseNumber, p.HouseNumber).ToString(); break;
                    case 11: this.button11.BackColor = Color.Yellow; this.button11.Text = AstroUtility.HouseGab(houseNumber, p.HouseNumber).ToString(); break;
                    case 12: this.button12.BackColor = Color.Yellow; this.button12.Text = AstroUtility.HouseGab(houseNumber, p.HouseNumber).ToString(); break;
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
    }
}
