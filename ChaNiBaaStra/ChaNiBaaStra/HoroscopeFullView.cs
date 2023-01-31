using ChaNiBaaStra.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChaNiBaaStra.Utilities;
using ChaNiBaaStra.Dal.Models;
using static ChaNiBaaStra.Calculator.AstroCalculator;

namespace ChaNiBaaStra
{
    public partial class HoroscopeFullView : UserControl
    {
        public Horoscope CurrentHoroscope { get; set; }
        public Horoscope TransitHoroscope { get; set; }
        public bool IsBhavaView { get; set; }

        public HoroscopeFullView()
        {
            InitializeComponent();
        }

        public void UiInit()
        {
            InitHoroscopeFlowLayout();
            InitHoroscope();
            InitNawamsaHoroscope();  
        }

        public void PartialUiInit()
        {
            InitTransitFlowLayout();
            InitTransitHoroscope();
        }

        private void InitNawamsaHoroscope()
        {
            this.labelNawamsa.Text = CurrentHoroscope.NavamsaRasi.Name
                + "\r\n(" + CurrentHoroscope.NavamsaRasi.AdhipathiPlanets.FirstOrDefault()
                + ") " + Math.Truncate(CurrentHoroscope.NavamsaRasi.RasiEndDegreesFromHorizon)
                + "°";
            ResetLabels();
            if (IsBhavaView)
                foreach (AstroBhava rasi in CurrentHoroscope.BhavaHouseList)
                    CreateNawamsaHoroscope(rasi.Planets);
            else
                foreach (AstroRasi rasi in CurrentHoroscope.RasiHouseList)
                    CreateNawamsaHoroscope(rasi.Planets);
        }

        private void CreateNawamsaHoroscope(List<AstroPlanet> planets)
        {                
            foreach (AstroPlanet planet in planets)
            {
                int houseNumber = CurrentHoroscope
                    .NavamsaRasi.ofRasi(planet.NavamsaRasi.Current);
                switch (houseNumber)
                {
                    case 1:
                        updateNawamsa(this.labelNW1, planet.ShortName);
                        break;
                    case 2:
                        updateNawamsa(this.labelNW2, planet.ShortName);
                        break;
                    case 3:
                        updateNawamsa(this.labelNW3, planet.ShortName);
                        break;
                    case 4:
                        updateNawamsa(this.labelNW4, planet.ShortName);
                        break;
                    case 5:
                        updateNawamsa(this.labelNW5, planet.ShortName);
                        break;
                    case 6:
                        updateNawamsa(this.labelNW6, planet.ShortName);
                        break;
                    case 7:
                        updateNawamsa(this.labelNW7, planet.ShortName);
                        break;
                    case 8:
                        updateNawamsa(this.labelNW8, planet.ShortName);
                        break;
                    case 9:
                        updateNawamsa(this.labelNW9, planet.ShortName);
                        break;
                    case 10:
                        updateNawamsa(this.labelNW10, planet.ShortName);
                        break;
                    case 11:
                        updateNawamsa(this.labelNW11, planet.ShortName);
                        break;
                    case 12:
                        updateNawamsa(this.labelNW12, planet.ShortName);
                        break;
                }
            }
        }

        private void updateNawamsa(Label nawamsaLabel, string planetName)
        {
            if (nawamsaLabel.Text.Length > 0)
                nawamsaLabel.Text += ", ";
            nawamsaLabel.Text += planetName;
        }

        private void ResetLabels()
        {
            this.labelNW1.Text = "";
            this.labelNW2.Text = "";
            this.labelNW3.Text = "";
            this.labelNW4.Text = "";
            this.labelNW5.Text = "";
            this.labelNW6.Text = "";
            this.labelNW7.Text = "";
            this.labelNW8.Text = "";
            this.labelNW9.Text = "";
            this.labelNW10.Text = "";
            this.labelNW11.Text = "";
            this.labelNW12.Text = "";
        }

        public void InitTransitHoroscope()
        {
            this.labelTransit.Text = TransitHoroscope.LagnaRasi.Name
                + "\r\n(" + TransitHoroscope.LagnaRasi.AdhipathiPlanets.FirstOrDefault()
                + ") " + Math.Truncate(TransitHoroscope.LagnaRasi.RasiEndDegreesFromHorizon)
                + "°";
            if (IsBhavaView)
                foreach (AstroBhava rasi in TransitHoroscope.BhavaHouseList)
                    CreateTransitHoroscope(rasi.BhavaNumber, rasi.Planets);
            else
                foreach (AstroRasi rasi in TransitHoroscope.RasiHouseList)
                    CreateTransitHoroscope(rasi.HouseNumber, rasi.Planets);
        }

