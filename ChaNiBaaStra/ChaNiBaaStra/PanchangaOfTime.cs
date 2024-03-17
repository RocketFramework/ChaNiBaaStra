using ChaNiBaaStra.Calculator;
using ChaNiBaaStra.DataModels;
using ChaNiBaaStra.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace ChaNiBaaStra
{

    public partial class PanchangaOfTime : UserControl
    {
        private BackgroundWorker backgroundWorker;
        private static List<SubhaTime> matchedSubhaTimes;
        private AstroPlace astroPlace;
        private static bool loopStop;
        public Horoscope BirthHoroscope { get; set; }
        public PanchangaOfTime()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void labelThithi_Click(object sender, EventArgs e)
        {

        }

        private void labelYoga_Click(object sender, EventArgs e)
        {

        }

        private void labelKarana_Click(object sender, EventArgs e)
        {

        }

        private void labelLagna_Click(object sender, EventArgs e)
        {

        }

        private void labelDate_Click(object sender, EventArgs e)
        {

        }

        private void labelNakath_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void PanchangaOfTime_Load(object sender, EventArgs e)
        {

        }

        private void comboBoxNakath_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected item from the combo box
            string selectedItem = comboBoxNakath.SelectedItem.ToString();

            // Check if the item is already in the list view
            bool alreadyExists = false;
            foreach (ListViewItem item in listViewNakaths.Items)
            {
                if (item.Text == selectedItem)
                {
                    alreadyExists = true;
                    break;
                }
            }

            // If the item is not already in the list view, add it
            if (!alreadyExists)
            {
                listViewNakaths.Items.Add(selectedItem);
            }
        }

        private void comboBoxRashi_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected item from the combo box
            string selectedItem = comboBoxRashi.SelectedItem.ToString();

            // Check if the item is already in the list view
            bool alreadyExists = false;
            foreach (ListViewItem item in listViewRashies.Items)
            {
                if (item.Text == selectedItem)
                {
                    alreadyExists = true;
                    break;
                }
            }

            // If the item is not already in the list view, add it
            if (!alreadyExists)
            {
                listViewRashies.Items.Add(selectedItem);
            }
        }

        private void comboBoxThithi_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected item from the combo box
            string selectedItem = comboBoxThithi.SelectedItem.ToString();

            // Check if the item is already in the list view
            bool alreadyExists = false;
            foreach (ListViewItem item in listViewThthies.Items)
            {
                if (item.Text == selectedItem)
                {
                    alreadyExists = true;
                    break;
                }
            }

            // If the item is not already in the list view, add it
            if (!alreadyExists)
            {
                listViewThthies.Items.Add(selectedItem);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedPlanet = comboBoxPlanet.SelectedItem.ToString();
            if (selectedPlanet == string.Empty)
                return;
            // Get the selected item from the combo box
            string selectedItem = comboBoxHouse.SelectedItem.ToString();
            selectedItem = selectedPlanet + ":" + selectedItem;
            // Check if the item is already in the list view
            bool alreadyExists = false;
            foreach (ListViewItem item in listViewPlanets.Items)
            {
                if (item.Text == selectedItem)
                {
                    alreadyExists = true;
                    break;
                }
            }

            // If the item is not already in the list view, add it
            if (!alreadyExists)
            {
                listViewPlanets.Items.Add(selectedItem);
            }
        }

        private void listViewNakaths_KeyDown(object sender, KeyEventArgs e)
        {
            // Cast the sender object back to a ListView
            ListView listView = sender as ListView;

            // Check if the pressed key is the Delete key
            if (e.KeyCode == Keys.Delete)
            {
                // Iterate through all selected items and remove them from the ListView
                foreach (ListViewItem selectedItem in listView.SelectedItems)
                {
                    listView.Items.Remove(selectedItem);
                }
            }
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            InitializeBackgroundWorker();
            backgroundWorker.RunWorkerAsync();
        }

        private static ListViewItem[] rashiList;
        private static ListViewItem[] nakathList;
        private static ListViewItem[] thithiList;
        private static ListViewItem[] planetList;
        private void InitializeBackgroundWorker()
        {
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.DoWork += BackgroundWorker_DoWork;
            backgroundWorker.ProgressChanged += BackgroundWorker_ProgressChanged;
            this.progressBarFinderStatus.Maximum = 100;
            this.progressBarFinderStatus.Value = 0;
            nakathList = new ListViewItem[listViewNakaths.Items.Count];
            rashiList = new ListViewItem[listViewRashies.Items.Count];
            thithiList = new ListViewItem[listViewThthies.Items.Count];
            planetList = new ListViewItem[listViewPlanets.Items.Count];
            listViewNakaths.Items.CopyTo(nakathList, 0);
            listViewRashies.Items.CopyTo(rashiList, 0);
            listViewThthies.Items.CopyTo(thithiList, 0);
            listViewPlanets.Items.CopyTo(planetList, 0);
            loopStop = false;
            matchedSubhaTimes = new List<SubhaTime>();

            this.buttonNakathMatched.BackColor = System.Drawing.SystemColors.Control;
            this.buttonPlanetMatched.BackColor = System.Drawing.SystemColors.Control;
            this.buttonThthiMatched.BackColor = System.Drawing.SystemColors.Control;
            this.buttonRashiMatched.BackColor = System.Drawing.SystemColors.Control;
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            double increMent = Convert.ToDouble(this.textBoxIncrement.Text);
            int iterCount = Convert.ToInt32(this.textBoxIteration.Text);
            DateTime checkDateTime = Convert.ToDateTime(this.dateTimePickerStart.Value);
            for (int i = 0; i < iterCount; i++)
            {
                if (loopStop)
                {
                    backgroundWorker.ReportProgress(-1);
                    break;
                }
                astroPlace = new AstroPlace(Convert.ToDouble(this.textBoxLatitude.Text)
                    , Convert.ToDouble(this.textBoxLongitude.Text), checkDateTime);
                AstroCalculator birthCalculator = new AstroCalculator(astroPlace);
                List<AstroPlanet> birthPlantes = birthCalculator.CalculatePlanetPositionWithDetailsOptmized(false);
                Horoscope birthHoroscope = birthCalculator.CalculateHoroscope(birthPlantes);
                // check for nakath
                bool nakathMatched = false;
                if (nakathList.Length == 0)
                    nakathMatched = true;
                else
                    foreach (ListViewItem item in nakathList)
                        if (item != null)
                        {
                            nakathMatched = item.Text.Contains(birthHoroscope.Nakath.Name);
                            if (nakathMatched)
                                break;
                        }


                //check for Rashi
                bool rashiMatched = false;
                if (rashiList.Length == 0)
                    rashiMatched = true;
                else
                    foreach (ListViewItem item in rashiList)
                        if (item != null)
                        {
                            rashiMatched = item.Text.Contains(birthHoroscope.LagnaRasi.Name);
                            if (rashiMatched)
                                break;
                        }


                //check for Thithi
                bool thithiMatched = false;
                if (thithiList.Length == 0)
                    thithiMatched = true;
                else

                    foreach (ListViewItem item in thithiList)
                        if (item != null)
                        {
                            thithiMatched = item.Text.Contains(birthHoroscope.CurrentTransitDate.Thithi.Name);
                            if (thithiMatched)
                                break;
                        }


                //check for Planet 
                bool planetMatched = false;
                if (planetList.Length == 0)
                    planetMatched = true;
                else
                    foreach (ListViewItem item in planetList)
                    {
                        if (item != null)
                        {
                            string[] datas = item.Text.Split(new char[] { ':' });
                            string name = datas[0];
                            int house = Convert.ToInt32(datas[1]);
                            planetMatched = birthHoroscope.CompletePlanetList.Exists(x => (x.Name == name) && (x.HouseNumber == house));
                            if (planetMatched)
                                break;
                        }

                    }
                checkDateTime = checkDateTime.AddDays(increMent);
                FindingStatus findingStatus = new FindingStatus();

                findingStatus.LastAttemptedDateTime = checkDateTime.ToLongDateString() + ":" + checkDateTime.ToLongTimeString();
                findingStatus.NakathMatched = nakathMatched;
                findingStatus.RashiMatched = rashiMatched;
                findingStatus.ThithiMatched = thithiMatched;
                findingStatus.PlanetMatched = planetMatched;
                findingStatus.IterationCount = i;
                if (nakathMatched && rashiMatched && thithiMatched && planetMatched)
                    matchedSubhaTimes.Add(MapSubhaTime(birthHoroscope, birthCalculator));

                backgroundWorker.ReportProgress((int)100 - (100 / (i + 1)), findingStatus);

                System.Threading.Thread.Sleep(100);

                this.buttonNakathMatched.BackColor = System.Drawing.SystemColors.Control;
                this.buttonPlanetMatched.BackColor = System.Drawing.SystemColors.Control;
                this.buttonThthiMatched.BackColor = System.Drawing.SystemColors.Control;
                this.buttonRashiMatched.BackColor = System.Drawing.SystemColors.Control;
            }
            loopStop = true;
            backgroundWorker.ReportProgress(-1);
        }

        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == -1)
            {
                this.progressBarFinderStatus.Value = 0;
                this.labelStatus.Text = "";

                this.buttonNakathMatched.BackColor = System.Drawing.SystemColors.Control;
                this.buttonPlanetMatched.BackColor = System.Drawing.SystemColors.Control;
                this.buttonThthiMatched.BackColor = System.Drawing.SystemColors.Control;
                this.buttonRashiMatched.BackColor = System.Drawing.SystemColors.Control;
                return;
            }

            this.progressBarFinderStatus.Value = e.ProgressPercentage;
            FindingStatus fstatus = (FindingStatus)e.UserState;
            this.labelStatus.Text = fstatus.IterationCount + " - " + fstatus.LastAttemptedDateTime;
            this.buttonNakathMatched.BackColor = (fstatus.NakathMatched) ? System.Drawing.Color.Yellow : System.Drawing.Color.Red;
            this.buttonPlanetMatched.BackColor = (fstatus.PlanetMatched) ? System.Drawing.Color.Yellow : System.Drawing.Color.Red;
            this.buttonThthiMatched.BackColor = (fstatus.ThithiMatched) ? System.Drawing.Color.Yellow : System.Drawing.Color.Red;
            this.buttonRashiMatched.BackColor = (fstatus.PlanetMatched) ? System.Drawing.Color.Yellow : System.Drawing.Color.Red;


            BindingSource bindingSourceMatchingResults = new BindingSource();
            bindingSourceMatchingResults.DataSource = matchedSubhaTimes;
            this.dataGridViewEvents.DataSource = bindingSourceMatchingResults;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (loopStop)
            {
                this.progressBarFinderStatus.Value = 0; 
                this.labelStatus.Text = "";

                this.buttonNakathMatched.BackColor = System.Drawing.SystemColors.Control;
                this.buttonPlanetMatched.BackColor = System.Drawing.SystemColors.Control;
                this.buttonThthiMatched.BackColor = System.Drawing.SystemColors.Control;
                this.buttonRashiMatched.BackColor = System.Drawing.SystemColors.Control;
            }
            else
                loopStop = true;

        }

        private SubhaTime MapSubhaTime(Horoscope horoscope, AstroCalculator calculator)
        {
            SubhaTime subhaTime = new SubhaTime();

            subhaTime.Karnaya = horoscope.CurrentTransitDate.Karna.Name;
            subhaTime.Lagnaya = horoscope.LagnaRasi.Name;
            subhaTime.Yogaya = horoscope.CurrentTransitDate.Yoga.Name;
            subhaTime.Dinaya = horoscope.CurrentTransitDate.WeekDay.Name;
            subhaTime.Nakatha = horoscope.Nakath.Name;
            subhaTime.NakathRelation = BirthHoroscope.Nakath.RelationshipWith(horoscope.Nakath).ToString();
            subhaTime.Mercury = horoscope.CurrentTransitDate.Mercury.HouseNumber + " Adhipathis of: " + horoscope.CurrentTransitDate.Mercury.AdhipathiHouses.ToCustomString() + " Who I see: " + horoscope.CurrentTransitDate.Mercury.Views.ICanSeeThem.ToCustomString();
            Tuple<DateTime, DateTime> RahuTimes = horoscope.CurrentTransitDate.WeekDay.Rahukalaya(horoscope.CurrentTransitDate.SunRise, horoscope.CurrentTransitDate.SunSet);
            subhaTime.RahuKalaya = RahuTimes.Item1.ToShortTimeString() + "-" + RahuTimes.Item2.ToShortTimeString();
            subhaTime.Venus = horoscope.CurrentTransitDate.Venus.HouseNumber + " Adhipathis of: " + horoscope.CurrentTransitDate.Venus.AdhipathiHouses.ToCustomString() + " Who I see: " + horoscope.CurrentTransitDate.Venus.Views.ICanSeeThem.ToCustomString();
            subhaTime.SunRise = horoscope.CurrentTransitDate.SunRise;
            subhaTime.SunSet = horoscope.CurrentTransitDate.SunSet;
            subhaTime.Time = horoscope.CurrentTransitDate.CurrentDateTime;
            subhaTime.SunNakath = horoscope.CurrentTransitDate.Sun.Nakatha.Name;
            subhaTime.Hora = calculator.Muthurtha.CurrentHoraKala.KalaAdhipathiPlanet.ToString();
            subhaTime.MoonHouseFromLagna = horoscope.CurrentTransitDate.Moon.HouseNumber.ToString();
            subhaTime.MoonHouseFromTransitLagna = horoscope.CurrentTransitDate.Moon.Rasi.absoluteHouseFromRasi(BirthHoroscope.CurrentTransitDate.Moon.Rasi.Current).ToString();
            subhaTime.Thithiya = calculator.Thithi.Name;

            return subhaTime;
        }

        private void dataGridViewEvents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

    public class FindingStatus
    {
        public string LastAttemptedDateTime { get; set; }
        public bool NakathMatched { get; set; }
        public bool RashiMatched { get; set; }
        public bool ThithiMatched { get; set; }
        public bool PlanetMatched { get; set; }
        public int IterationCount { get; set; }
    }
}
