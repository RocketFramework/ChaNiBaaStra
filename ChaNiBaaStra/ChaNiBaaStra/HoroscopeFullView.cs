﻿using ChaNiBaaStra.DataModels;
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
using ChaNiBaaStra.DataModels.Varga;
using ChaNiBaaStra.Calculator;

namespace ChaNiBaaStra
{
    public partial class HoroscopeFullView : UserControl
    {
        public Horoscope CurrentHoroscope { get; set; }
        public D9Chart NawamsaHoroscope { get; set; }
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
            UpdateMessages();
        }

        public void SetAsktakaVarga(AstroPlanet clickedPlanet)
        {
            if (clickedPlanet.IsTransitPlanet)
            {
                AstakaVargaMaster varga = new AstakaVargaMaster(CurrentHoroscope.CompletePlanetList);
                switch (clickedPlanet.Current)
                {
                    case EnumPlanet.Sun: SetVarga(varga.SunVarga); break;
                    case EnumPlanet.Moon: SetVarga(varga.MoonVarga); break;
                    case EnumPlanet.Mars: SetVarga(varga.MarVarga); break;
                    case EnumPlanet.Mercury: SetVarga(varga.MercuryVarga); break;
                    case EnumPlanet.Jupiter: SetVarga(varga.JupiterVarga); break;
                    case EnumPlanet.Venus: SetVarga(varga.VenusVarga); break;
                    case EnumPlanet.Saturn: SetVarga(varga.SaturnVarga); break;
                }
            }
        }

        private void SetVarga(AshtakaVargayaBase baseVargaCalculator)
        {
            for (int i = 0; i < 12; i++)
            {
                Label labelN = (this.Controls.OfType<Label>())
                    .Where(x => x.Name == "labelAsktakaVarga" + (i + 1)).FirstOrDefault();
                labelN.Text = baseVargaCalculator.AshtakaVargaList[i].ToString();
            }
        }

        private void UpdateMessages()
        {
            for (int i = 1; i <= 12; i++)
            {
                FlowLayoutPanel laoutPanelN = (this.Controls.OfType<FlowLayoutPanel>())
                .Where(x => x.Name == "flowLayoutPanelN" + i).FirstOrDefault();
                if (laoutPanelN != null)
                {
                    string message = this.CurrentHoroscope.RasiHouseList
                        .Where(x => x.HouseNumber == i).FirstOrDefault().GetPowerBasedOnViews();
                    this.toolTipFullView.SetToolTip(laoutPanelN
                        , message);
                    laoutPanelN.Tag = message;
                }
                FlowLayoutPanel laoutPanelT = (this.Controls.OfType<FlowLayoutPanel>())
                .Where(x => x.Name == "flowLayoutPanelT" + i).FirstOrDefault();
                if (laoutPanelT != null)
                {
                    string message = this.TransitHoroscope.RasiHouseList
                        .Where(x => x.HouseNumber == i).FirstOrDefault().GetPowerBasedOnViews();
                    this.toolTipFullView.SetToolTip(laoutPanelT
                        , message);
                    laoutPanelT.Tag = message;
                }
            }
        }

        private void InitNawamsaHoroscope()
        {
            this.labelNawamsa.Text = CurrentHoroscope.NavamsaRasi.Name
                + "\r\nN (" + CurrentHoroscope.NavamsaRasi.AdhipathiEnumPlanets.FirstOrDefault()
                + ") " + Math.Truncate(CurrentHoroscope.NavamsaRasi.RasiEndDegreesFromHorizon)
                + "°";

            ResetLabels();
            if (IsBhavaView)
                foreach (AstroBhava rasi in CurrentHoroscope.BhavaHouseList)
                {
                    CreateNawamsaHoroscope(rasi.Planets);
                }
            else
                foreach (AstroRasi rasi in CurrentHoroscope.RasiHouseList)
                {
                    CreateNawamsaHoroscope(rasi.Planets); 
                }
        }

