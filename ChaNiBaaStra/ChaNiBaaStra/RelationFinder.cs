using ChaNiBaaStra.Calculator;
using ChaNiBaaStra.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChaNiBaaStra.DataModels;

namespace ChaNiBaaStra
{
    public partial class RelationFinder : Form
    {
        private string currentFilePath { get; set; }
        public RelationFinder()
        {
            InitializeComponent();

            dataGridViewFutureMapping.Scroll += dataGridView1_Scroll;
            this.comboBoxIncrement.SelectedItem = 1;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // Create new ListViewItem
            ListViewItem newItem = new ListViewItem();

            // Add main item
            newItem.Text = this.textBoxIdentity.Text;
            newItem.SubItems.Add(this.dateTimePickerEvent.Text);

            // Add sub-items to the ListViewItem
            newItem.SubItems.Add(this.textBoxLongitute.Text);
            newItem.SubItems.Add(this.textBoxLatitude.Text);

            // Add the ListViewItem to the ListView
            this.listViewEventDate.Items.Add(newItem);
        }

        private void RelationFinder_Load(object sender, EventArgs e)
        {
            LocationDetails birthlData = new Utilities.LocationDetails();
            birthlData.Load();
            comboBoxCountry.DataSource = birthlData.Countries;
            comboBoxCountry.DisplayMember = "Country";
            comboBoxCountry.ValueMember = "Country";

            comboBoxCity.DisplayMember = "City";
            comboBoxCity.ValueMember = "Id";

            comboBoxCountry.SelectedValue = "Select Country";
            comboBoxCountry.SelectedItem = comboBoxCountry.Items
                .Cast<CountryItem>().FirstOrDefault(x => x.Country == "Sri Lanka");
            comboBoxCountry.Focus();

            comboBoxCity.SelectedValue = "Select City";
            comboBoxCity.SelectedItem = comboBoxCity.Items
                .Cast<LocationItem>().FirstOrDefault(x => x.City == "Colombo");
            comboBoxCity.Focus();
            comboBoxCountry2.DisplayMember = "Country";
            comboBoxCountry2.ValueMember = "Country";
            comboBoxCountry2.DataSource = birthlData.Countries;
            listViewEventDate.Columns.Clear();

            this.listViewEventDate.View = View.Details;
            this.listViewEventDate.Columns.Add("Identity", 120);
            this.listViewEventDate.Columns.Add("Event Date", 120); // Adjust width as needed
            this.listViewEventDate.Columns.Add("Longitude", 80);
            this.listViewEventDate.Columns.Add("Latitude", 80);

            listViewEventDate.FullRowSelect = true;
        }