        private void CreateTransitHoroscope(int houseNumber, List<AstroPlanet> planets)
        {
            switch (houseNumber)
            {
                case 1:
                    AddPlanet(planets, this.flowLayoutPanelT1
                        , CurrentHoroscope.LagnaRasi.Current, true);
                    break;
                case 2:
                    AddPlanet(planets, this.flowLayoutPanelT2
                        , CurrentHoroscope.LagnaRasi.Current, true);
                    break;
                case 3:
                    AddPlanet(planets, this.flowLayoutPanelT3
                        , CurrentHoroscope.LagnaRasi.Current, true);
                    break;
                case 4:
                    AddPlanet(planets, this.flowLayoutPanelT4
                        , CurrentHoroscope.LagnaRasi.Current, true);
                    break;
                case 5:
                    AddPlanet(planets, this.flowLayoutPanelT5
                        , CurrentHoroscope.LagnaRasi.Current, true);
                    break;
                case 6:
                    AddPlanet(planets, this.flowLayoutPanelT6
                        , CurrentHoroscope.LagnaRasi.Current, true);
                    break;
                case 7:
                    AddPlanet(planets, this.flowLayoutPanelT7
                        , CurrentHoroscope.LagnaRasi.Current, true);
                    break;
                case 8:
                    AddPlanet(planets, this.flowLayoutPanelT8
                        , CurrentHoroscope.LagnaRasi.Current, true);
                    break;
                case 9:
                    AddPlanet(planets, this.flowLayoutPanelT9
                        , CurrentHoroscope.LagnaRasi.Current, true);
                    break;
                case 10:
                    AddPlanet(planets, this.flowLayoutPanelT10
                        , CurrentHoroscope.LagnaRasi.Current, true);
                    break;
                case 11:
                    AddPlanet(planets, this.flowLayoutPanelT11
                        , CurrentHoroscope.LagnaRasi.Current, true);
                    break;
                case 12:
                    AddPlanet(planets, this.flowLayoutPanelT12
                        , CurrentHoroscope.LagnaRasi.Current, true);
                    break;
            }
        }

        public void InitHoroscope()
        {
            this.labelLagna.Text = CurrentHoroscope.LagnaRasi.Name
                + "\r\n(" + CurrentHoroscope.LagnaRasi.AdhipathiPlanets.FirstOrDefault()
                + ") " + Math.Truncate(CurrentHoroscope.LagnaRasi.RasiEndDegreesFromHorizon)
                + "°";
            if (IsBhavaView)
                foreach (AstroBhava rasi in CurrentHoroscope.BhavaHouseList)
                {
                    CeateHoroscope(rasi.BhavaNumber, rasi.Planets);
                }
            else
                foreach (AstroRasi rasi in CurrentHoroscope.RasiHouseList)
                {
                    CeateHoroscope(rasi.HouseNumber, rasi.Planets);
                }
        }

