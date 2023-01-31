using ChaNiBaaStra.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChaNiBaaStra
{
    public partial class GetBirthData : Form
    {
        public GetBirthData()
        {
            InitializeComponent();
            int[] tz = AstroUtility.GetDegreeMinuteSeconds(-1 * Convert.ToDouble(this.textBoxLongitude.Text) / 15.0);
            this.textBoxTimezone.Text = tz[0].ToString() + ":" + tz[1];
        }

        public string PersonName { get => name; set => name = value; }
        public double Longitute { get => _longitute; set => _longitute = value; }
        public DateTime BirthTime { get => _birthTime; set => _birthTime = value; }
        public double Latitude { get => _latitude; set => _latitude = value; }

        private string name;
        private double _longitute;
        private double _latitude;
        private DateTime _birthTime;

        private void buttonSave_Click(object sender, EventArgs e)
        {
            this._birthTime = dateTimePickerBirthDateTime.Value;
            this._longitute = Convert.ToDouble(this.textBoxLongitude.Text);
            this._latitude = Convert.ToDouble(this.textBoxLatitude.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void textBoxLatitude_TextChanged(object sender, EventArgs e)
        {
            int[] tz = AstroUtility.GetDegreeMinuteSeconds(-1 * Convert.ToDouble(this.textBoxLongitude.Text) / 15.0);
            this.textBoxTimezone.Text = tz[0].ToString() + ":" + tz[1];
        }

        private void textBoxLongitude_TextChanged(object sender, EventArgs e)
        {
            this.textBoxTimezone.Text = (-1 * Convert.ToDouble(this.textBoxLongitude.Text) / 15.0).ToString();
        }
    }
}
