using ChaNiBaaStra.Calculator;
using ChaNiBaaStra.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Security.Cryptography;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms;

namespace ChaNiBaaStra
{
    public partial class Form1 : Form
    {
        public DateTime TransitDate { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*this.Country = "Sri Lanka";
            this.City = "Colombo";
            this.Longitude = 79.861244;
            this.Latitude = 6.9271;
            this.TimeZone = -1 * Longitude / 15.0;
            int[] tz = AstroUtility.GetDegreeMinuteSeconds(TimeZone);
            this.TimeZoneString = tz[0].ToString() + ":" + tz[1];

            this.birthDateTime = new DateTime(1975, 7, 2, 12, 34, 0);*/
           /* AstroTransitDate date = new AstroTransitDate(new DataModels.AstroPlace(), false);
            List<AstroPlanet> plantes = date.CalculatePlanetPosition();
            Horoscope hsc = date.CalculateHoroscope(plantes);*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TransitDate = DateTime.Now;

            using (var form = new GetBirthData())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    AstroCalculator birthCalculator = new AstroCalculator(new DataModels.AstroPlace("", "", form.Latitude, form.Longitute, form.BirthTime));
                    AstroCalculator transitCalculator = new AstroCalculator(new DataModels.AstroPlace("", "", form.Latitude, form.Longitute, System.DateTime.Now));
                    //AstroTransitDate birthDate = new AstroTransitDate(new DataModels.AstroPlace("", "", form.Latitude, form.Longitute, form.BirthTime), false);
                    //AstroTransitDate transitDate = new AstroTransitDate(new DataModels.AstroPlace("", "", form.Latitude, form.Longitute, TransitDate), false);

                    List<AstroPlanet> birthPlantes = birthCalculator.CalculatePlanetPositionWithDetailsOptmized();
                    List<AstroPlanet> transitPlantes = transitCalculator.CalculatePlanetPositionWithDetailsOptmized();


                    //System.Threading.Thread.Sleep(2300);
                    //List<AstroPlanet> transitPlantes = transitDate.CalculatePlanetPositionWithDetailsOptmized();

                    Horoscope birthHoroscope = birthCalculator.CalculateHoroscope(birthPlantes);
                    birthHoroscope.CurrentTransitDate = birthCalculator; 
                   
                    Horoscope transitHoroscope = birthCalculator.CalculateHoroscope(transitPlantes);
                    transitHoroscope.CurrentTransitDate = transitCalculator;
                    //Horoscope transitHoroscope = birthDate.CalculateHoroscope(transitPlantes);

                    this.horoscopeView1.UpdateUI(birthHoroscope, true);
                    this.horoscopeView2.UpdateUI(birthHoroscope, false);
                    var bindingList = new BindingList<AstroDasa>(birthHoroscope.AstroDasaDetails.FutureDasas);
                    var source = new BindingSource(bindingList, null);
                    this.dataGridView1.DataSource = source;
                }
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            var rowsCount = dataGridView1.SelectedRows.Count;
            if (rowsCount == 0 || rowsCount > 1) return;
            var row = dataGridView1.SelectedRows[0];
            AstroDasa dasa = ((AstroDasa)row.DataBoundItem);

            if (row == null) return;
            var bindingList = new BindingList<AstroDasa>(dasa.AthuruDasas);
            var source = new BindingSource(bindingList, null);
            this.dataGridView2.DataSource = source;
        }
    }
}