        private void comboBoxCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBoxCountry.SelectedValue != null)
            {
                if (this.comboBoxCountry.Items.Count > 1)
                    this.comboBoxCountry.SelectedItem = comboBoxCountry.Items
                        .Cast<CountryItem>().FirstOrDefault(x => x.Country == comboBoxCountry.SelectedValue.ToString());
                LocationDetails lData = new Utilities.LocationDetails();
                comboBoxCity.DataSource = ((CountryItem)this.comboBoxCountry.SelectedItem).LocationList;
                //choose the specific field to display
                comboBoxCity.DisplayMember = "City";
                comboBoxCity.ValueMember = "Id";
                //set default selected value
                comboBoxCity.SelectedValue = "Select City";
                comboBoxCity2.DisplayMember = comboBoxCity.DisplayMember;
                comboBoxCity2.ValueMember = comboBoxCity.ValueMember;
                comboBoxCity2.DataSource = ((CountryItem)this.comboBoxCountry.SelectedItem).LocationList;

            }
        }

        private void comboBoxCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBoxCity.SelectedValue != null)
            {
                if (comboBoxCity.Items.Count > 1)
                    this.comboBoxCity.SelectedItem = comboBoxCity.Items
                        .Cast<LocationItem>().FirstOrDefault(x => x.City == ((LocationItem)comboBoxCity.SelectedItem).City);
                LocationItem lItem = (LocationItem)this.comboBoxCity.SelectedItem;
                if (lItem != null)
                {
                    this.textBoxLatitude.Text = lItem.Latitude.ToString();
                    this.textBoxLongitute.Text = lItem.Longitude.ToString();
                    this.textBoxLat2.Text = lItem.Latitude.ToString();
                    this.textBoxLong2.Text = lItem.Longitude.ToString();
                }
            }
        }

        private void SaveItemsToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (ListViewItem item in listViewEventDate.Items)
                    writer.WriteLine($"{item.Text},{item.SubItems[1].Text},{item.SubItems[2].Text}, {item.SubItems[3].Text}");
            }
        }

        private void LoadItemsFromFile(string filePath)
        {
            if (!File.Exists(filePath))
                return;

            this.labelFilePath.Text = filePath;

            listViewEventDate.Items.Clear();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length >= 3)
                    {
                        ListViewItem newItem = new ListViewItem(parts[0]);
                        newItem.SubItems.Add(parts[1]);
                        newItem.SubItems.Add(parts[2]);
                        newItem.SubItems.Add(parts[3]);
                        listViewEventDate.Items.Add(newItem);
                    }
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog.Title = "Open";
            openFileDialog.ShowDialog();

            if (openFileDialog.FileName != "")
                LoadItemsFromFile(openFileDialog.FileName);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            saveFileDialog.Title = "Save As...";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
                SaveItemsToFile(saveFileDialog.FileName);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentFilePath))
                SaveItemsToFile(currentFilePath);
            else
                saveAsToolStripMenuItem_Click(sender, e);
        }

        private void listViewEventDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewEventDate.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewEventDate.SelectedItems[0];

                // Retrieve items of the selected row
                string identity = selectedItem.SubItems[0].Text;
                string eventDate = selectedItem.SubItems[1].Text;
                string longitude = selectedItem.SubItems[2].Text;
                string latitude = selectedItem.SubItems[3].Text;
            }
        }
        List<BirthData> dataList;
        AstroPlace activePlace;
        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            BindingSource bindingSourceTheySee = new BindingSource();
            dataList = new List<BirthData>();
            this.toolStripProgressBarStatus.Maximum = 100;
            int incrment = 100 / listViewEventDate.Items.Count;
            this.toolStripProgressBarStatus.Value = 0;
            foreach (ListViewItem listItem in listViewEventDate.Items)
            {
                this.toolStripProgressBarStatus.Value += incrment;
                string identity = listItem.SubItems[0].Text;
                string eventDate = listItem.SubItems[1].Text;
                string longitude = listItem.SubItems[2].Text;
                string latitude = listItem.SubItems[3].Text;

                activePlace = new AstroPlace(Convert.ToDouble(latitude)
                    , Convert.ToDouble(longitude), Convert.ToDateTime(eventDate));
                BirthData dataObject = null;
                if (!dataList.Exists(item => item.DateTime == activePlace.OriginalDateTime))
                {
                    AstroCalculator birthCalculator = new AstroCalculator(activePlace);
                    List<AstroPlanet> birthPlantes = birthCalculator.CalculatePlanetPositionWithDetailsOptmized(false);
                    Horoscope birthHoroscope = birthCalculator.CalculateHoroscope(birthPlantes);
                    birthHoroscope.CurrentTransitDate = birthCalculator;
                    birthHoroscope.CurrentTransitDate.PlaceData = activePlace;

                    dataObject = GetBirthDataObject(birthHoroscope);
                }
                if (dataObject != null)
                    dataList.Add(dataObject);
            }
            bindingSourceTheySee.DataSource = dataList;
            this.dataGridViewMain.DataSource = bindingSourceTheySee;
            this.toolStripProgressBarStatus.Value = 0;
        }

        private static BirthData GetBirthDataObject(Horoscope birthHoroscope)
        {
            return new BirthData
            {
                DateTime = birthHoroscope.CurrentTransitDate.CurrentDateTime,
                Langna = birthHoroscope.LagnaRasi.Name,
                Nawamsa = birthHoroscope.NavamsaRasi.Name,
                MostPowerfulPlanet = birthHoroscope.MostPowerfulPlanet.Name,
                Nakath = birthHoroscope.Nakath.Name,
                AscendentDegrees = (int)(birthHoroscope.LagnaRasi.AscendentDegrees / 10) * 10,
                IsMaleRashi = birthHoroscope.LagnaRasi.IsMaleRashi,
                IsOddRashi = birthHoroscope.LagnaRasi.IsOddRashi,
                IsThiraRashi = birthHoroscope.LagnaRasi.IsThiraRashi,
                IsCharaRashi = birthHoroscope.LagnaRasi.IsCharaRashi,
                IsUbhayaRashi = birthHoroscope.LagnaRasi.IsUbhayaRashi,

                SunLocaltionFromMesha = (int)(birthHoroscope.CurrentTransitDate.Sun.Longitude / 10) * 10,
                SunLocaltionFromMoon = (int)((birthHoroscope.CurrentTransitDate.Sun.Longitude - birthHoroscope.CurrentTransitDate.Moon.Longitude) / 10) * 10,
                SunLocaltion = (int)(birthHoroscope.CurrentTransitDate.Sun.AjustedLongitude / 10) * 10,
                SunHouse = birthHoroscope.CurrentTransitDate.Sun.HouseNumber,
                SunRashi = birthHoroscope.CurrentTransitDate.Sun.Rasi.Name,

                MoonLocaltionFromMesha = (int)(birthHoroscope.CurrentTransitDate.Moon.Longitude / 10) * 10,
                MoonLocaltionFromSun = (int)((birthHoroscope.CurrentTransitDate.Moon.Longitude - birthHoroscope.CurrentTransitDate.Sun.Longitude) / 10) * 10,
                MoonLocaltion = (int)(birthHoroscope.CurrentTransitDate.Moon.AjustedLongitude / 10) * 10,
                MoonHouse = birthHoroscope.CurrentTransitDate.Moon.HouseNumber,
                MoonRashi = birthHoroscope.CurrentTransitDate.Moon.Rasi.Name,

                MarsLocaltionFromMesha = (int)(birthHoroscope.CurrentTransitDate.Mars.Longitude / 10) * 10,
                MarsLocaltionFromSun = (int)((birthHoroscope.CurrentTransitDate.Mars.Longitude - birthHoroscope.CurrentTransitDate.Sun.Longitude) / 10) * 10,
                MarsLocaltion = (int)(birthHoroscope.CurrentTransitDate.Mars.AjustedLongitude / 10) * 10,
                MarsHouse = birthHoroscope.CurrentTransitDate.Mars.HouseNumber,
                MarsRashi = birthHoroscope.CurrentTransitDate.Mars.Rasi.Name,

                JupiterLocaltionFromMesha = (int)(birthHoroscope.CurrentTransitDate.Jupiter.Longitude / 10) * 10,
                JupiterLocaltionFromSun = (int)((birthHoroscope.CurrentTransitDate.Jupiter.Longitude - birthHoroscope.CurrentTransitDate.Sun.Longitude) / 10) * 10,
                JupiterLocaltionFromMoon = (int)((birthHoroscope.CurrentTransitDate.Jupiter.Longitude - birthHoroscope.CurrentTransitDate.Moon.Longitude) / 10) * 10,
                JupiterLocaltion = (int)(birthHoroscope.CurrentTransitDate.Jupiter.AjustedLongitude / 10) * 10,
                JupiterHouse = birthHoroscope.CurrentTransitDate.Jupiter.HouseNumber,
                JupiterRashi = birthHoroscope.CurrentTransitDate.Jupiter.Rasi.Name,

                SaturnLocaltionFromMesha = (int)(birthHoroscope.CurrentTransitDate.Saturn.Longitude / 10) * 10,
                SaturnLocaltionFromSun = (int)((birthHoroscope.CurrentTransitDate.Saturn.Longitude - birthHoroscope.CurrentTransitDate.Sun.Longitude) / 10) * 10,
                SaturnLocaltionFromMoon = (int)((birthHoroscope.CurrentTransitDate.Saturn.Longitude - birthHoroscope.CurrentTransitDate.Moon.Longitude) / 10) * 10,
                SaturnLocaltion = (int)(birthHoroscope.CurrentTransitDate.Saturn.AjustedLongitude / 10) * 10,
                SaturnHouse = birthHoroscope.CurrentTransitDate.Saturn.HouseNumber,
                SaturnRashi = birthHoroscope.CurrentTransitDate.Saturn.Rasi.Name,

                MercuryLocaltionFromMesha = (int)(birthHoroscope.CurrentTransitDate.Mercury.Longitude / 10) * 10,
                MercuryLocaltionFromSun = (int)((birthHoroscope.CurrentTransitDate.Mercury.Longitude - birthHoroscope.CurrentTransitDate.Sun.Longitude) / 10) * 10,
                MercuryLocaltionFromMoon = (int)((birthHoroscope.CurrentTransitDate.Mercury.Longitude - birthHoroscope.CurrentTransitDate.Moon.Longitude) / 10) * 10,
                MercuryLocaltion = (int)(birthHoroscope.CurrentTransitDate.Mercury.AjustedLongitude / 10) * 10,
                MercuryHouse = birthHoroscope.CurrentTransitDate.Mercury.HouseNumber,
                MercuryRashi = birthHoroscope.CurrentTransitDate.Mercury.Rasi.Name,

                VenusLocaltionFromMesha = (int)(birthHoroscope.CurrentTransitDate.Venus.Longitude / 10) * 10,
                VenusLocaltionFromSun = (int)((birthHoroscope.CurrentTransitDate.Venus.Longitude - birthHoroscope.CurrentTransitDate.Sun.Longitude) / 10) * 10,
                VenusLocaltionFromMoon = (int)((birthHoroscope.CurrentTransitDate.Venus.Longitude - birthHoroscope.CurrentTransitDate.Moon.Longitude) / 10) * 10,
                VenusLocaltion = (int)(birthHoroscope.CurrentTransitDate.Venus.AjustedLongitude / 10) * 10,
                VenusHouse = birthHoroscope.CurrentTransitDate.Venus.HouseNumber,
                VenusRashi = birthHoroscope.CurrentTransitDate.Venus.Rasi.Name,

                RahuLocaltionFromMesha = (int)(birthHoroscope.CurrentTransitDate.Rahu.Longitude / 10) * 10,
                RahuLocaltionFromSun = (int)((birthHoroscope.CurrentTransitDate.Rahu.Longitude - birthHoroscope.CurrentTransitDate.Sun.Longitude) / 10) * 10,
                RahuLocaltionFromMoon = (int)((birthHoroscope.CurrentTransitDate.Rahu.Longitude - birthHoroscope.CurrentTransitDate.Moon.Longitude) / 10) * 10,
                RahuLocaltion = (int)(birthHoroscope.CurrentTransitDate.Rahu.AjustedLongitude / 10) * 10,
                RahuHouse = birthHoroscope.CurrentTransitDate.Rahu.HouseNumber,
                RahuRashi = birthHoroscope.CurrentTransitDate.Rahu.Rasi.Name,

                KethuLocaltionFromMesha = (int)(birthHoroscope.CurrentTransitDate.Kethu.Longitude / 10) * 10,
                KethuLocaltionFromSun = (int)((birthHoroscope.CurrentTransitDate.Kethu.Longitude - birthHoroscope.CurrentTransitDate.Sun.Longitude) / 10) * 10,
                KethuLocaltionFromMoon = (int)((birthHoroscope.CurrentTransitDate.Kethu.Longitude - birthHoroscope.CurrentTransitDate.Moon.Longitude) / 10) * 10,
                KethuLocaltion = (int)(birthHoroscope.CurrentTransitDate.Kethu.AjustedLongitude / 10) * 10,
                KethuHouse = birthHoroscope.CurrentTransitDate.Kethu.HouseNumber,
                KethuRashi = birthHoroscope.CurrentTransitDate.Kethu.Rasi.Name,

                UranusLocaltionFromMesha = (int)(birthHoroscope.CurrentTransitDate.Uranus.Longitude / 10) * 10,
                UranusLocaltionFromSun = (int)((birthHoroscope.CurrentTransitDate.Uranus.Longitude - birthHoroscope.CurrentTransitDate.Sun.Longitude) / 10) * 10,
                UranusLocaltionFromMoon = (int)((birthHoroscope.CurrentTransitDate.Uranus.Longitude - birthHoroscope.CurrentTransitDate.Moon.Longitude) / 10) * 10,
                UranusLocaltion = (int)(birthHoroscope.CurrentTransitDate.Uranus.AjustedLongitude / 10) * 10,
                UranusHouse = birthHoroscope.CurrentTransitDate.Uranus.HouseNumber,
                UranusRashi = birthHoroscope.CurrentTransitDate.Uranus.Rasi.Name,

                NeptuneLocaltionFromMesha = (int)(birthHoroscope.CurrentTransitDate.Neptune.Longitude / 10) * 10,
                NeptuneLocaltionFromSun = (int)((birthHoroscope.CurrentTransitDate.Neptune.Longitude - birthHoroscope.CurrentTransitDate.Sun.Longitude) / 10) * 10,
                NeptuneLocaltionFromMoon = (int)((birthHoroscope.CurrentTransitDate.Neptune.Longitude - birthHoroscope.CurrentTransitDate.Moon.Longitude) / 10) * 10,
                NeptuneLocaltion = (int)(birthHoroscope.CurrentTransitDate.Neptune.AjustedLongitude / 10) * 10,
                NeptuneHouse = birthHoroscope.CurrentTransitDate.Neptune.HouseNumber,
                NeptuneRashi = birthHoroscope.CurrentTransitDate.Neptune.Rasi.Name,

                PlutoLocaltionFromMesha = (int)(birthHoroscope.CurrentTransitDate.Pluto.Longitude / 10) * 10,
                PlutoLocaltionFromSun = (int)((birthHoroscope.CurrentTransitDate.Pluto.Longitude - birthHoroscope.CurrentTransitDate.Sun.Longitude) / 10) * 10,
                PlutoLocaltionFromMoon = (int)((birthHoroscope.CurrentTransitDate.Pluto.Longitude - birthHoroscope.CurrentTransitDate.Moon.Longitude) / 10) * 10,
                PlutoLocaltion = (int)(birthHoroscope.CurrentTransitDate.Pluto.AjustedLongitude / 10) * 10,
                PlutoHouse = birthHoroscope.CurrentTransitDate.Pluto.HouseNumber,
                PlutoRashi = birthHoroscope.CurrentTransitDate.Pluto.Rasi.Name
            };
        }

        public BirthData GetMostCommonBirthData(List<BirthData> dataList)
        {
            var properties = typeof(BirthData).GetProperties();
            var commonBirthData = new BirthData();

            foreach (var property in properties)
            {
                var mostCommonValue = dataList
                    .GroupBy(x => property.GetValue(x))
                    .OrderByDescending(g => g.Count())
                    .Select(g => g.Key)
                    .FirstOrDefault();

                // Check if mostCommonValue is null before setting it
                if (mostCommonValue != null)
                    property.SetValue(commonBirthData, mostCommonValue);
            }

            return commonBirthData;
        }

        public BirthData GetMostCommonBirthDataNewNew(List<BirthData> dataList, out Dictionary<string, int> propertyCounts)
        {
            var properties = typeof(BirthData).GetProperties();

            var commonCounts = new Dictionary<string, Dictionary<object, int>>();
            propertyCounts = new Dictionary<string, int>();

            // Count occurrences of each property value
            foreach (var property in properties)
            {
                var propertyValues = dataList.Select(x => property.GetValue(x)).ToList();
                var valueCounts = propertyValues.GroupBy(x => x)
                                                 .ToDictionary(g => g.Key, g => g.Count());

                commonCounts[property.Name] = valueCounts;

                var mostCommonValue = valueCounts.OrderByDescending(kv => kv.Value).FirstOrDefault();
                if (mostCommonValue.Key != null)
                {
                    propertyCounts[property.Name] = mostCommonValue.Value;
                }
            }

            // Create a new BirthData object using the most common properties
            var mostCommonDataProperties = commonCounts.OrderByDescending(property => property.Value.Values.Sum()).FirstOrDefault();
            var mostCommonData = new BirthData();

            foreach (var property in properties)
            {
                var mostCommonPropertyValue = dataList.Select(x => property.GetValue(x))
                                                      .GroupBy(x => x)
                                                      .OrderByDescending(g => g.Count())
                                                      .FirstOrDefault()?.Key;

                if (mostCommonPropertyValue != null)
                {
                    var propertyValue = Convert.ChangeType(mostCommonPropertyValue, property.PropertyType);

                    // Check if the property is writable
                    if (property.CanWrite)
                    {
                        property.SetValue(mostCommonData, propertyValue);
                    }
                }
                else
                {
                    // Use the corresponding property value from the first BirthData object
                    var firstData = dataList.FirstOrDefault();
                    if (firstData != null)
                    {
                        var propertyValue = property.GetValue(firstData);

                        // Check if the property is writable
                        if (property.CanWrite)
                        {
                            property.SetValue(mostCommonData, propertyValue);
                        }
                    }
                }
            }

            return mostCommonData;
        }

        public static double Compare(BirthData data1, BirthData data2, Dictionary<string, int> keyValuePairs, int minCount)
        {
            var properties = typeof(BirthData).GetProperties();
            int totalProperties = properties.Length;
            int matchingProperties = 0;
            int relatedProperties = 0;
            int i = 0;
            foreach (var property in properties)
            { 
                var value1 = property.GetValue(data1);
                int itemCount = keyValuePairs.Values.ToArray()[i];
                if (itemCount > minCount)
                {
                    relatedProperties++;
                    var value2 = property.GetValue(data2);
                    // Compare property values, considering null values
                    if ((value1 == null && value2 == null) ||
                        (value1 != null && value1.Equals(value2)))
                        matchingProperties++;
                }
                i++;
            }

            // Calculate the percentage of matching properties
            double matchPercentage = (double)matchingProperties / relatedProperties;
            return matchPercentage;
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (listViewEventDate.SelectedItems.Count > 0)
            {
                // Remove the selected item
                ListViewItem selectedItem = listViewEventDate.SelectedItems[0];
                listViewEventDate.Items.Remove(selectedItem);
            }
        }

        Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();
        BirthData mostCommonBirthData;
        private void buttonRelate_Click(object sender, EventArgs e)
        {
            if (dataList != null && dataList.Count > 0)
            {
                mostCommonBirthData = GetMostCommonBirthDataNewNew(dataList, out keyValuePairs);
                BindingSource bSource = new BindingSource();
                bSource.DataSource = mostCommonBirthData;
                this.dataGridViewRelation.DataSource = bSource;
            }
        }

        private void dataGridViewRelation_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex == 0)
            {
                // Get the value of the cell

                string value = dataGridViewRelation.Columns[e.ColumnIndex].Name;
                KeyValuePair<string, int> item = keyValuePairs.FirstOrDefault(x => x.Key == value);
                if (item.Value >= dataList.Count / 2)
                {
                    e.CellStyle.BackColor = Color.Red;
                    e.CellStyle.ForeColor = Color.White;
                }
            }
        }

        bool stopFinding = false;
        double dayIncrement = 1;
        private BackgroundWorker backgroundWorker;
        AstroPlace futurePlace = new AstroPlace();
        DateTime eventDate;
        private void InitializeBackgroundWorker()
        {
            if (this.comboBoxIncrement.SelectedItem != null)
            {
                backgroundWorker = new BackgroundWorker();
                backgroundWorker.WorkerReportsProgress = true;
                backgroundWorker.DoWork += BackgroundWorker_DoWork;
                backgroundWorker.ProgressChanged += BackgroundWorker_ProgressChanged;
                dayIncrement = Convert.ToDouble(this.comboBoxIncrement.SelectedItem.ToString());
                DateTime startDate = this.dateTimePickerStartingDate.Value;
                DateTime eventDate = this.dateTimePickerStartingDate.Value;
                string longitude = this.textBoxLong2.Text;
                string latitude = this.textBoxLat2.Text;

                futurePlace = new AstroPlace(Convert.ToDouble(latitude)
                    , Convert.ToDouble(longitude), eventDate);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFuture_Click(object sender, EventArgs e)
        {
            InitializeBackgroundWorker();
            backgroundWorker.RunWorkerAsync();     
        }

        List<BirthData> futureBirthObject = new List<BirthData>();
        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Your long-running task here
            // Update progress
            backgroundWorker.ReportProgress(50);
            eventDate = futurePlace.OriginalDateTime;
            // Do other work...
            while (!stopFinding)
            {
                backgroundWorker.ReportProgress(50);
                if (mostCommonBirthData != null)
                {
                    futurePlace = new AstroPlace(futurePlace.Latitude
                         , futurePlace.Longitude, futurePlace.OriginalDateTime.AddDays(dayIncrement));
                    AstroCalculator birthCalculator = new AstroCalculator(futurePlace);
                    List<AstroPlanet> birthPlantes = birthCalculator.CalculatePlanetPositionWithDetailsOptmized(false);
                    Horoscope birthHoroscope = birthCalculator.CalculateHoroscope(birthPlantes);
                    birthHoroscope.CurrentTransitDate = birthCalculator;
                    birthHoroscope.CurrentTransitDate.PlaceData = futurePlace;

                    BirthData dataObject = GetBirthDataObject(birthHoroscope);
                    if (Compare(dataObject, mostCommonBirthData, keyValuePairs, dataList.Count/2) >= .50)
                    {
                        this.toolStripStatusLabelNextDate.Text = dataObject.DateTime.ToString();
                        futureBirthObject.Add(dataObject);
                    }
                }
                if (this.toolStripProgressBarStatus.Value == 50)
                    backgroundWorker.ReportProgress(100);
                else
                    backgroundWorker.ReportProgress(0);
                System.Threading.Thread.Sleep(100);
            }
        }

        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Update UI here
            this.toolStripProgressBarStatus.Value = e.ProgressPercentage;
            BindingSource furtureDataSource = new BindingSource();
            furtureDataSource.DataSource = futureBirthObject;
            this.dataGridViewFutureMapping.DataSource = furtureDataSource;
            this.toolStripStatusLabelNextDate.Text = futurePlace.OriginalDateTime.ToString();

        }
        private void buttonStop_Click(object sender, EventArgs e)
        {
            stopFinding = true;
            this.toolStripProgressBarStatus.Value = 0;
        }

        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            // Synchronize horizontal scrolling between dataGridView1 and dataGridView2
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                dataGridViewRelation.HorizontalScrollingOffset = dataGridViewFutureMapping.HorizontalScrollingOffset;
            }
        }
    }
}
