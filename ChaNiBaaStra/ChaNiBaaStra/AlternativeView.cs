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
        public AlternativeView()
        {
            InitializeComponent();
        }

        public void UpdateUI(ChartBase hrScope, bool isLagna)
        {
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
    }
}
