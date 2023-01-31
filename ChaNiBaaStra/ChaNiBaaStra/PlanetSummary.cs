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

        public void UpdateHoroscope(DateTime birthDate, int maleProb, string nakath)
        {
            this.textBoxBirthDate.Text = birthDate.ToString("yyyy/mm/dd - hh:MM");
            this.textBoxMaleProb.Text = maleProb.ToString();
            this.textBoxNakath.Text = nakath;
        }
    }


}