        private void CeateHoroscope(int house, List<AstroPlanet> planets)
        {
            switch (house)
            {
                case 1:
                    {
                        AddPlanet(planets, this.flowLayoutPanelN1
                            , CurrentHoroscope.LagnaRasi.Current);
                        break;
                    }
                case 2:
                    {
                        AddPlanet(planets, this.flowLayoutPanelN2
                            , CurrentHoroscope.LagnaRasi.Current);
                        break;
                    }
                case 3:
                    {
                        AddPlanet(planets, this.flowLayoutPanelN3
                            , CurrentHoroscope.LagnaRasi.Current);
                        break;
                    }
                case 4:
                    {
                        AddPlanet(planets, this.flowLayoutPanelN4
                            , CurrentHoroscope.LagnaRasi.Current);
                        break;
                    }
                case 5:
                    {
                        AddPlanet(planets, this.flowLayoutPanelN5
                            , CurrentHoroscope.LagnaRasi.Current);
                        break;
                    }
                case 6:
                    {
                        AddPlanet(planets, this.flowLayoutPanelN6
                            , CurrentHoroscope.LagnaRasi.Current);
                        break;
                    }
                case 7:
                    {
                        AddPlanet(planets, this.flowLayoutPanelN7
                            , CurrentHoroscope.LagnaRasi.Current);
                        break;
                    }
                case 8:
                    {
                        AddPlanet(planets, this.flowLayoutPanelN8
                            , CurrentHoroscope.LagnaRasi.Current);
                        break;
                    }
                case 9:
                    {
                        AddPlanet(planets, this.flowLayoutPanelN9
                            , CurrentHoroscope.LagnaRasi.Current);
                        break;
                    }
                case 10:
                    {
                        AddPlanet(planets, this.flowLayoutPanelN10
                            , CurrentHoroscope.LagnaRasi.Current);
                        break;
                    }
                case 11:
                    {
                        AddPlanet(planets, this.flowLayoutPanelN11
                            , CurrentHoroscope.LagnaRasi.Current);
                        break;
                    }
                case 12:
                    AddPlanet(planets, this.flowLayoutPanelN12
                        , CurrentHoroscope.LagnaRasi.Current);
                    break;
            }
        }

        private void AddPlanet(List<AstroPlanet> planets, FlowLayoutPanel flowLayoutPanel, EnumRasi lagnaRasi, bool IsTransit = false)
        {
            foreach (AstroPlanet planet in planets)
            {
                ChaNiBaaStra.PlanetView planetHolder = new PlanetView();
                planetHolder.IsTransitPlanet = IsTransit;
                planetHolder.UpdateUI(planet);
                flowLayoutPanel.Controls.Add(planetHolder);
                if (planet.Rasi.IsBadakaSthana)
                    this.toolTipFullView.SetToolTip(flowLayoutPanel, "Badaka Sthana");
                planetHolder.Size = new Size(55, 30);
                planetHolder.PlanetButtonClicked = new ButtonClicked(SomePlanetClicked);
            }
        }

        public List<PlanetView> planetHolders = new List<PlanetView>(2);

        public void SomePlanetClicked(object sender, EventArgs e)
        {
            PlanetView pView = (PlanetView)sender;
            ((Form2)this.Parent.Parent.Parent).UpdateForPlanet((!IsBhavaView)
                ? pView.ThisPlanet.AjustedLongitude
                : pView.ThisPlanet.AjustedBhavaLongitude
                , pView.ThisPlanet.Nakatha.Name
                , pView.ThisPlanet.NavamsaRasi.Name);

            if (planetHolders.Count == 0)
            {
                planetHolders.Add(pView);
                planetHolders[0].RelatedPlanet = null;
            }
            else if (planetHolders.Count == 1)
            {
                planetHolders.Add(pView);
                planetHolders[0].RelatedPlanet = planetHolders[1].ThisPlanet;
                planetHolders[1].RelatedPlanet = planetHolders[0].ThisPlanet;
            }
            else if (planetHolders.Count >= 2)
            {
                planetHolders[0].UpdateButtonNobe(true);
                planetHolders[0] = planetHolders[1];
                planetHolders[1] = pView;
                planetHolders[0].RelatedPlanet = planetHolders[1].ThisPlanet;
                planetHolders[1].RelatedPlanet = planetHolders[0].ThisPlanet;
                pView.UpdateButtonNobe(false);
                planetHolders[0].UpdateButtonNobe(false);
            }
            ShowAdhipathyAfterPlanetClick(pView.ThisPlanet
                , CurrentHoroscope.LagnaRasi.Current
                , pView.IsTransitPlanet);
        }

        private void UpdateAdhipathyAfterClick(Panel adhipathyIndicator
            , Label gapLabel, int gap)
        {
            adhipathyIndicator.Visible = true;
            gapLabel.Text = "(" + gap + ")";
        }

