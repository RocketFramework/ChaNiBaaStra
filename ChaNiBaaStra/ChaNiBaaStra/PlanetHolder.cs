using ChaNiBaaStra.Dal.Models;
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

namespace ChaNiBaaStra
{
    

    public partial class PlanetHolder : UserControl
    {
        public PlanetHolder()
        {
            InitializeComponent();
        }

        public AstroPlanet CurrentPlanet { get; set; }

        public void UpdateUI(AstroPlanet planet, bool isNawamsa)
        {
            CurrentPlanet = planet;
            this.buttonMiddle.Text = (planet.IsReversing) ? "(" + planet.Name.Substring(0, 2) 
                + ")" : planet.Name.Substring(0, 2);
            this.labelTop.Text = planet.GetPlanetRelationToRasi(planet.Current
                , planet.NavamsaRasi.Current).ToShortString();
            this.labelTop.Tag = new String(new char[] { 'c' });
            this.labelTop.Tag = planet.GetPlanetRelationToRasi(planet.Current
                , planet.NavamsaRasi.Current).ToLongString();
        }

        public void UpdateUI(AstroPlanet planet)
        {
            CurrentPlanet = planet;
            this.buttonMiddle.Text = (planet.IsReversing) ? "(" 
                + planet.Name.Substring(0, 2) + ")" : planet.Name.Substring(0, 2);
            this.labelTop.Text = planet.GetPlanetRelationToRasi(planet.Current
                , planet.NavamsaRasi.Current).ToShortString();
            this.labelTop.Tag = new String(new char[] { 'c' });
            this.labelTop.Tag = planet.GetPlanetRelationToRasi(planet.Current
                , planet.NavamsaRasi.Current).ToLongString();

            // Astha mean weaken by the bright light of the sun
            // 
            this.labelBottom.Text = "";
            if (planet.IsVargoththama)
            {
                if (planet.IsNivrutha && planet.IsAstha)
                    this.labelBottom.Text = "VR | NIV | AST";
                else if (planet.IsAstha)
                    this.labelBottom.Text = "VR | AST";
                else
                    this.labelBottom.Text = "VR";
            }
            else
            {
                if (planet.IsNivrutha && planet.IsAstha)
                    this.labelBottom.Text = "NIV | AST";
                else if (planet.IsAstha)
                    this.labelBottom.Text = "AST";
                else
                    this.labelBottom.Text = "NIV";
            }
            this.labelTop.Text = planet.PlanetRasiRelation.ToShortString();
            if (planet.IsDigbala)
                this.buttonMiddle.BackColor = Color.GreenYellow;
        }

        private void labelBottom_MouseHover(object sender, EventArgs e)
        {
            string s = "The planet is";
            if (((Label)sender).Text.Contains("NIV")) s += ", in 'Nirvruthththa' state";
            if (((Label)sender).Text.Contains("AST")) s += ", in 'Astha' (Weaken by the bright Sun) state";
            if (((Label)sender).Text.Contains("VR")) s += ", in 'Vargoththama' (Planet has the same Rasi in both Navamsa and Natal Chart) state";
            this.toolTipPlanet.SetToolTip((Label)sender, s);
        }

        private void labelTop_MouseHover(object sender, EventArgs e)
        {
            this.toolTipPlanet.SetToolTip((Label)sender, this.labelTop.Tag.ToString());
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        { }

        private void buttonMiddle_MouseHover(object sender, EventArgs e)
        {
            this.toolTipPlanet.Show(CurrentPlanet.GetPlanetQuality(), (Button)sender, 10000);
        }
    }
}
