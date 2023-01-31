using ChaNiBaaStra.Calculator;
using ChaNiBaaStra.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ChaNiBaaStra
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            UiInit();
        }
        private AstroCalculator birthCalculator;
        private AppDataObject appDataObject;
        private void UiInit()
        {
            birthCalculator = new AstroCalculator(new DataModels.AstroPlace("", "", 6.9271, 79.8612, new System.DateTime(1975, 7, 2, 12, 34, 1)));
            List<AstroPlanet> birthPlantes = birthCalculator.CalculatePlanetPositionWithDetailsOptmized();
            Horoscope birthHoroscope = birthCalculator.CalculateHoroscope(birthPlantes);
            birthHoroscope.CurrentTransitDate = birthCalculator;
            this.horoscopeFullView1.CurrentHoroscope = birthHoroscope;
            UpdateforTransit(System.DateTime.Now);
            this.horoscopeFullView1.UiInit();
            this.planetSummary1.UpdateHoroscope(birthHoroscope.CurrentTransitDate.CurrentDateTime
                , birthHoroscope.IsMaleHoroscope(), birthHoroscope.Nakath.Name);
        }

        public void UpdateforTransit(DateTime dateTime)
        {
            AstroCalculator transitCalculator = new 
                AstroCalculator(new DataModels.AstroPlace("", "", 6.9271, 79.8612, dateTime));
            List<AstroPlanet> transitPlantes = transitCalculator
                .CalculatePlanetPositionWithDetailsOptmized();
            if (birthCalculator != null)
            {
                Horoscope transitHoroscope = birthCalculator
                    .CalculateHoroscope(transitPlantes);
                transitHoroscope.CurrentTransitDate = transitCalculator;
                this.horoscopeFullView1.TransitHoroscope = transitHoroscope;
                this.horoscopeFullView1.PartialUiInit();
            }
        }

        public void UpdateForPlanet(double planetDeg, string nakath, string nawamsa)
        {
            this.planetSummary1.UpdatePlanet(planetDeg.ToString(), nakath, nawamsa);
        }

        private DateTime originalValue = System.DateTime.Now;
        private void trackBarDate_ValueChanged(object sender, EventArgs e)
        {
            this.datePicker.Value = originalValue.AddDays(this.trackBarDate.Value);
            UpdateforTransit(this.datePicker.Value);
        }

        private void buttonSetDate_Click(object sender, EventArgs e)
        {
            originalValue = this.datePicker.Value;
            this.trackBarDate.Value = 100;
            UpdateforTransit(originalValue);
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            originalValue = System.DateTime.Now;
        }

        private void radioButtonBhavaOn_CheckedChanged(object sender, EventArgs e)
        {
            horoscopeFullView1.IsBhavaView = (radioButtonBhavaOn.Checked);
            horoscopeFullView1.UiInit();
            horoscopeFullView1.PartialUiInit();
        }

        private void stripMenuItem_Click(object sender, EventArgs e)
        {
            switch (((ToolStripItem)sender).Text)
            {
                case "Birth Date": break;
            }
        }
    }
}