        private void ShowAdhipathyAfterPlanetClick(AstroPlanet p
            , EnumRasi lagnaRasi, bool isTransit)
        {
            if (isTransit)
                ResetTransitButtonColor();
            else
                ResetButtonColor();

            foreach (EnumRasi rasi in p.AdhipathiRasis)
            {
                int houseNumber = AstroUtility.AstroCycleIncrease((int)lagnaRasi
                    , (this.IsBhavaView) ? p.Bhava.absoluteGabOfRasi(rasi) : p.Rasi.absoluteGabOfRasi(rasi));
                if (houseNumber == 0) houseNumber = 12;
                switch (houseNumber)
                {
                    case 1:
                        {
                            UpdateAdhipathyAfterClick((isTransit) ? this.panelT1RashiHead
                                : this.panelN1RashiHead, (isTransit) ? this.labelT1
                                : this.labelN1, AstroUtility.HouseGab(houseNumber, (this.IsBhavaView) 
                                ? p.Bhava.BhavaNumber : p.HouseNumber));
                            break;
                        }
                    case 2:
                        {
                            UpdateAdhipathyAfterClick((isTransit) ? this.panelT2RashiHead
                                : this.panelN2RashiHead, (isTransit) ? this.labelT2
                                : this.labelN2, AstroUtility.HouseGab(houseNumber, (this.IsBhavaView) 
                                ? p.Bhava.BhavaNumber : p.HouseNumber));
                            break;
                        }
                    case 3:
                        {
                            UpdateAdhipathyAfterClick((isTransit) ? this.panelT3RashiHead
                                : this.panelN3RashiHead, (isTransit) ? this.labelT3
                                : this.labelN3, AstroUtility.HouseGab(houseNumber, (this.IsBhavaView) 
                                ? p.Bhava.BhavaNumber : p.HouseNumber));
                            break;
                        }
                    case 4:
                        {
                            UpdateAdhipathyAfterClick((isTransit) ? this.panelT4RashiHead
                                : this.panelN4RashiHead, (isTransit) ? this.labelT4
                                : this.labelN4, AstroUtility.HouseGab(houseNumber, (this.IsBhavaView) 
                                ? p.Bhava.BhavaNumber : p.HouseNumber));
                            break;
                        }
                    case 5:
                        {
                            UpdateAdhipathyAfterClick((isTransit) ? this.panelT5RashiHead
                                : this.panelN5RashiHead, (isTransit) ? this.labelT5
                                : this.labelN5, AstroUtility.HouseGab(houseNumber, (this.IsBhavaView) 
                                ? p.Bhava.BhavaNumber : p.HouseNumber));
                            break;
                        }
                    case 6:
                        {
                            UpdateAdhipathyAfterClick((isTransit) ? this.panelT6RashiHead
                                : this.panelN6RashiHead, (isTransit) ? this.labelT6
                                : this.labelN6, AstroUtility.HouseGab(houseNumber, (this.IsBhavaView) 
                                ? p.Bhava.BhavaNumber : p.HouseNumber));
                            break;
                        }
                    case 7:
                        {
                            UpdateAdhipathyAfterClick((isTransit) ? this.panelT7RashiHead
                                : this.panelN7RashiHead, (isTransit) ? this.labelT7
                                : this.labelN7, AstroUtility.HouseGab(houseNumber, (this.IsBhavaView) 
                                ? p.Bhava.BhavaNumber : p.HouseNumber));
                            break;
                        }
                    case 8:
                        {
                            UpdateAdhipathyAfterClick((isTransit) ? this.panelT8RashiHead
                                : this.panelN8RashiHead, (isTransit) ? this.labelT8
                                : this.labelN8, AstroUtility.HouseGab(houseNumber, (this.IsBhavaView) 
                                ? p.Bhava.BhavaNumber : p.HouseNumber));
                            break;
                        }
                    case 9:
                        {
                            UpdateAdhipathyAfterClick((isTransit) ? this.panelT9RashiHead
                                : this.panelN9RashiHead, (isTransit) ? this.labelT9
                                : this.labelN9, AstroUtility.HouseGab(houseNumber, (this.IsBhavaView) 
                                ? p.Bhava.BhavaNumber : p.HouseNumber));
                            break;
                        }
                    case 10:
                        {
                            UpdateAdhipathyAfterClick((isTransit) ? this.panelT10RashiHead
                                : this.panelN10RashiHead, (isTransit) ? this.labelT10
                                : this.labelN10, AstroUtility.HouseGab(houseNumber, (this.IsBhavaView) 
                                ? p.Bhava.BhavaNumber : p.HouseNumber));
                            break;
                        }
                    case 11:
                        {
                            UpdateAdhipathyAfterClick((isTransit) ? this.panelT11RashiHead
                                : this.panelN11RashiHead, (isTransit) ? this.labelT11
                                : this.labelN11, AstroUtility.HouseGab(houseNumber, (this.IsBhavaView) 
                                ? p.Bhava.BhavaNumber : p.HouseNumber));
                            break;
                        }
                    case 12:
                        {
                            UpdateAdhipathyAfterClick((isTransit) ? this.panelT12RashiHead
                                : this.panelN12RashiHead, (isTransit) ? this.labelT12
                                : this.labelN12, AstroUtility.HouseGab(houseNumber, (this.IsBhavaView) 
                                ? p.Bhava.BhavaNumber : p.HouseNumber));
                            break;
                        }
                }
            }
        }

