using ChaNiBaaStra.DataModels;
using ChaNiBaaStra.Utilities;
using SwissEphNet;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace ChaNiBaaStra
{
    public partial class GetBirthData : Form
    {
        public GetBirthData(BirthDataSaveObject birthPlace) : this(birthPlace.BirthPlace, birthPlace.TransitPlace) { }

        

        public GetBirthData(AstroPlace birthPlace, AstroPlace transitPlace)
        {
            InitializeComponent();
            int[] tzBirth = AstroUtility.GetDegreeMinuteSeconds(-1 * birthPlace.Longitude / 15.0);
            this.textBoxTimezone.Text = tzBirth[0].ToString() + ":" + tzBirth[1];

            int[] tzTransit = AstroUtility.GetDegreeMinuteSeconds(-1 * transitPlace.Longitude / 15.0);
            this.textBoxTimezone.Text = tzTransit[0].ToString() + ":" + tzTransit[1];

            LocationDetails birthlData = new Utilities.LocationDetails();
            birthlData.Load();

            LocationDetails transitlData = new Utilities.LocationDetails();
            transitlData.Load();

            this.dateTimePickerBirthDateTime.Value = birthPlace.OriginalDateTime;
            comboBoxCountry.DataSource = birthlData.Countries;
            comboBoxTransitCountry.DataSource = transitlData.Countries;

            //choose the specific field to display
            comboBoxCountry.DisplayMember = "Country";
            comboBoxCountry.ValueMember = "Country";
            comboBoxTransitCountry.DisplayMember = "Country";
            comboBoxTransitCountry.ValueMember = "Country";

            comboBoxCity.DisplayMember = "City";
            comboBoxCity.ValueMember = "Id";
            comboBoxTransitCity.DisplayMember = "City";
            comboBoxTransitCity.ValueMember = "Id";
            //set default selected value
            comboBoxCountry.SelectedValue = "Select Country";
            comboBoxCountry.SelectedItem = comboBoxCountry.Items
                .Cast<CountryItem>().FirstOrDefault(x => x.Country == birthPlace.Country);
            comboBoxCountry.Focus();

            comboBoxTransitCountry.SelectedValue = "Select Country";
            comboBoxTransitCountry.SelectedItem = comboBoxTransitCountry.Items
                .Cast<CountryItem>().FirstOrDefault(x => x.Country == transitPlace.Country);
            comboBoxTransitCountry.Focus();

            comboBoxCity.SelectedValue = "Select City";
            comboBoxCity.SelectedItem = comboBoxCity.Items
                .Cast<LocationItem>().FirstOrDefault(x => x.City == birthPlace.City);
            comboBoxCity.Focus();

            comboBoxTransitCity.SelectedValue = "Select City";
            comboBoxTransitCity.SelectedItem = comboBoxTransitCity.Items
                .Cast<LocationItem>().FirstOrDefault(x => x.City == transitPlace.City);
            comboBoxTransitCity.Focus();

            this.textBoxLatitude.Text = birthPlace.Latitude.ToString();
            this.textBoxLongitude.Text = birthPlace.Longitude.ToString();
            this.textBoxTransitLatitude.Text = transitPlace.Latitude.ToString();
            this.textBoxTransitLongitude.Text = transitPlace.Longitude.ToString();

            this.textBoxName.Text = birthPlace.PersonName;
            this.checkBoxIsMale.Checked = birthPlace.IsMale;
        }

        public GetBirthData() : this(new BirthDataSaveObject())
        {
            /*int[] tz = AstroUtility.GetDegreeMinuteSeconds(-1 * Convert.ToDouble(this.textBoxLongitude.Text) / 15.0);
            this.textBoxTimezone.Text = tz[0].ToString() + ":" + tz[1];
            LocationDetails lData = new Utilities.LocationDetails();
            lData.Load();
            comboBoxCountry.DataSource = lData.Countries;
            //choose the specific field to display
            comboBoxCountry.DisplayMember = "Country";
            comboBoxCountry.ValueMember = "Country";
            //set default selected value
            comboBoxCountry.SelectedValue = "Select Country";
            comboBoxCountry.SelectedItem = comboBoxCountry.Items
                .Cast<CountryItem>().FirstOrDefault(x => x.Country == "Sri Lanka");
            comboBoxCountry.Focus();
            comboBoxCity.SelectedItem = comboBoxCity.Items
                .Cast<LocationItem>().FirstOrDefault(x => x.City == "Colombo");
            comboBoxCity.Focus();*/
        }

        public string PersonName { get => _name; set => _name = value; }
        public double Longitute { get => _longitute; set => _longitute = value; }
        public DateTime BirthTime { get => _birthTime; set => _birthTime = value; }
        public double Latitude { get => _latitude; set => _latitude = value; }
        public string Country { get; set; }
        public string City { get; set; }
        public bool IsMale { get; private set; }

        public AstroPlace BirthPlace { get; private set; }
        public AstroPlace TransitPlace { get; private set; }

        private string _name;
        private double _longitute;
        private double _latitude;
        private DateTime _birthTime;

        private void buttonSave_Click(object sender, EventArgs e)
        {
            this._birthTime = dateTimePickerBirthDateTime.Value;
            this._longitute = Convert.ToDouble(this.textBoxLongitude.Text);
            this._latitude = Convert.ToDouble(this.textBoxLatitude.Text);
            this._name = this.textBoxName.Text;
            this.Country = this.comboBoxCountry.Text;
            this.City = this.comboBoxCity.Text;
            this.IsMale = this.checkBoxIsMale.Checked;
            BirthPlace = new AstroPlace(City, Country, PersonName, Latitude, Longitute, BirthTime, IsMale);
            TransitPlace = new AstroPlace(this.comboBoxTransitCity.Text, this.comboBoxTransitCountry.Text
                , this.textBoxName.Text, Convert.ToDouble(this.textBoxTransitLatitude.Text)
                , Convert.ToDouble(this.textBoxTransitLongitude.Text), System.DateTime.Now, IsMale);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void textBoxLongitude_TextChanged(object sender, EventArgs e)
        {
            int[] tz = AstroUtility.GetDegreeMinuteSeconds(-1 * Convert.ToDouble(this.textBoxLongitude.Text) / 15.0);
            this.textBoxTimezone.Text = tz[0].ToString() + ":" + tz[1];
        }

        private void textBoxTransitLongitude_TextChanged(object sender, EventArgs e)
        {
            int[] tz = AstroUtility.GetDegreeMinuteSeconds(-1 * Convert.ToDouble(this.textBoxTransitLongitude.Text) / 15.0);
            this.textBoxTransitTimeZone.Text = tz[0].ToString() + ":" + tz[1];
        }

        private void comboBoxCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBoxCountry.SelectedValue != null)
            {
                if (this.comboBoxTransitCountry.Items.Count > 1)
                    this.comboBoxTransitCountry.SelectedItem = comboBoxTransitCountry.Items
                        .Cast<CountryItem>().FirstOrDefault(x => x.Country == (string)comboBoxCountry.SelectedValue);
                LocationDetails lData = new Utilities.LocationDetails();
                comboBoxCity.DataSource = ((CountryItem)this.comboBoxCountry.SelectedItem).LocationList;
                //choose the specific field to display
                comboBoxCity.DisplayMember = "City";
                comboBoxCity.ValueMember = "Id";
                //set default selected value
                comboBoxCity.SelectedValue = "Select City";
            }
        }

        private void comboBoxCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBoxCity.SelectedValue != null)
            {
                if (comboBoxTransitCity.Items.Count > 1)
                    this.comboBoxTransitCity.SelectedItem = comboBoxTransitCity.Items
                        .Cast<LocationItem>().FirstOrDefault(x => x.City == ((LocationItem)comboBoxCity.SelectedItem).City);
                LocationItem lItem = (LocationItem)this.comboBoxCity.SelectedItem;
                if (lItem != null)
                {
                    this.textBoxLatitude.Text = lItem.Latitude.ToString();
                    this.textBoxLongitude.Text = lItem.Longitude.ToString();
                }
            }
        }

        private void comboBoxTransitCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBoxTransitCountry.SelectedValue != null)
            {
                LocationDetails lData = new Utilities.LocationDetails();
                comboBoxTransitCity.DataSource = ((CountryItem)this.comboBoxTransitCountry.SelectedItem).LocationList;
                //choose the specific field to display
                comboBoxTransitCity.DisplayMember = "City";
                comboBoxTransitCity.ValueMember = "Id";
                //set default selected value
                comboBoxTransitCity.SelectedValue = "Select City";
            }
        }

        private void comboBoxTransitCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBoxTransitCity.SelectedValue != null)
            {
                LocationItem lItem = (LocationItem)this.comboBoxTransitCity.SelectedItem;
                if (lItem != null)
                {
                    this.textBoxTransitLatitude.Text = lItem.Latitude.ToString();
                    this.textBoxTransitLongitude.Text = lItem.Longitude.ToString();
                }
            }
        }
    }
}
