using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChaNiBaaStra.Calculator;
using ChaNiBaaStra.Dal.Models;
using ChaNiBaaStra.DataModels;
using ChaNiBaaStra.Utilities;

namespace ChaNiBaaStra
{
    public delegate void ButtonClicked(object sender, EventArgs e);
    public partial class PlanetView : UserControl
    { 
        public ButtonClicked PlanetButtonClicked { get; set; }
        public string PlanetButtonToolTip = "";
        public bool ISeeYou {
            get { return this.panelOtherPlanetSeeMe.Visible; }
            set { this.panelOtherPlanetSeeMe.Visible = value; }
        }

        private AstroPlanet thisPlanet;
        public AstroPlanet ThisPlanet { get{ return thisPlanet; } set { thisPlanet = value;
                this.thisPlanet.IsTransitPlanet = IsTransitPlanet;
            } }
        public AstroRasi ThisRasi { get; set; }

        public bool IsTransitPlanet { get; set; }

        private AstroPlanet relatedPlanet;
        public AstroPlanet RelatedPlanet {
            get
            {
                return relatedPlanet;
            }
            set
            {
                relatedPlanet = value;
                if (value == null)
                    this.buttonPlnet.BackColor = SystemColors.Window;
                else
                    this.buttonPlnet.BackColor = SystemColors.ControlDark;
            }
        }

        public PlanetView()
        {
            InitializeComponent();
        }

        public void Reset()
        {
            if (this.ThisPlanet != null)
            {
                if (this.ThisPlanet.Rasi.Current == this.RelatedPlanet.Rasi.Current)
                    return;

                if (this.ISeeYou)
                    this.panelOtherPlanetSeeMe.Visible = true;
                else
                    this.panelOtherPlanetSeeMe.Visible = false;

                if (this.ThisPlanet.IsVargoththama)
                    this.panelVargoththama.Visible = true;
                else
                    this.panelVargoththama.Visible = false;

                if (this.RelatedPlanet != null)
                    this.buttonPlanetRelation.BackColor = this.ThisPlanet
                        .GetPlanetRelation(this.relatedPlanet.Current).ToColor();
            }
        }

        public void UpdateButtonNobe(bool isReset)
        {
            if (isReset)
            {
                ResetTxtForViewsSeesRelatedNobe();
            }
            else if (this.RelatedPlanet != null)
            {
                UpdateTxtForViewsSeesRelatedNobe(this.relatedPlanet);
            }
        }

        public void UpdateTxtForViewsSeesRelatedNobe(AstroPlanet relatingPlanet)
        {
            if (relatingPlanet != null)
            {
                this.buttonPlanetRelation.BackColor = this.ThisPlanet
                    .GetPlanetRelation(relatingPlanet.Current).ToColor();
                this.toolTipPlanet.SetToolTip(this.buttonPlanetRelation, this.ThisPlanet
                    .GetPlanetRelation(relatingPlanet.Current).ToLongString(relatingPlanet.Name));
            }
        }

        public void ResetTxtForViewsSeesRelatedNobe()
        {
            this.buttonPlnet.BackColor = Color.Transparent;
            this.buttonPlanetRelation.BackColor = Color.Transparent;
            this.toolTipPlanet.SetToolTip(this.buttonPlanetRelation, null);
        }

        internal void UpdateUI(AstroPlanet planet)
        {
            this.BackColor= Color.Transparent;
            ThisPlanet = planet;
            ThisRasi = planet.Rasi;
            this.buttonPlnet.Text = (planet.IsReversing) ?
                "(" + planet.Name.Substring(0, 2)
                + ")" : planet.Name.Substring(0, 2);
            this.buttonRashiRelation.BackColor = planet.PlanetRasiRelation.ToColor();
            this.toolTipPlanet.SetToolTip(this.buttonRashiRelation
                , planet.PlanetRasiRelation.ToLongString());
            this.panelVargoththama.Visible = planet.IsVargoththama;
            this.Font = new Font(FontFamily.GenericSerif, 8);
            this.buttonPlnet.Width = 35;
            this.buttonPlnet.Height = 25;

            if (planet.IsMarakaPlanet)
                PlanetButtonToolTip += " 2 or 8 Adhipathi - Maraka Planet ";

            if (planet.IsRogaPlanet)
                PlanetButtonToolTip += " 6 or 12 Adhipathi - Roga Planet ";

            this.toolTipPlanet
                .SetToolTip(this.buttonPlnet, this.PlanetButtonToolTip 
                + "\r\n" + ThisPlanet.GetSpecialMessages());
        }

        public void ICanSeeThem(AstroPlanet clickedPlanet)
        {
            this.buttonPlnet.BackColor = Color.Yellow;
            this.buttonPlnet.ForeColor = Color.Blue;
            this.buttonPlnet.Font = new Font(this.buttonPlnet.Font, FontStyle.Bold);
            UpdateTxtForViewsSeesRelatedNobe(clickedPlanet);
        }

        public void ICantSeeThem()
        {
            this.buttonPlnet.BackColor = Color.Transparent;
            this.buttonPlnet.ForeColor = Color.Black;
            this.buttonPlnet.Font = new Font(this.buttonPlnet.Font, FontStyle.Regular);
            ResetTxtForViewsSeesRelatedNobe();
        }

        public void TheyCanSeeMe(AstroPlanet clickedPlanet)
        {
            this.panelOtherPlanetSeeMe.Visible = true;
            UpdateTxtForViewsSeesRelatedNobe(clickedPlanet);
        }

        public void TheyCantSeeMe()
        {
            this.panelOtherPlanetSeeMe.Visible = false;
            ResetTxtForViewsSeesRelatedNobe();
        }

        private void buttonPlnet_Click(object sender, EventArgs e)
        {
            this.RelatedPlanet = ThisPlanet;
            if (PlanetButtonClicked != null)
                PlanetButtonClicked(this, e);
        }
    }
}
