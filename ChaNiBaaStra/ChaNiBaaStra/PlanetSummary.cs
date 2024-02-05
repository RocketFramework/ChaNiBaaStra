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
    public partial class PlanetSummary : UserControl
    {
        public PlanetSummary()
        {
            InitializeComponent();
        }
        public void UpdatePlanet(string planetDeg, string planetNak, string planetNaw)
        {
            this.textBoxPlanetDegrees.Text = planetDeg;
            this.textBoxPlanetNakath.Text = planetNak;
            this.textBoxPlanetNawamsa.Text = planetNaw;
        }

        public void UpdateHoroscope(DateTime birthDate, int maleProb, string nakath, int isMale, AstroPlanet mostPowerfulPlanet)
        {
            this.textBoxBirthDate.Text = birthDate.ToString("yyyy/MM/dd - hh:mm");
            this.textBoxMaleProb.Text = maleProb.ToString();
            this.textBoxNakath.Text = nakath;
            this.textBoxMaleProb.Text = isMale + "%";
            if (mostPowerfulPlanet != null)
            {
                this.buttonPowerfullPlanet.Text = mostPowerfulPlanet.Name;
                this.buttonPowerfullPlanet.Tag = mostPowerfulPlanet;
            }
            else
                this.buttonPowerfullPlanet.Text = "None";
        }

        private void buttonPowerfullPlanet_Click(object sender, EventArgs e)
        {    
            if (this.buttonPowerfullPlanet.Tag != null)
            {
                AstroPlanet mostPowerfulPlanet = (AstroPlanet)this.buttonPowerfullPlanet.Tag;
                MessageBox.Show(mostPowerfulPlanet.Identity.ToString()
                    , "Personality Types", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }


}
