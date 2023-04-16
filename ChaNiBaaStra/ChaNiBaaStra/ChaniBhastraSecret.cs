using ChaNiBaaStra.Calculator;
using ChaNiBaaStra.Configuration;
using ChaNiBaaStra.DataModels;
using ChaNiBaaStra.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ChaNiBaaStra
{
    public partial class ChaniBhastraSecret : Form
    {
        public ChaniBhastraSecret()
        {
            InitializeComponent();
            birthPlace = new AstroPlace();
            transitPlace = new AstroPlace();
            transitPlace.OriginalDateTime = DateTime.Now;
            UiInit(birthPlace);
            IsBirthDateTimeChange = false;
        }

        public AstroPlace birthPlace;
        public AstroPlace transitPlace;
        public double Logitude { get; set; }
        public double Latitude { get; set; }
        public string PersonName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public bool IsMale { get; set; }
        public bool IsBirthDateTimeChange { get; set; }
        public bool IsTransitDateTimeChange { get; set; }

        private AstroCalculator birthCalculator;
        private AstroCalculator transitCalculator;
        private AppDataObject appDataObject;
        private TextAnalyzer analyzer = new TextAnalyzer();
        Horoscope birthHoroscope;
        Horoscope transitHoroscope;
        private void UiInit(AstroPlace place)
        {
            birthCalculator = new AstroCalculator(place);
            List<AstroPlanet> birthPlantes = birthCalculator.CalculatePlanetPositionWithDetailsOptmized(false);
            birthHoroscope = birthCalculator.CalculateHoroscope(birthPlantes);
            birthHoroscope.CurrentTransitDate = birthCalculator;
            birthHoroscope.CurrentTransitDate.PlaceData = place;
            this.horoscopeFullView1.CurrentHoroscope = birthHoroscope;
            this.Country = place.Country;
            this.City= place.City;
            this.Logitude= place.Longitude;
            this.Latitude= place.Latitude;
            this.PersonName = place.PersonName;
            this.IsMale = place.IsMale;

            UpdateforTransit(System.DateTime.Now);
            this.horoscopeFullView1.UiInit();
            this.planetSummary1.UpdateHoroscope(birthHoroscope.CurrentTransitDate.PlaceData.OriginalDateTime
                , birthHoroscope.IsMaleHoroscope(), birthHoroscope.Nakath.Name, this.birthHoroscope.IsMaleHoroscope(), birthHoroscope.MostPowerfulPlanet);
            UpdateGeneraData(birthHoroscope);

            HoraKala current = transitCalculator.Muthurtha.CurrentHoraKala;
            AstroMuhurtha muhurtha = transitCalculator.Muthurtha;
            this.toolStripStatusLabelHora.Text = current.KalaAdhipathiPlanet.ToString();
            this.toolStripStatusLabelPanchamaHora.Text = muhurtha.ThisPachamaHoraAdhipathiPlanet.ToString() + (((muhurtha.ThisPachamaHora != null) && muhurtha.ThisPachamaHora.IsVisha) ? "*" : "");
            this.toolStripStatusLabelSukshamaHora.Text = muhurtha.ThisSukshamaHoraAdhipathiPlanet.ToString() + (((muhurtha.ThisSukshamaHora != null) && muhurtha.ThisSukshamaHora.IsVisha) ? "*" : "");
            this.toolStripStatusLabelCharaThira.Text = (birthHoroscope.LagnaRasi.IsThiraRashi ? "Firm" : birthHoroscope.LagnaRasi.IsCharaRashi ? "Waving" : "Firm and Waving");
            this.toolStripStatusLabelMruduThada.Text = (birthHoroscope.LagnaRasi.IsOddRashi ? "Thejas" : "Mrudu");
        }

        private void UpdateGeneraData(Horoscope birthHoroscope)
        {
            this.labelThithi.Text = birthHoroscope.CurrentTransitDate.Thithi.CurrentInt.ToString() + "-"
                + birthHoroscope.CurrentTransitDate.Thithi.Current.ToString();
            this.labelAsubhaPlanet.Text = birthHoroscope.ExtraDetails.Asubha;
            this.labelBadaka.Text = birthHoroscope.ExtraDetails.BadakaHouseNumber.ToString();
            this.labelBirthTime.Text = birthCalculator.PlaceData.OriginalDateTime.ToString("yyyy/MM/dd - hh:mm");
            this.labelAdjustedBirthTime.Text = birthCalculator.CurrentDateTime.ToString("yyyy/MM/dd - hh:mm");
            this.labelSunRise.Text = birthCalculator.SunRise.ToString("hh:mm");
            this.labelSunSet.Text = birthCalculator.SunSet.ToString("hh:mm");
            this.labelHora.Text = birthCalculator.Muthurtha.CurrentHoraKala.KalaAdhipathiPlanet.ToString();
            this.Text = this.birthCalculator.PlaceData.PersonName;
            this.labelIsPura.Text = birthHoroscope.ExtraDetails.IsPura ? "Pura" : "Awa";
            this.labelNakath.Text = birthHoroscope.Nakath.Name;
            this.labelSubhaPlanet.Text = birthHoroscope.ExtraDetails.Subha;
            this.labelYogakaraka.Text = birthHoroscope.ExtraDetails.Yogakaraka;
            this.labelAathmaKaraka.Text = birthHoroscope.ExtraDetails.AathmaKaraka.Current.ToString();
            this.labelAmathyaKaraka.Text = birthHoroscope.ExtraDetails.AmathyaKaraka.Current.ToString();
            this.labelBradhariKaraka.Text = birthHoroscope.ExtraDetails.AmathyaKaraka.Current.ToString();
            this.labelMathruKaraka.Text = birthHoroscope.ExtraDetails.MathruKaraka.Current.ToString();
            this.labelPithruKaraka.Text = birthHoroscope.ExtraDetails.PithruKaraka.Current.ToString();
            this.labelGnathiKaraka.Text = birthHoroscope.ExtraDetails.GnathiKaraka.Current.ToString();
            this.labelDhaaraKaraka.Text = birthHoroscope.ExtraDetails.DhaaraKaraka.Current.ToString();

            var bindingList = new BindingList<AstroDasa>(birthHoroscope.AstroDasaDetails.FutureDasas);
            var source = new BindingSource(bindingList, null);
            this.dataGridViewMainDasa.DataSource = source;
            //dataGridViewMainDasa.SelectedRows.Clear();
            //this.dataGridViewMainDasa.Rows.OfType<DataGridViewRow>().Where(x=>(DateTime)x.Cells[3].Value > DateTime.Now && (DateTime)x.Cells[4].Value < DateTime.Now).ToArray<DataGridViewRow>()[0].Selected = true;
        }

        public void UpdateforTransit(DateTime dateTime)
        {
            transitPlace = new AstroPlace(transitPlace.City, transitPlace.Country
                , transitPlace.PersonName, transitPlace.Latitude
                , transitPlace.Longitude, dateTime, transitPlace.IsMale);
            transitCalculator = new 
                AstroCalculator(transitPlace);
            List<AstroPlanet> transitPlantes = transitCalculator
                .CalculatePlanetPositionWithDetailsOptmized(true);

            if (birthCalculator != null)
            {                
                Horoscope temp = transitCalculator.CalculateHoroscope(transitPlantes);
                transitHoroscope = birthCalculator
                    .CalculateHoroscope(transitPlantes);
                foreach (AstroPlanet planet in transitHoroscope.CompletePlanetList)
                    planet.BirthPlanets = birthHoroscope.CompletePlanetList;
                transitHoroscope.LagnaRasi = temp.LagnaRasi;
                transitHoroscope.CurrentTransitDate = transitCalculator;
                this.horoscopeFullView1.TransitHoroscope = transitHoroscope;
                this.horoscopeFullView1.PartialUiInit();
            }
        }

        public void UpdateDisplayPlanetMessages(AstroPlanet planet, bool isBhavaView)
        {
            this.richTextBoxClickedPlanet.Text = "===Rashi Data===\r\n" + planet.Rasi.GetRashiQuality(); 
            this.richTextBoxClickedPlanet.Text += "\r\n===Planet Data===\r\n" + planet.GetPlanetQuality();
            this.richTextBoxClickedPlanet.Text += "\r\n===Planet On House===\r\n" + planet.GetPlanetQualityOnHouse();
            this.richTextBoxClickedPlanet.Text += "\r\n===Planet Special Message===\r\n" + planet.GetSpecialMessages();
            this.planetSummary1.UpdatePlanet(((!isBhavaView)
                ? planet.AjustedLongitude
                : planet.AjustedBhavaLongitude).ToDegreeString()
                , planet.Nakatha.Name, planet.NawamsaRasi.Name);
            analyzer.AddString(this.richTextBoxClickedPlanet.Text);
            this.richTextBoxSummary.Text = analyzer.GetSummary();    
        }

        public void UpdateDisplayMessage(string message, bool isAppend)
        {
            if (isAppend)
                this.richTextBoxClickedPlanet.Text += message;
            else
                this.richTextBoxClickedPlanet.Text = message;
        }

        private DateTime originalValue = System.DateTime.Now;
        private bool isComingfromSetDate = false;
        private void trackBarDate_ValueChanged(object sender, EventArgs e)
        {
            if (!isComingfromSetDate)
                this.datePicker.Value = originalValue.AddDays(this.trackBarDate.Value);
            UpdateforTransit(this.datePicker.Value);
            isComingfromSetDate = false;
        }

        private void buttonSetDate_Click(object sender, EventArgs e)
        {
            originalValue = this.datePicker.Value;
            isComingfromSetDate = true;
            UpdateforTransit(originalValue);
            RefreshEventList();
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
                case "Birth Date":
                    {
                        BirthDataSaveObject myObject = new BirthDataSaveObject();
                        myObject.BirthPlace = birthHoroscope.CurrentTransitDate.PlaceData;
                        myObject.TransitPlace = transitHoroscope.CurrentTransitDate.PlaceData;
                        using (var form = new GetBirthData(myObject))
                        {
                            var result = form.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                if (birthHoroscope.CurrentTransitDate.PlaceData.OriginalDateTime != form.BirthTime)
                                    IsBirthDateTimeChange = true;
                                birthPlace = new AstroPlace(form.BirthPlace.City, form.BirthPlace.Country
                                    , form.BirthPlace.PersonName, form.BirthPlace.Latitude
                                    , form.BirthPlace.Longitude, form.BirthPlace.OriginalDateTime, form.BirthPlace.IsMale); 

                                transitPlace = new AstroPlace(form.TransitPlace.City, form.TransitPlace.Country
                                    , form.TransitPlace.PersonName, form.TransitPlace.Latitude
                                    , form.TransitPlace.Longitude, DateTime.Now, form.TransitPlace.IsMale);

                                UiInit(birthPlace);
                                FileIOOperation.WriteToXmlFile<BirthDataSaveObject>(birthPlace.PersonName
                                    , new BirthDataSaveObject(birthPlace, transitPlace));
                                RefreshYogaList();
                            }
                        }
                    }
                    break;
                case "Open...":
                    {
                        OpenFileDialog openFileDialog1 = new OpenFileDialog
                        {
                            InitialDirectory = @".\Users",
                            Title = "Browse Horoscope Files",
                            CheckFileExists = true,
                            CheckPathExists = true,

                            DefaultExt = "xml",
                            Filter = "xml files (*.xml)|*.xml",
                            FilterIndex = 2,
                            RestoreDirectory = true,

                            ReadOnlyChecked = true,
                            ShowReadOnly = true
                        };
                        if (openFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            BirthDataSaveObject savedObject = FileIOOperation.ReadFromXmlFile<BirthDataSaveObject>(openFileDialog1.FileName);
                            birthPlace = new AstroPlace(savedObject.BirthPlace.City, savedObject.BirthPlace.Country
                                , savedObject.BirthPlace.PersonName, savedObject.BirthPlace.Latitude
                                , savedObject.BirthPlace.Longitude, savedObject.BirthPlace.OriginalDateTime, savedObject.BirthPlace.IsMale);

                            transitPlace = new AstroPlace(savedObject.TransitPlace.City, savedObject.TransitPlace.Country
                                , savedObject.TransitPlace.PersonName, savedObject.TransitPlace.Latitude
                                , savedObject.TransitPlace.Longitude, DateTime.Now, savedObject.TransitPlace.IsMale);

                            if (birthPlace.AdjustedBirthDateTime != birthHoroscope.CurrentTransitDate.PlaceData.OriginalDateTime)
                                IsBirthDateTimeChange = true;
                            UiInit(birthPlace);
                        }
                    }
                    break;
                case "New":
                    {
                        using (var form = new GetBirthData())
                        {
                            var result = form.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                birthPlace = new AstroPlace(form.BirthPlace.City, form.BirthPlace.Country
                                    , form.BirthPlace.PersonName, form.BirthPlace.Latitude
                                    , form.BirthPlace.Longitude, form.BirthPlace.OriginalDateTime, form.BirthPlace.IsMale);

                                transitPlace = new AstroPlace(form.TransitPlace.City, form.TransitPlace.Country
                                    , form.TransitPlace.PersonName, form.TransitPlace.Latitude
                                    , form.TransitPlace.Longitude, DateTime.Now, form.TransitPlace.IsMale);

                                UiInit(birthPlace);
                                FileIOOperation.WriteToXmlFile<BirthDataSaveObject>(birthPlace.PersonName
                                    , new BirthDataSaveObject(birthPlace, transitPlace));
                                IsBirthDateTimeChange = true;
                            }
                        }
                    }
                    break;
            }
        }

        private void buttonSummaryReset_Click(object sender, EventArgs e)
        {
            analyzer.Reset();
            this.richTextBoxSummary.Clear();
        }

        public void ResetMainDasaSelection(DateTime transitDateTime)
        {
            dataGridViewMainDasa.Rows[0].Selected = true;
        }

        private void dataGridViewMainDasa_SelectionChanged(object sender, EventArgs e)
        {
            AstroDasa dasa = getSelectedDasa();
            if (dasa == null) return;
            var bindingList = new BindingList<AstroDasa>(dasa.AthuruDasas);
            var source = new BindingSource(bindingList, null);
            this.dataGridViewSubDasa.DataSource = source;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshYogaList();
        }

        private void RefreshYogaList()
        {
            if (!IsBirthDateTimeChange) return;

            this.listBoxYoga.Items.Clear();
            if (birthHoroscope != null && transitHoroscope != null)
            {
                YogaEventFinder finder = new YogaEventFinder(birthHoroscope, transitHoroscope);
                List<string> yogaList = finder.CalculateYoga();
                foreach (string yoga in yogaList)
                    this.listBoxYoga.Items.Add(yoga);
            }
            IsBirthDateTimeChange = false;
        }

        private void RefreshEventList()
        {
            if (birthHoroscope != null && transitHoroscope != null)
            {
                YogaEventFinder finder = new YogaEventFinder(birthHoroscope, transitHoroscope);
                List<string> yogaList = finder.CalculateEvents();
                foreach (string yoga in yogaList)
                    this.listBoxYoga.Items.Add(yoga);
            }
        }

        private void yogaConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YogaEditor editorForm = new YogaEditor();
            editorForm.ShowDialog();
        }

        private void dataGridViewSubDasa_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //.Show("hello");
        }

        private void dataGridViewSubDasa_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            AstroDasa dasa = getSelectedAthuruDasa();
            DisplayDasaMessage(dasa);
        }

        private AstroDasa getSelectedDasa()
        {
            var rowsCount = dataGridViewMainDasa.SelectedRows.Count;
            if (rowsCount == 0 || rowsCount > 1) return null;
            var row = dataGridViewMainDasa.SelectedRows[0];
            if (row == null) return null;
            return ((AstroDasa)row.DataBoundItem);
        }

        private AstroDasa getSelectedAthuruDasa()
        {
            var rowsCount = dataGridViewSubDasa.SelectedRows.Count;
            if (rowsCount == 0 || rowsCount > 1) return null;
            var row = dataGridViewSubDasa.SelectedRows[0];
            if (row == null) return null;
            return ((AstroDasa)row.DataBoundItem);
        }

        private AstroDasa getSelectedAntharAthuruDasa()
        {
            var rowsCount = dataGridViewSubSubDasa.SelectedRows.Count;
            if (rowsCount == 0 || rowsCount > 1) return null;
            var row = dataGridViewSubSubDasa.SelectedRows[0];
            if (row == null) return null;
            return ((AstroDasa)row.DataBoundItem);
        }

        public Horoscope getDasaHoroscope(AstroDasa dasa)
        {
            AstroCalculator dasaCalculator = new
                AstroCalculator(new DataModels.AstroPlace(City, Country, PersonName
                , Latitude, Logitude, dasa.Start, IsMale));
            List<AstroPlanet> dasaPlantes = dasaCalculator
                .CalculatePlanetPositionWithDetailsOptmized(false);
            if (birthCalculator != null)
                return birthCalculator
                    .CalculateHoroscope(dasaPlantes);
            return null;
        }

        private void dataGridViewMainDasa_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            AstroDasa dasa = getSelectedDasa();
            DisplayDasaMessage(dasa);
        }

        private void DisplayDasaMessage(AstroDasa dasa)
        {
            if (dasa != null)
            {
                Horoscope dasaHoroscope = getDasaHoroscope(dasa);
                DasaResultTypes b = dasa.IsDasaTransitTimeGood(dasaHoroscope.CompletePlanetList);
                string s = AstroGoodBad.GetDasaQualityBasedOnMoonPlacement(dasaHoroscope.CurrentTransitDate.Moon.Rasi.Current);
                s += "\r\nData Effect by Birth: " + dasa.GetDasaBirthPlanetEffect(birthHoroscope.CompletePlanetList)
                + "\r\nDescription: " + AstroGoodBad.GetDasaQualityBasedOnDasaPlanet(dasa.DasaPlanet, b < DasaResultTypes.Mixed );
                System.Windows.Forms.MessageBox.Show("This is a " + b.ToString() + " Dasa transit for you - " + s);
            }
        }

        private void dataGridViewSubDasa_SelectionChanged(object sender, EventArgs e)
        {
            AstroDasa dasa = getSelectedAthuruDasa();
            if (dasa == null) return;
            var bindingList = new BindingList<AstroDasa>(dasa.AthuruDasas);
            var source = new BindingSource(bindingList, null);
            this.dataGridViewSubSubDasa.DataSource = source;
        }

        private void dataGridViewSubSubDasa_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            AstroDasa dasa = getSelectedAntharAthuruDasa();
            DisplayDasaMessage(dasa);
        }
    }
}