        private void CreateNawamsaHoroscope(List<AstroPlanet> planets)
        {            
            //NawamsaHoroscope.Planets.AddRange(planets);
            foreach (AstroPlanet planet in planets)
            {
                int houseNumber = CurrentHoroscope
                    .NavamsaRasi.ofRasi(planet.NawamsaRasi.Current);
                switch (houseNumber)
                {
                    case 1:
                        {
                            //CreateHouseObject(NawamsaHoroscope.House1, planet);
                            updateNawamsa(this.labelNW1, planet.ShortName);
                        }
                        break;
                    case 2:
                        {
                            //CreateHouseObject(NawamsaHoroscope.House2, planet);
                            updateNawamsa(this.labelNW2, planet.ShortName);
                        }
                        break;
                    case 3:
                        //CreateHouseObject(NawamsaHoroscope.House3, planet);
                        updateNawamsa(this.labelNW3, planet.ShortName);
                        break;
                    case 4:
                        //CreateHouseObject(NawamsaHoroscope.House4, planet);
                        updateNawamsa(this.labelNW4, planet.ShortName);
                        break;
                    case 5:
                        //CreateHouseObject(NawamsaHoroscope.House5, planet);
                        updateNawamsa(this.labelNW5, planet.ShortName);
                        break;
                    case 6:
                        //CreateHouseObject(NawamsaHoroscope.House6, planet);
                        updateNawamsa(this.labelNW6, planet.ShortName);
                        break;
                    case 7:
                        //CreateHouseObject(NawamsaHoroscope.House7, planet);
                        updateNawamsa(this.labelNW7, planet.ShortName);
                        break;
                    case 8:
                        //CreateHouseObject(NawamsaHoroscope.House8, planet);
                        updateNawamsa(this.labelNW8, planet.ShortName);
                        break;
                    case 9:
                        //CreateHouseObject(NawamsaHoroscope.House9, planet);
                        updateNawamsa(this.labelNW9, planet.ShortName);
                        break;
                    case 10:
                        //CreateHouseObject(NawamsaHoroscope.House10, planet);
                        updateNawamsa(this.labelNW10, planet.ShortName);
                        break;
                    case 11:
                        //CreateHouseObject(NawamsaHoroscope.House11, planet);
                        updateNawamsa(this.labelNW11, planet.ShortName);
                        break;
                    case 12:
                        //CreateHouseObject(NawamsaHoroscope.House12, planet);
                        updateNawamsa(this.labelNW12, planet.ShortName);
                        break;
                }
            }
        }

        /*private void CreateHouseObject(House house, AstroPlanet planet)
        {
            house = House.GetInstance().Set(planet.NawamsaRasi);
            house.HouseRasi = planet.NawamsaRasi;
            house.HousePlanets.Add(planet);
        }*/

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
                + "\r\nT (" + TransitHoroscope.LagnaRasi.AdhipathiEnumPlanets.FirstOrDefault()
                + ") " + Math.Truncate(TransitHoroscope.LagnaRasi.RasiEndDegreesFromHorizon)
                + "°";