        private void ResetTransitButtonColor()
        {
            this.panelT1RashiHead.Visible = false;
            this.panelT2RashiHead.Visible = false;
            this.panelT3RashiHead.Visible = false;
            this.panelT4RashiHead.Visible = false;
            this.panelT5RashiHead.Visible = false;
            this.panelT6RashiHead.Visible = false;
            this.panelT7RashiHead.Visible = false;
            this.panelT8RashiHead.Visible = false;
            this.panelT9RashiHead.Visible = false;
            this.panelT10RashiHead.Visible = false;
            this.panelT11RashiHead.Visible = false;
            this.panelT12RashiHead.Visible = false;

            this.labelT1.Text = "";
            this.labelT2.Text = "";
            this.labelT3.Text = "";
            this.labelT4.Text = "";
            this.labelT5.Text = "";
            this.labelT6.Text = "";
            this.labelT7.Text = "";
            this.labelT8.Text = "";
            this.labelT9.Text = "";
            this.labelT10.Text = "";
            this.labelT11.Text = "";
            this.labelT12.Text = "";
        }

        private void ResetButtonColor()
        {
            this.panelN1RashiHead.Visible = false;
            this.panelN2RashiHead.Visible = false;
            this.panelN3RashiHead.Visible = false;
            this.panelN4RashiHead.Visible = false;
            this.panelN5RashiHead.Visible = false;
            this.panelN6RashiHead.Visible = false;
            this.panelN7RashiHead.Visible = false;
            this.panelN8RashiHead.Visible = false;
            this.panelN9RashiHead.Visible = false;
            this.panelN10RashiHead.Visible = false;
            this.panelN11RashiHead.Visible = false;
            this.panelN12RashiHead.Visible = false;

            this.labelN1.Text = "";
            this.labelN2.Text = "";
            this.labelN3.Text = "";
            this.labelN4.Text = "";
            this.labelN5.Text = "";
            this.labelN6.Text = "";
            this.labelN7.Text = "";
            this.labelN8.Text = "";
            this.labelN9.Text = "";
            this.labelN10.Text = "";
            this.labelN11.Text = "";
            this.labelN12.Text = "";
        }

        private void InitHoroscopeFlowLayout()
        {
            this.flowLayoutPanelN1.Controls.Clear();
            this.flowLayoutPanelN2.Controls.Clear();
            this.flowLayoutPanelN3.Controls.Clear();
            this.flowLayoutPanelN4.Controls.Clear();
            this.flowLayoutPanelN5.Controls.Clear();
            this.flowLayoutPanelN6.Controls.Clear();
            this.flowLayoutPanelN7.Controls.Clear();
            this.flowLayoutPanelN8.Controls.Clear();
            this.flowLayoutPanelN9.Controls.Clear();
            this.flowLayoutPanelN10.Controls.Clear();
            this.flowLayoutPanelN11.Controls.Clear();
            this.flowLayoutPanelN12.Controls.Clear();
        }

        private void InitTransitFlowLayout()
        {
            this.flowLayoutPanelT1.Controls.Clear();
            this.flowLayoutPanelT2.Controls.Clear();
            this.flowLayoutPanelT3.Controls.Clear();
            this.flowLayoutPanelT4.Controls.Clear();
            this.flowLayoutPanelT5.Controls.Clear();
            this.flowLayoutPanelT6.Controls.Clear();
            this.flowLayoutPanelT7.Controls.Clear();
            this.flowLayoutPanelT8.Controls.Clear();
            this.flowLayoutPanelT9.Controls.Clear();
            this.flowLayoutPanelT10.Controls.Clear();
            this.flowLayoutPanelT11.Controls.Clear();
            this.flowLayoutPanelT12.Controls.Clear();
        }
    }
}