            if (IsBhavaView)
                foreach (AstroBhava rasi in TransitHoroscope.BhavaHouseList)
                    CreateTransitHoroscope(rasi.BhavaNumber, rasi.Planets.OrderBy(x => x.AjustedLongitude).ToList());
            else
                foreach (AstroRasi rasi in TransitHoroscope.RasiHouseList)
                {
                    CreateTransitHoroscope(rasi.HouseNumber, rasi.Planets.OrderBy(x => x.AjustedLongitude).ToList());
                }
            //CreateTransitHoroscope(AstroUtility.AstroCycleIncreaseNew(rasi.HouseNumber, Math.Abs(TransitHoroscope.LagnaRasi.CurrentInt - CurrentHoroscope.LagnaRasi.CurrentInt+1)), rasi.Planets.OrderBy(x => x.AjustedLongitude).ToList());
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
                + "\r\nL (" + CurrentHoroscope.LagnaRasi.AdhipathiEnumPlanets.FirstOrDefault()
                + ") " + CurrentHoroscope.LagnaRasi.RasiEndDegreesFromHorizon.ToDegreeString();
            if (IsBhavaView)
                foreach (AstroBhava rasi in CurrentHoroscope.BhavaHouseList)
                {
                    CeateBavaHoroscope(rasi, rasi.Planets.OrderBy(x => x.AjustedLongitude).ToList());
                }
            else
                foreach (AstroRasi rasi in CurrentHoroscope.RasiHouseList)
                {
                    CreateRashiHoroscope(rasi, rasi.Planets.OrderBy(x => x.AjustedLongitude).ToList());

                }
        }

        private void CeateBavaHoroscope(AstroBhava rasi, List<AstroPlanet> planets)
        {
            UpdateLoard(rasi);
            CeateHoroscope(rasi.BhavaNumber, planets);
        }

        private void CreateRashiHoroscope(AstroRasi rasi, List<AstroPlanet> planets)
        {
            UpdateLoard(rasi);
            UpdateAdhipathi(rasi);
            CeateHoroscope(rasi.HouseNumber, planets);
        }

        private void UpdateLoard(AstroRasi rasi)
        {
            Label labelLord = (this.Controls.OfType<Label>())
                .Where(x => x.Name == "labelLord" + rasi.HouseNumber).FirstOrDefault();
            labelLord.Text = rasi.Loard.ShortName + " ♔";
            AstroPlanet adhipathi = rasi.AdhipathiAstroPlanets.Last();
            if (rasi.Loard.Current == adhipathi.Current)
                labelLord.Text += "♕";
        }

        private void UpdateAdhipathi(AstroRasi rasi)
        {
            AstroPlanet adhipathi = rasi.AdhipathiAstroPlanets.Last();
            if (rasi.Loard.Current != adhipathi.Current)
            {
                Label labelAdhipathi = (this.Controls.OfType<Label>())
                    .Where(x => x.Name == "labelAdhipathi" + rasi.HouseNumber).FirstOrDefault();
                labelAdhipathi.Text = rasi.AdhipathiAstroPlanets.Last().ShortName + " ♕";
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
        PlanetView pViewClicked;
        public void SomePlanetClicked(object sender, EventArgs e)
        {
            pViewClicked = (PlanetView)sender;
            SetAsktakaVarga(pViewClicked.ThisPlanet);
            ((ChaniBhastraSecret)this.Parent.Parent.Parent).UpdateDisplayPlanetMessages(pViewClicked.ThisPlanet, this.IsBhavaView);

            if (planetHolders.Count == 0)
            {
                planetHolders.Add(pViewClicked);
                planetHolders[0].RelatedPlanet = planetHolders[0].ThisPlanet;

                if (pViewClicked.ThisPlanet.Views.TheyCanSeeMee != null)
                    foreach (AstroPlanet view in pViewClicked.ThisPlanet.Views.TheyCanSeeMee)
                        UpdateForTheyCanSeeMee(view, pViewClicked.IsTransitPlanet);
            }
            else if (planetHolders.Count == 1)
            {
                planetHolders.Add(pViewClicked);
                planetHolders[0].RelatedPlanet = planetHolders[1].ThisPlanet;
                planetHolders[1].RelatedPlanet = planetHolders[0].ThisPlanet;

                ResetButtonColorUpdate();

                if ((pViewClicked.ThisPlanet.Name == planetHolders[0].Name)
                    && (pViewClicked.IsTransitPlanet == planetHolders[0].IsTransitPlanet)
                     && (pViewClicked.ThisPlanet.Views.ICanSeeThem != null))
                    foreach (int view in planetHolders[1].ThisPlanet.Views.ICanSeeThem)
                        UpdateForICanSeeThem(view, planetHolders[1].IsTransitPlanet);
                else if (pViewClicked.ThisPlanet.Views.TheyCanSeeMee != null)
                    foreach (AstroPlanet view in pViewClicked.ThisPlanet.Views.TheyCanSeeMee)
                        UpdateForTheyCanSeeMee(view, pViewClicked.IsTransitPlanet);
            }
            else if (planetHolders.Count >= 2)
            {
                planetHolders[0].UpdateButtonNobe(true);
                planetHolders[0] = planetHolders[1];
                planetHolders[1] = pViewClicked;
                planetHolders[0].RelatedPlanet = planetHolders[1].ThisPlanet;
                planetHolders[1].RelatedPlanet = planetHolders[0].ThisPlanet;
                pViewClicked.UpdateButtonNobe(false);
                planetHolders[0].UpdateButtonNobe(false);

                ResetButtonColorUpdate();

                if ((pViewClicked.ThisPlanet.Name == planetHolders[0].ThisPlanet.Name)
                    && (pViewClicked.IsTransitPlanet == planetHolders[0].IsTransitPlanet)
                    && (pViewClicked.ThisPlanet.Views.ICanSeeThem != null))
                    foreach (int view in pViewClicked.ThisPlanet.Views.ICanSeeThem)
                        UpdateForICanSeeThem(view, pViewClicked.IsTransitPlanet);
                else if (planetHolders[1].ThisPlanet.Views.TheyCanSeeMee != null)
                    foreach (AstroPlanet view in planetHolders[1].ThisPlanet.Views.TheyCanSeeMee)
                        UpdateForTheyCanSeeMee(view, planetHolders[1].IsTransitPlanet);

                /*
                               if (pView.ThisPlanet.Views.SeeRasiHouses != null)
                               {
                                   foreach (AstroPlanet view in planetHolders[0].ThisPlanet.Views.PlanetRasiSeeMee)
                                       UpdateForResetSeeMe(view, planetHolders[0].IsTransitPlanet);
                                   foreach (AstroPlanet view in pView.ThisPlanet.Views.PlanetRasiSeeMee)
                                       UpdateForSeeMe(view, pView.IsTransitPlanet);
                               }

                               foreach (int view in planetHolders[1].ThisPlanet.Views.SeeRasiHouses)
                                   UpdateForResetHouseView(view, planetHolders[0].IsTransitPlanet);

                               if ((pView.ThisPlanet.Name == planetHolders[1].Name) && (pView.IsTransitPlanet == planetHolders[1].IsTransitPlanet))
                                   foreach (int view in planetHolders[1].ThisPlanet.Views.SeeRasiHouses)
                                       UpdateForHouseView(view, planetHolders[1].IsTransitPlanet);
                               else
                                   foreach (AstroPlanet view in pView.ThisPlanet.Views.PlanetRasiSeeMee)
                                       UpdateForSeeMe(view, pView.IsTransitPlanet);

                               if ((pView.ThisPlanet.Name == planetHolders[1].Name) && (pView.IsTransitPlanet == planetHolders[1].IsTransitPlanet))

               */
            }

            ShowAdhipathyAfterPlanetClick(pViewClicked.ThisPlanet
                , CurrentHoroscope.LagnaRasi.Current
                , pViewClicked.IsTransitPlanet);
        }

        private void ResetButtonColorUpdate()
        {
            if (planetHolders[0].ThisPlanet.Views.ICanSeeThem != null)
                foreach (int view in planetHolders[0].ThisPlanet.Views.ICanSeeThem)
                    UpdateForICantSeeThem(view, planetHolders[0].IsTransitPlanet);
            if ((planetHolders.Count > 1) && (planetHolders[1].ThisPlanet.Views.ICanSeeThem != null))
                foreach (int view in planetHolders[1].ThisPlanet.Views.ICanSeeThem)
                    UpdateForICantSeeThem(view, planetHolders[1].IsTransitPlanet);

            if (planetHolders[0].ThisPlanet.Views.TheyCanSeeMee != null)
                foreach (AstroPlanet view in planetHolders[0].ThisPlanet.Views.TheyCanSeeMee)
                    UpdateForTheyCantSeeMee(view, planetHolders[0].IsTransitPlanet);
            if ((planetHolders.Count > 1) && (planetHolders[1].ThisPlanet.Views.TheyCanSeeMee != null))
                foreach (AstroPlanet view in planetHolders[1].ThisPlanet.Views.TheyCanSeeMee)
                    UpdateForTheyCantSeeMee(view, planetHolders[1].IsTransitPlanet);
        }

        private void UpdateForICanSeeThem(int view, bool isTransitPlanet)
        {
            List<PlanetView> planetViewList = (this.Controls.OfType<FlowLayoutPanel>())
                .Where(x => x.Name == "flowLayoutPanel" + (isTransitPlanet ? "T" : "N") + view)
                .FirstOrDefault().Controls.OfType<PlanetView>().ToList();
            if (planetViewList != null)
                foreach (PlanetView planetView in planetViewList)
                    planetView.ICanSeeThem(pViewClicked.ThisPlanet);
        }

        private void UpdateForICantSeeThem(int view, bool isTransitPlanet)
        {
            List<PlanetView> planetViewList = (this.Controls.OfType<FlowLayoutPanel>())
                .Where(x => x.Name == "flowLayoutPanel" + (isTransitPlanet ? "T" : "N") + view)
                .FirstOrDefault().Controls.OfType<PlanetView>().ToList();
            if (planetViewList != null)
                foreach (PlanetView planetView in planetViewList)
                    planetView.ICantSeeThem();
        }

        private void UpdateForTheyCanSeeMee(AstroPlanet view, bool isTransit)
        {
            PlanetView planetView = (this.Controls.OfType<FlowLayoutPanel>())
                .Where(x => x.Name == "flowLayoutPanel" + (isTransit ? "T" : "N") + view.HouseNumber)
                .FirstOrDefault().Controls.OfType<PlanetView>()
                .Where(x => x.ThisPlanet.Name == view.Name).FirstOrDefault();
            if (planetView != null)
                planetView.TheyCanSeeMe(pViewClicked.ThisPlanet);
        }

        private void UpdateForTheyCantSeeMee(AstroPlanet view, bool isTransit)
        {
            PlanetView planetView = (this.Controls.OfType<FlowLayoutPanel>())
                .Where(x => x.Name == "flowLayoutPanel" + (isTransit ? "T" : "N") + view.HouseNumber)
                .FirstOrDefault().Controls.OfType<PlanetView>()
                .Where(x => x.ThisPlanet.Name == view.Name).FirstOrDefault();
            if (planetView != null)
                planetView.TheyCantSeeMe();
        }

        private void UpdateDistanceToClickedPlanet(Panel adhipathyIndicator
            , Label gapLabel, int gap, int score)
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

            foreach (int houseNumber in p.AdhipathiHouses)
            {
                /*int houseNumber = AstroUtility.AstroCycleIncrease((int)lagnaRasi
                    , (this.IsBhavaView) ? p.Bhava.absoluteGabOfRasi(rasi) : p.Rasi.absoluteGabOfRasi(rasi));
                p.AdhipathiHouses.Add(houseNumber)*/
                switch (houseNumber)
                {
                    case 1:
                        {
                            UpdateDistanceToClickedPlanet((isTransit) ? this.panelT1RashiHead
                                : this.panelN1RashiHead, (isTransit) ? this.labelT1
                                : this.labelN1, AstroUtility.HouseGab(houseNumber, (this.IsBhavaView)
                                ? p.Bhava.BhavaNumber : p.HouseNumber), p.RashiAdhipathiScore);
                            break;
                        }
                    case 2:
                        {
                            UpdateDistanceToClickedPlanet((isTransit) ? this.panelT2RashiHead
                                : this.panelN2RashiHead, (isTransit) ? this.labelT2
                                : this.labelN2, AstroUtility.HouseGab(houseNumber, (this.IsBhavaView)
                                ? p.Bhava.BhavaNumber : p.HouseNumber), p.RashiAdhipathiScore);
                            break;
                        }
                    case 3:
                        {
                            UpdateDistanceToClickedPlanet((isTransit) ? this.panelT3RashiHead
                                : this.panelN3RashiHead, (isTransit) ? this.labelT3
                                : this.labelN3, AstroUtility.HouseGab(houseNumber, (this.IsBhavaView)
                                ? p.Bhava.BhavaNumber : p.HouseNumber), p.RashiAdhipathiScore);
                            break;
                        }
                    case 4:
                        {
                            UpdateDistanceToClickedPlanet((isTransit) ? this.panelT4RashiHead
                                : this.panelN4RashiHead, (isTransit) ? this.labelT4
                                : this.labelN4, AstroUtility.HouseGab(houseNumber, (this.IsBhavaView)
                                ? p.Bhava.BhavaNumber : p.HouseNumber), p.RashiAdhipathiScore);
                            break;
                        }
                    case 5:
                        {
                            UpdateDistanceToClickedPlanet((isTransit) ? this.panelT5RashiHead
                                : this.panelN5RashiHead, (isTransit) ? this.labelT5
                                : this.labelN5, AstroUtility.HouseGab(houseNumber, (this.IsBhavaView)
                                ? p.Bhava.BhavaNumber : p.HouseNumber), p.RashiAdhipathiScore);
                            break;
                        }
                    case 6:
                        {
                            UpdateDistanceToClickedPlanet((isTransit) ? this.panelT6RashiHead
                                : this.panelN6RashiHead, (isTransit) ? this.labelT6
                                : this.labelN6, AstroUtility.HouseGab(houseNumber, (this.IsBhavaView)
                                ? p.Bhava.BhavaNumber : p.HouseNumber), p.RashiAdhipathiScore);
                            break;
                        }
                    case 7:
                        {
                            UpdateDistanceToClickedPlanet((isTransit) ? this.panelT7RashiHead
                                : this.panelN7RashiHead, (isTransit) ? this.labelT7
                                : this.labelN7, AstroUtility.HouseGab(houseNumber, (this.IsBhavaView)
                                ? p.Bhava.BhavaNumber : p.HouseNumber), p.RashiAdhipathiScore);
                            break;
                        }
                    case 8:
                        {
                            UpdateDistanceToClickedPlanet((isTransit) ? this.panelT8RashiHead
                                : this.panelN8RashiHead, (isTransit) ? this.labelT8
                                : this.labelN8, AstroUtility.HouseGab(houseNumber, (this.IsBhavaView)
                                ? p.Bhava.BhavaNumber : p.HouseNumber), p.RashiAdhipathiScore);
                            break;
                        }
                    case 9:
                        {
                            UpdateDistanceToClickedPlanet((isTransit) ? this.panelT9RashiHead
                                : this.panelN9RashiHead, (isTransit) ? this.labelT9
                                : this.labelN9, AstroUtility.HouseGab(houseNumber, (this.IsBhavaView)
                                ? p.Bhava.BhavaNumber : p.HouseNumber), p.RashiAdhipathiScore);
                            break;
                        }
                    case 10:
                        {
                            UpdateDistanceToClickedPlanet((isTransit) ? this.panelT10RashiHead
                                : this.panelN10RashiHead, (isTransit) ? this.labelT10
                                : this.labelN10, AstroUtility.HouseGab(houseNumber, (this.IsBhavaView)
                                ? p.Bhava.BhavaNumber : p.HouseNumber), p.RashiAdhipathiScore);
                            break;
                        }
                    case 11:
                        {
                            UpdateDistanceToClickedPlanet((isTransit) ? this.panelT11RashiHead
                                : this.panelN11RashiHead, (isTransit) ? this.labelT11
                                : this.labelN11, AstroUtility.HouseGab(houseNumber, (this.IsBhavaView)
                                ? p.Bhava.BhavaNumber : p.HouseNumber), p.RashiAdhipathiScore);
                            break;
                        }
                    case 12:
                        {
                            UpdateDistanceToClickedPlanet((isTransit) ? this.panelT12RashiHead
                                : this.panelN12RashiHead, (isTransit) ? this.labelT12
                                : this.labelN12, AstroUtility.HouseGab(houseNumber, (this.IsBhavaView)
                                ? p.Bhava.BhavaNumber : p.HouseNumber), p.RashiAdhipathiScore);
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

        private void flowLayoutPanelN10_MouseDown(object sender, MouseEventArgs e)
        {
            ((ChaniBhastraSecret)this.Parent.Parent.Parent).UpdateDisplayMessage(((FlowLayoutPanel)sender).Tag.ToString(), false);

            //this.((FlowLayoutPanel)sender).Tag.ToString();
        }

        private void flowLayoutPanelT1_MouseDown(object sender, MouseEventArgs e)
        {
            ((ChaniBhastraSecret)this.Parent.Parent.Parent).UpdateDisplayMessage(((FlowLayoutPanel)sender).Tag.ToString(), true);

        }

        private void labelNawamsa_Click(object sender, EventArgs e)
        {
            string message = "";
            if (NawamsaHoroscope.House1.HousePlanets.Exists(x => x.Current == EnumPlanet.Sun) ||
                NawamsaHoroscope.House5.HousePlanets.Exists(x => x.Current == EnumPlanet.Sun) ||
                NawamsaHoroscope.House9.HousePlanets.Exists(x => x.Current == EnumPlanet.Sun))
                message += "\r\nSun in 1, 5, 9th in D9. The person has rhythm, may play some musical instrument, and is very interested in music.The person may also read a lot.";

            if (NawamsaHoroscope.House1.HousePlanets.Exists(x => x.Current == EnumPlanet.Moon) ||
                NawamsaHoroscope.House5.HousePlanets.Exists(x => x.Current == EnumPlanet.Moon) ||
                NawamsaHoroscope.House9.HousePlanets.Exists(x => x.Current == EnumPlanet.Moon))
                message += "\r\nMoon in 1, 5, 9th in D9. Has a very nice voice and could be a singer.";

            if (NawamsaHoroscope.House1.HousePlanets.Exists(x => x.Current == EnumPlanet.Mars) ||
                NawamsaHoroscope.House5.HousePlanets.Exists(x => x.Current == EnumPlanet.Mars) ||
                NawamsaHoroscope.House9.HousePlanets.Exists(x => x.Current == EnumPlanet.Mars))
                message += "\r\nMars in 1, 5, 9th in D9. Short-tempered, courageous, and warrior tendencies.";

            if (NawamsaHoroscope.House1.HousePlanets.Exists(x => x.Current == EnumPlanet.Mercury) ||
                NawamsaHoroscope.House5.HousePlanets.Exists(x => x.Current == EnumPlanet.Mercury) ||
                NawamsaHoroscope.House9.HousePlanets.Exists(x => x.Current == EnumPlanet.Mercury))
                message += "\r\nMercury in 1, 5, 9th in D9. Very good speaker, does not like conflicts and is good in business";

            if (NawamsaHoroscope.House1.HousePlanets.Exists(x => x.Current == EnumPlanet.Jupiter) ||
                NawamsaHoroscope.House5.HousePlanets.Exists(x => x.Current == EnumPlanet.Jupiter) ||
                NawamsaHoroscope.House9.HousePlanets.Exists(x => x.Current == EnumPlanet.Jupiter))
                message += "\r\nJupiter in 1, 5, 9th in D9.  wise and knowledgeable. Has a lot of knowledge about various things.";

            if (NawamsaHoroscope.House1.HousePlanets.Exists(x => x.Current == EnumPlanet.Saturn) ||
                NawamsaHoroscope.House5.HousePlanets.Exists(x => x.Current == EnumPlanet.Saturn) ||
                NawamsaHoroscope.House9.HousePlanets.Exists(x => x.Current == EnumPlanet.Saturn))
                message += "\r\nSaturn in 1, 5, 9th in D9. Hard-working, traditional and orthodox.";

            if (NawamsaHoroscope.House1.HousePlanets.Exists(x => x.Current == EnumPlanet.Venus) ||
                NawamsaHoroscope.House5.HousePlanets.Exists(x => x.Current == EnumPlanet.Venus) ||
                NawamsaHoroscope.House9.HousePlanets.Exists(x => x.Current == EnumPlanet.Venus))
                message += "\r\nVenus in 1, 5, 9th in D9. Eye for details, artistic abilities, photographic memory, better with faces than names.";

            if (NawamsaHoroscope.House1.HousePlanets.Exists(x => x.Current == EnumPlanet.Rahu) ||
                NawamsaHoroscope.House5.HousePlanets.Exists(x => x.Current == EnumPlanet.Rahu) ||
                NawamsaHoroscope.House9.HousePlanets.Exists(x => x.Current == EnumPlanet.Rahu))
                message += "\r\nRahu in 1, 5, 9th in D9. Ability to handle big machines without fear. Skilled in research, philosophy, and mathematics.";

            if (NawamsaHoroscope.House1.HousePlanets.Exists(x => x.Current == EnumPlanet.Kethu) ||
                NawamsaHoroscope.House5.HousePlanets.Exists(x => x.Current == EnumPlanet.Kethu) ||
                NawamsaHoroscope.House9.HousePlanets.Exists(x => x.Current == EnumPlanet.Kethu))
                message += "\r\nKethu in 1, 5, 9th in D9. Great with mobile devices, computers, and electronics. Very spiritual and has the capability to show the path for people.";

            AstroRasi rasi = CurrentHoroscope.RasiHouseList.FirstOrDefault(x => x.HouseNumber == 9);
            if (rasi.Loard.IsExtremelyExaltedInRashi(rasi.Loard.NawamsaRasi.Current) || rasi.Loard.IsExaltedInRashi(rasi.Loard.NawamsaRasi.Current))
                message += "\r\nLoard of 9th house " + rasi.Loard.Name + " of D1 chart is exalted in the D9 chart. It signifies great fortune";
            else if (rasi.Loard.IsExtremelyDebilitatedInRashi(rasi.Loard.NawamsaRasi.Current) || rasi.Loard.IsExtremelyDebilitatedInRashi(rasi.Loard.NawamsaRasi.Current))
                message += "\r\nLoard of 9th house " + rasi.Loard.Name + " of D1 chart is deblitated in the D9 chart. You may have to work harder and life could be challenging";

            if (NawamsaHoroscope.CurrentLagnaRashi.Loard.IsExtremelyExaltedInRashi(NawamsaHoroscope.CurrentLagnaRashi.Loard.NawamsaRasi.Current) || NawamsaHoroscope.CurrentLagnaRashi.Loard.IsExaltedInRashi(rasi.Loard.NawamsaRasi.Current) || NawamsaHoroscope.CurrentLagnaRashi.Loard.PlanetRasiRelation == EnumPlanetRasiRelationTypes.Swashesthra)
                message += "\r\nLoard of D9 " + NawamsaHoroscope.CurrentLagnaRashi.Loard.Name + " is exalted or in own house. Add strength to the chart";

            if (NawamsaHoroscope.CurrentLagnaRashi.Current == CurrentHoroscope.LagnaRasi.Current)
                message += "\r\nD9 lagna " + NawamsaHoroscope.CurrentLagnaRashi.Name + " is vargottama, therefore it promises a long life.";

            if (NawamsaHoroscope.CurrentLagnaRashi.GetIncrementRashi(7) == CurrentHoroscope.NavamsaRasi.Current)
                message += "\r\nNavamsha lagna " + CurrentHoroscope.NavamsaRasi.Name + " is in the 8th house of Rashi lagna. So there will be one setback in your life which will make you very spiritual.";

            if (NawamsaHoroscope.House10.HousePlanets.Exists(x => x.MelificOrBenific == PlanetTypes.Melific))
                message += "\r\nThe 10th house in d9 shows the flow of money or income. You have malefic planets here so the wealth may be fluctuating.";
            else if (NawamsaHoroscope.House10.HousePlanets.Exists(x => x.MelificOrBenific == PlanetTypes.Benefic))
                message += "\r\nThe 10th house in d9 shows the flow of money or income. You have benefic planets here so the wealth may flow steadilly.";

            if (NawamsaHoroscope.House7.HousePlanets.Exists(x => x.MelificOrBenific == PlanetTypes.Melific))
                message += "\r\nMalefic planets placed in the 7th house of the D9 chart. Can create problems in relationships.";
            else if (NawamsaHoroscope.House7.HousePlanets.Exists(x => x.MelificOrBenific == PlanetTypes.Benefic))
                message += "\r\nBenefic planets placed in the 7th house of the D9 chart. It is good for relationships.";

            List<AstroPlanet> planets = NawamsaHoroscope.Planets.FindAll(x => x.NawamsaRasi.Current == EnumRasi.Thula || x.NawamsaRasi.Current == EnumRasi.Vrishabha);
            if (planets.Count > 0)
                foreach (AstroPlanet p in planets)
                    message += "\r\n Your life style influenced by the previous birth is  " + p.GetPlanetQuality();
            EnumPlanet enumSaniNawamsaLoardPlanet = NawamsaHoroscope.Planets.FirstOrDefault(x => x.Current == EnumPlanet.Saturn).NawamsaRasi.Loard.Current;
            AstroPlanet saniNawamsaLoardPlanet = CurrentHoroscope.CompletePlanetList.FirstOrDefault(x => x.Current == enumSaniNawamsaLoardPlanet);
            if (saniNawamsaLoardPlanet.IsVargoththama || saniNawamsaLoardPlanet.IsPowerful)
                message += "\r\nThe rashi load (" + saniNawamsaLoardPlanet.Name + ") of D9 where Saturn is placed either vargoththama or well placed. You will somehow come out of suffering and pain in life";

            if (NawamsaHoroscope.House1.HouseRasi.Loard.IsPowerful)
                message += "\r\nStrong Navamsa lagna lord, " + NawamsaHoroscope.House1.HouseRasi.Loard.Name + " in Rashi (D1) chart promises good health";
            if (NawamsaHoroscope.House10.HouseRasi.Loard.IsPowerful)
                message += "\r\n10th house lord of Navamsa, " + NawamsaHoroscope.House10.HouseRasi.Loard.Name + " is strong in Rashi so it promises great wealth";
            if (NawamsaHoroscope.House4.HouseRasi.Loard.IsPowerful)
                message += "\r\n4th house lord of Navamsa, " + NawamsaHoroscope.House4.HouseRasi.Loard.Name + " is strong in Rashi so it is great for spirituality";
            if (NawamsaHoroscope.House7.HouseRasi.Loard.IsPowerful)
                message += "\r\n7th house lord of Navamsa, " + NawamsaHoroscope.House7.HouseRasi.Loard.Name + " is strong in Rashi so it is  good for joy and happiness in life";
            AstroPlanet moonPlanet = NawamsaHoroscope.Planets.FirstOrDefault(x => x.Current == EnumPlanet.Moon);

            message += "\r\nMoon Khara Nawamsa =" + CurrentHoroscope.GetKharaNavamsa(EnumPlanet.Moon) + ", The Loard (Look for depression, diseases or problems related with water or even death) = " + CurrentHoroscope.GetKharaNavamsaLoard(EnumPlanet.Moon).Name;
            message += "\r\nLagna Khara Nawamsa =" + CurrentHoroscope.GetLagnaKharaNawamsa() + ", The Loard (Look for diseases, accidents or physical pains in their Dasha or Antardasha) = " + CurrentHoroscope.GetLagnaKharakaNawamsaLoard().Name;
            message += "\r\nKhara Nawamsa =" + NawamsaHoroscope.House4.HouseRasi.Name + ", The planets (Look for diseases, accidents or physical pains in its Dasha or Antardasha) =" + NawamsaHoroscope.House4.HousePlanets.ToAstroPlanetShortString();

            if (CurrentHoroscope.NavamsaRasi.Current == CurrentHoroscope.LagnaRasi.GetIncrementRashi(11))
                message += "\r\nThe person will be core and awful.";
            if (CurrentHoroscope.NavamsaRasi.Current == CurrentHoroscope.LagnaRasi.GetIncrementRashi(8))
                message += "\r\nThe person will be passionate.";
            if (CurrentHoroscope.NavamsaRasi.Current == CurrentHoroscope.LagnaRasi.GetIncrementRashi(10))
                message += "\r\nThe person will obtain moksha.";
            if (CurrentHoroscope.NavamsaRasi.Current == CurrentHoroscope.LagnaRasi.GetIncrementRashi(6))
                message += "\r\nThe person will not be ethical.";

            this.toolTipFullView.SetToolTip(labelNawamsa, message);
        }
    }
}
